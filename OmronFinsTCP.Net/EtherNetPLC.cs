using System;
using System.Net.Sockets;
using System.Threading;

namespace OmronFinsTCP.Net
{
    public class EtherNetPLC
    {
        /// <summary>
        /// PLC节点号，调试方法，一般不需要使用
        /// </summary>
        public string PLCNode
        {
            get { return BasicClass.plcNode.ToString(); }
        }

        /// <summary>
        /// PC节点号，调试方法，一般不需要使用
        /// </summary>
        public string PCNode
        {
            get { return BasicClass.pcNode.ToString(); }
        }

        /// <summary>
        /// 实例化PLC操作对象
        /// </summary>
        public EtherNetPLC()
        {
            BasicClass.Client = new TcpClient();
        }

        /// <summary>
        /// 与PLC建立TCP连接
        /// </summary>
        /// <param name="rIP">PLC的IP地址</param>
        /// <param name="rPort">端口号，默认9600</param>
        /// <param name="timeOut">超时时间，默认3000毫秒</param>
        /// <returns></returns>
        public short Link(string rIP, short rPort, short timeOut = 3000)
        {
            if(BasicClass.PingCheck(rIP,timeOut))
            {
                BasicClass.Client.Connect(rIP, (int)rPort);
                BasicClass.Stream = BasicClass.Client.GetStream();
                Thread.Sleep(10);

                if (BasicClass.SendData(FinsClass.HandShake()) != 0)
                {
                    return -1;
                }
                else
                {
                    //开始读取返回信号
                    byte[] buffer = new byte[24];
                    if (BasicClass.ReceiveData(buffer) != 0)
                    {
                        return -1;
                    }
                    else
                    {
                        if (buffer[15] != 0)//TODO:这里的15号是不是ERR信息暂时不能完全肯定
                            return -1;
                        else
                        {
                            BasicClass.pcNode = buffer[19];
                            BasicClass.plcNode = buffer[23];
                            return 0;
                        }
                    }
                }
            }
            else
            {
                //连接超时
                return -1;
            }
        }

        /// <summary>
        /// 关闭PLC操作对象的TCP连接
        /// </summary>
        /// <returns></returns>
        public short Close()
        {
            try
            {
                BasicClass.Stream.Close();
                BasicClass.Client.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 读值方法（多个连续值）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">起始地址</param>
        /// <param name="cnt">地址个数</param>
        /// <param name="reData">返回值</param>
        /// <returns></returns>
        public short ReadWords(PlcMemory mr, short ch, short cnt, out short[] reData)
        {
            reData = new short[(int)(cnt)];//储存读取到的数据

            short tempCnt = 0;
            short tempCh = 0;
            if (cnt > 999)
            {
                tempCnt = (short)(cnt - 999);
                tempCh = (short)(ch + 999);
                cnt = 999;
            }

            int num = (int)(30 + cnt * 2);//接收数据(Text)的长度,字节数
            byte[] buffer = new byte[num];//用于接收数据的缓存区大小
            byte[] array = FinsClass.FinsCmd(RorW.Read, mr, MemoryType.Word, ch, 00, cnt);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回，开始读取返回的具体数值
                            for (int i = 0; i < cnt; i++)
                            {
                                //返回的数据从第30字节开始储存的,
                                //PLC每个字占用两个字节，且是高位在前，这和微软的默认低位在前不同
                                //因此无法直接使用，reData[i] = BitConverter.ToInt16(buffer, 30 + i * 2);
                                //先交换了高低位的位置，然后再使用BitConverter.ToInt16转换
                                byte[] temp = new byte[] { buffer[30 + i * 2 + 1], buffer[30 + i * 2] };
                                reData[i] = BitConverter.ToInt16(temp, 0);
                            }

                            short[] tempReData;
                            if (tempCnt > 0)//有多余数值才执行循环读取
                            {
                                ReadWords(mr, tempCh, tempCnt, out tempReData);
                                tempReData.CopyTo(reData, 999);
                                //reData.CopyTo(tempReData, 730);
                            }

                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 读单个字方法
        /// </summary>
        /// <param name="mr"></param>
        /// <param name="ch"></param>
        /// <param name="reData"></param>
        /// <returns></returns>
        public short ReadWord(PlcMemory mr, short ch, out short reData)
        {
            short[] temp;
            reData = new short();
            short re = ReadWords(mr, ch, (short)1, out temp);
            if (re != 0)
                return -1;
            else
            {
                reData = temp[0];
                return 0;
            }
        }

        /// <summary>
        /// 写值方法（多个连续值）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">起始地址</param>
        /// <param name="cnt">地址个数</param>
        /// <param name="inData">写入值</param>
        /// <returns></returns>
        public short WriteWords(PlcMemory mr, short ch, short cnt, short[] inData)
        {            
            byte[] buffer = new byte[30];
            byte[] arrayhead = FinsClass.FinsCmd(RorW.Write, mr, MemoryType.Word, ch, 00, cnt);//前34字节和读指令基本一直，还需要拼接下面的输入数据数组
            byte[] wdata = new byte[(int)(cnt * 2)];
            //转换写入值到wdata数组
            for (int i = 0; i < cnt; i++)
            {
                byte[] temp = BitConverter.GetBytes(inData[i]);
                wdata[i * 2] = temp[1];//转换为PLC的高位在前储存方式
                wdata[i * 2 + 1] = temp[0];
            }
            //拼接写入数组
            byte[] array = new byte[(int)(cnt * 2 + 34)];
            arrayhead.CopyTo(array, 0);
            wdata.CopyTo(array, 34);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回0
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 写单个字方法
        /// </summary>
        /// <param name="mr"></param>
        /// <param name="ch"></param>
        /// <param name="inData"></param>
        /// <returns></returns>
        public short WriteWord(PlcMemory mr, short ch, short inData)
        {
            short[] temp = new short[] { inData };
            short re = WriteWords(mr, ch, (short)1, temp);
            if (re != 0)
                return -1;
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 读值方法-按位bit（单个）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">地址000.00</param>
        /// <param name="bs">返回开关状态枚举EtherNetPLC.BitState，0/1</param>
        /// <returns></returns>
        public short GetBitState(PlcMemory mr, string ch, out short bs)
        {
            bs = new short();
            byte[] buffer = new byte[31];//用于接收数据的缓存区大小
            short cnInt = short.Parse(ch.Split('.')[0]);
            short cnBit = short.Parse(ch.Split('.')[1]);
            byte[] array = FinsClass.FinsCmd(RorW.Read, mr, MemoryType.Bit, cnInt, cnBit, 1);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回，开始读取返回的具体数值
                            bs = (short)buffer[30];
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 写值方法-按位bit（单个）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">地址000.00</param>
        /// <param name="bs">开关状态枚举EtherNetPLC.BitState，0/1</param>
        /// <returns></returns>
        public short SetBitState(PlcMemory mr, string ch, BitState bs)
        {
            byte[] buffer = new byte[30];
            short cnInt = short.Parse(ch.Split('.')[0]);
            short cnBit = short.Parse(ch.Split('.')[1]);
            byte[] arrayhead = FinsClass.FinsCmd(RorW.Write, mr, MemoryType.Bit, cnInt, cnBit, 1);
            byte[] array = new byte[35];
            arrayhead.CopyTo(array, 0);
            array[34] = (byte)bs;
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回0
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 读一个浮点数的方法，单精度，在PLC中占两个字
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">起始地址，会读取两个连续的地址，因为单精度在PLC中占两个字</param>
        /// <param name="reData">返回一个float型</param>
        /// <returns></returns>
        public short ReadReal(PlcMemory mr, short ch,out float reData)
        {
            reData = new float();
            int num = (int)(30 + 2 * 2);//接收数据(Text)的长度,字节数
            byte[] buffer = new byte[num];//用于接收数据的缓存区大小
            byte[] array = FinsClass.FinsCmd(RorW.Read, mr, MemoryType.Word, ch, 00, 2);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回，开始读取返回的具体数值
                            byte[] temp = new byte[] { buffer[30 + 1], buffer[30], buffer[30 + 3], buffer[30 + 2] };
                            reData = BitConverter.ToSingle(temp, 0);
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}