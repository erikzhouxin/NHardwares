using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SADPINFO
    {
        public NET_DVR_IPADDR struIP;     // 设备IP地址
        public ushort wPort;      // 设备端口号
        public ushort wFactoryType;   // 设备厂家类型
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.SOFTWARE_VERSION_LEN)]
        public string chSoftwareVersion;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string chSerialNo; // 序列号
        public ushort wEncCnt;   // 编码通道个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;        // MAC 地址
        public NET_DVR_IPADDR struSubDVRIPMask;   // DVR IP地址掩码
        public NET_DVR_IPADDR struGatewayIpAddr;  // 网关
        public NET_DVR_IPADDR struDnsServer1IpAddr; /* 域名服务器1的IP地址 */
        public NET_DVR_IPADDR struDnsServer2IpAddr; /* 域名服务器2的IP地址 */
        public byte byDns;
        public byte byDhcp;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 158, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     // 保留字节
    }
}
