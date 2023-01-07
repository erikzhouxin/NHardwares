using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单BONDING网卡配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_ONE_BONDING
    {
        public byte byMode;
        public byte byUseDhcp;
        public byte byMasterCard;
        public byte byStatus;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NETWORK_CARD, ArraySubType = UnmanagedType.I1)]
        public byte[] byBond;
        public NET_DVR_ETHERNET_V30 struEtherNet;
        public NET_DVR_IPADDR struGatewayIpAddr;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
