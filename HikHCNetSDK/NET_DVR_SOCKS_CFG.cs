using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SOCKS_CFG
    {
        public uint dwSize;             // 结构体大小
        public byte byEnableSocks;          // 使能 0：关闭 1：开启
        public byte byVersion;              // SOCKS版本 4：SOCKS4   5：SOCKS5
        public ushort wProxyPort;               // 代理端口，默认1080
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byProxyaddr;      // 代理IP地址，可以是域名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byUserName;   // 用户名 SOCKS才用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPassword;           // 密码SOCKS5才用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LOCAL_ADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byLocalAddr;  //不使用socks代理的网段，格式为"ip/netmask;ip/netmask;…"
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
