using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileCRC16_G56
    {
        IntPtr fileAddre;     //文件地址指針
        ushort fileLen;        //文件长度
        ushort fileCRC16;      //文件CRC16校验
    }
}
