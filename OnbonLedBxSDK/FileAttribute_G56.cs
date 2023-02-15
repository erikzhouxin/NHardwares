using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileAttribute_G56
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName;  //文件名
        public byte fileType;     //文件类型
        public int fileLen;      //文件长度
        public int fileCRC;      //文件CRC校验
    }
}
