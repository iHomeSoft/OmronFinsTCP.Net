using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace OmronFinsTCP.Net
{
    class BasicClass
    {
        internal static TcpClient Client;
        internal static NetworkStream Stream;
        internal static byte pcNode, plcNode;

        //检查PLC链接状况
        internal static bool PingCheck(string ip,int timeOut)
        {
            Ping ping = new Ping();
            PingReply pr = ping.Send(ip, timeOut);
            if (pr.Status == IPStatus.Success)
                return true;
            else
                return false;
        }

        //内部方法，发送数据
        internal static short SendData(byte[] sd)
        {
            try
            {
                Stream.Write(sd, 0, sd.Length);
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        //内部方法，接收数据
        internal static short ReceiveData(byte[] rd)
        {
            try
            {
                //等待可读数据到底指定的长度，自己想的方法，下面的另一写法参考网络。
                //突然发现，此方法在数据量达不到指定长度时会死循环！
                //while (true)
                //{
                //    Thread.Sleep(1);
                //    if (Client.Available >= rd.Length && Stream.DataAvailable)
                //        break;
                //}
                //this.Stream.Read(rd, 0, rd.Length);
                //另一写法:
                int index = 0;
                do
                {
                    int len = Stream.Read(rd, index, rd.Length - index);
                    if (len == 0)
                        return -1;//这里控制读取不到数据时就跳出,网络异常断开，数据读取不完整。
                    else
                        index += len;
                } while (index < rd.Length);
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}
