using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEFAULT_VIDEO_COND
    {
        public uint dwSize;         // 结构体大小
        public uint dwChannel;      // 通道号
        public uint dwVideoMode;    // 模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      // 保留
    }
}
