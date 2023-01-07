using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_WIFIETHERNET
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sIpAddress;/*IP地址*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sIpMask;/*掩码*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;/*物理地址，只用来显示*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] bRes;
        public uint dwEnableDhcp;/*是否启动dhcp  0不启动 1启动*/
        public uint dwAutoDns;/*如果启动dhcp是否自动获取dns,0不自动获取 1自动获取；对于有线如果启动dhcp目前自动获取dns*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sFirstDns; /*第一个dns域名*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sSecondDns;/*第二个dns域名*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sGatewayIpAddr;/* 网关地址*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] bRes2;
    }

}
