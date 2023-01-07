using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //多网卡网络配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NETCFG_MULTI
    {
        public uint dwSize;
        public byte byDefaultRoute;
        public byte byNetworkCardNum;
        public byte byWorkMode;   //0-普通多网卡模式，1-内外网隔离模式
        public byte byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NETWORK_CARD, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ETHERNET_MULTI[] struEtherNet;//以太网口
        public NET_DVR_IPADDR struManageHost1IpAddr;
        public NET_DVR_IPADDR struManageHost2IpAddr;
        public NET_DVR_IPADDR struAlarmHostIpAddr;
        public ushort wManageHost1Port;
        public ushort wManageHost2Port;
        public ushort wAlarmHostIpPort;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byIpResolver;
        public ushort wIpResolverPort;
        public ushort wDvrPort;
        public ushort wHttpPortNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_IPADDR struMulticastIpAddr;/* 多播组地址 */
        public NET_DVR_PPPOECFG struPPPoE;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
