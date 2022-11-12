using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NETWORKCFG_S
    {
        public Int32 dwMTU;                                         /* MTU value */
        public Int32 dwIPv4DHCP;                                    /* DHCP of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string Ipv4AddressStr;                                /* IP address of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szIPv4GateWay;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szIPv4SubnetMask;                          /* Gateway of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 480)]
        public byte[] byRes;                                        /* Reserved */
    }

}
