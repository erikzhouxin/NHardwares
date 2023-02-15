using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogram_G6
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName; //节目参数文件名
        public byte fileType;    //文件类型
        public uint fileLen;     //参数文件长度
        public IntPtr fileAddre;   //文件所在的缓存地址
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] dfileName;//节目数据文件名
        public byte dfileType;   //节目数据文件类型
        public uint dfileLen;    //数据文件长度
        public IntPtr dfileAddre;  //数据文件缓存地址
    }
}
