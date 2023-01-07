using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HTTPS_CFG
    {
        public uint dwSize;
        public ushort wHttpsPort;       // HTTPS端口
        public byte byEnable;       // 使能 0：关闭 1：开启
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 125, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
