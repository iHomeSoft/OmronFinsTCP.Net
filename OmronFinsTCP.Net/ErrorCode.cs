using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmronFinsTCP.Net
{
    class ErrorCode
    {        
        /// <summary>
        /// （若返回的头指令为3）检查命令头中的错误代码
        /// </summary>
        /// <param name="Code">错误代码</param>
        /// <returns>指示程序是否可以继续进行</returns>
        internal static bool CheckHeadError(byte Code)
        {
            switch (Code)
            {
                case 0x00: return true;
                case 0x01: return false;//RaiseException("the head is not 'FINS'");
                case 0x02: return false;//RaiseException("the data length is too long");
                case 0x03: return false;//RaiseException("the command is not supported");
            }
            //no hit
            return false;//RaiseException("unknown exception");
        }

        /// <summary>
        /// 检查命令帧中的EndCode
        /// </summary>
        /// <param name="Main">主码</param>
        /// <param name="Sub">副码</param>
        /// <returns>指示程序是否可以继续进行</returns>
        internal static bool CheckEndCode(byte Main, byte Sub)
        {
            switch (Main)
            {
                case 0x00:
                    switch (Sub)
                    {
                        case 0x00: return true;//the only situation of success
                        case 0x01: return false;//RaiseException("service canceled");
                    }
                    break;

                case 0x01:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("local node not in network");
                        case 0x02: return false;//RaiseException("token timeout");
                        case 0x03: return false;//RaiseException("retries failed");
                        case 0x04: return false;//RaiseException("too many send frames");
                        case 0x05: return false;//RaiseException("node address range error");
                        case 0x06: return false;//RaiseException("node address duplication");
                    }
                    break;

                case 0x02:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("destination node not in network");
                        case 0x02: return false;//RaiseException("unit missing");
                        case 0x03: return false;//RaiseException("third node missing");
                        case 0x04: return false;//RaiseException("destination node busy");
                        case 0x05: return false;//RaiseException("response timeout");
                    }
                    break;

                case 0x03:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("communications controller error");
                        case 0x02: return false;//RaiseException("CPU unit error");
                        case 0x03: return false;//RaiseException("controller error");
                        case 0x04: return false;//RaiseException("unit number error");
                    }
                    break;

                case 0x04:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("undefined command");
                        case 0x02: return false;//RaiseException("not supported by model/version");
                    }
                    break;

                case 0x05:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("destination address setting error");
                        case 0x02: return false;//RaiseException("no routing tables");
                        case 0x03: return false;//RaiseException("routing table error");
                        case 0x04: return false;//RaiseException("too many relays");
                    }
                    break;

                case 0x10:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("command too long");
                        case 0x02: return false;//RaiseException("command too short");
                        case 0x03: return false;//RaiseException("elements/data don't match");
                        case 0x04: return false;//RaiseException("command format error");
                        case 0x05: return false;//RaiseException("header error");
                    }
                    break;

                case 0x11:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("area classification missing");
                        case 0x02: return false;//RaiseException("access size error");
                        case 0x03: return false;//RaiseException("address range error");
                        case 0x04: return false;//RaiseException("address range exceeded");
                        case 0x06: return false;//RaiseException("program missing");
                        case 0x09: return false;//RaiseException("relational error");
                        case 0x0a: return false;//RaiseException("duplicate data access");
                        case 0x0b: return false;//RaiseException("response too long");
                        case 0x0c: return false;//RaiseException("parameter error");
                    }
                    break;

                case 0x20:
                    switch (Sub)
                    {
                        case 0x02: return false;//RaiseException("protected");
                        case 0x03: return false;//RaiseException("table missing");
                        case 0x04: return false;//RaiseException("data missing");
                        case 0x05: return false;//RaiseException("program missing");
                        case 0x06: return false;//RaiseException("file missing");
                        case 0x07: return false;//RaiseException("data mismatch");
                    }
                    break;

                case 0x21:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("read-only");
                        case 0x02: return false;//RaiseException("protected , cannot write data link table");
                        case 0x03: return false;//RaiseException("cannot register");
                        case 0x05: return false;//RaiseException("program missing");
                        case 0x06: return false;//RaiseException("file missing");
                        case 0x07: return false;//RaiseException("file name already exists");
                        case 0x08: return false;//RaiseException("cannot change");
                    }
                    break;

                case 0x22:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("not possible during execution");
                        case 0x02: return false;//RaiseException("not possible while running");
                        case 0x03: return false;//RaiseException("wrong PLC mode");
                        case 0x04: return false;//RaiseException("wrong PLC mode");
                        case 0x05: return false;//RaiseException("wrong PLC mode");
                        case 0x06: return false;//RaiseException("wrong PLC mode");
                        case 0x07: return false;//RaiseException("specified node not polling node");
                        case 0x08: return false;//RaiseException("step cannot be executed");
                    }
                    break;

                case 0x23:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("file device missing");
                        case 0x02: return false;//RaiseException("memory missing");
                        case 0x03: return false;//RaiseException("clock missing");
                    }
                    break;

                case 0x24:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("table missing");
                    }
                    break;

                case 0x25:
                    switch (Sub)
                    {
                        case 0x02: return false;//RaiseException("memory error");
                        case 0x03: return false;//RaiseException("I/O setting error");
                        case 0x04: return false;//RaiseException("too many I/O points");
                        case 0x05: return false;//RaiseException("CPU bus error");
                        case 0x06: return false;//RaiseException("I/O duplication");
                        case 0x07: return false;//RaiseException("CPU bus error");
                        case 0x09: return false;//RaiseException("SYSMAC BUS/2 error");
                        case 0x0a: return false;//RaiseException("CPU bus unit error");
                        case 0x0d: return false;//RaiseException("SYSMAC BUS No. duplication");
                        case 0x0f: return false;//RaiseException("memory error");
                        case 0x10: return false;//RaiseException("SYSMAC BUS terminator missing");
                    }
                    break;

                case 0x26:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("no protection");
                        case 0x02: return false;//RaiseException("incorrect password");
                        case 0x04: return false;//RaiseException("protected");
                        case 0x05: return false;//RaiseException("service already executing");
                        case 0x06: return false;//RaiseException("service stopped");
                        case 0x07: return false;//RaiseException("no execution right");
                        case 0x08: return false;//RaiseException("settings required before execution");
                        case 0x09: return false;//RaiseException("necessary items not set");
                        case 0x0a: return false;//RaiseException("number already defined");
                        case 0x0b: return false;//RaiseException("error will not clear");
                    }
                    break;

                case 0x30:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("no access right");
                    }
                    break;

                case 0x40:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("service aborted");
                    }
                    break;
            }
            //no hit
            return false;//RaiseException("unknown exception");
        }
    }
}
