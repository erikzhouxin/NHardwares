using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogram
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName; //文件名
        public byte fileType; //文件类型
        public uint fileLen; //文件长度
        public IntPtr fileAddre; // 文件所在的缓存地址
        public uint fileCRC32; //文件CRC32校验码
    }
}
