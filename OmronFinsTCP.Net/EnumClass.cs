using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmronFinsTCP.Net
{
    /// <summary>
    /// 寄存器类型,十六进制表示形式
    /// </summary>
    public enum PlcMemory
    {
        //CIO_Word = 0xB0,
        //CIO_Bit = 0x30,
        //WR_Word = 0xB1,
        //WR_Bit = 0x31,
        //DM_Word = 0x82,
        //DM_Bit = 0x02
        //HR_Word =0xB2
        //HR_Bit = 0x32
        //AR_Word =0xB3
        //AR_Bit = 0x33
        CIO,
        WR,
        AR,
        HR,
        DM
    }

    /// <summary>
    /// 地址类型
    /// </summary>
    public enum MemoryType
    {
        Bit,
        Word
    }

    /// <summary>
    /// 数据类型,PLC字为16位数，最高位为符号位，负数表现形式为“取反加一”
    /// </summary>
    public enum DataType
    {
        BIT,
        INT16,
        REAL
    }

    /// <summary>
    /// bit位开关状态，on=1，off=0
    /// </summary>
    public enum BitState
    {
        ON = 1,
        OFF = 0
    }

    /// <summary>
    /// 区分指令的读写类型
    /// </summary>
    public enum RorW
    {
        Read,
        Write
    }
}
