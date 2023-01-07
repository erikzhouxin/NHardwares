using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BONJOUR_CFG
    {
        public uint dwSize;             // 结构体大小
        public byte byEnableBonjour;        // Bonjour使能 0 ：开启 1：关闭
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byFriendlyName;   // 服务名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
