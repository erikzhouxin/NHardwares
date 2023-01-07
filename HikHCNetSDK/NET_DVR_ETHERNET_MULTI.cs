using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单个网卡配置信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ETHERNET_MULTI
    {
        public NET_DVR_IPADDR struDVRIP;
        public NET_DVR_IPADDR struDVRIPMask;
        public uint dwNetInterface;
        public byte byCardType;  //网卡类型，0-普通网卡，1-内网网卡，2-外网网卡
        public byte byRes1;
        public ushort wMTU;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public byte byUseDhcp;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        public NET_DVR_IPADDR struGatewayIpAddr;
        public NET_DVR_IPADDR struDnsServer1IpAddr;
        public NET_DVR_IPADDR struDnsServer2IpAddr;
    }
}
