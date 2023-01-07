using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //网络配置结构(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NETCFG_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ETHERNET_V30[] struEtherNet;//以太网口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPADDR[] struRes1;/*保留*/
        public NET_DVR_IPADDR struAlarmHostIpAddr;/* 报警主机IP地址 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public ushort wAlarmHostIpPort;
        public byte byUseDhcp;
        public byte byRes3;
        public NET_DVR_IPADDR struDnsServer1IpAddr;/* 域名服务器1的IP地址 */
        public NET_DVR_IPADDR struDnsServer2IpAddr;/* 域名服务器2的IP地址 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byIpResolver;
        public ushort wIpResolverPort;
        public ushort wHttpPortNo;
        public NET_DVR_IPADDR struMulticastIpAddr;/* 多播组地址 */
        public NET_DVR_IPADDR struGatewayIpAddr;/* 网关地址 */
        public NET_DVR_PPPOECFG struPPPoE;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
