using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 网络配置信息 结构体定义 Network configuration information
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NETWORKCFG_S
    {
        public Int32 dwMTU;                                            /* MTU值  MTU value */
        public Int32 dwIPv4DHCP;                                       /* IPv4的DHCP  DHCP of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string Ipv4AddressStr;                                  /* IPv4的IP地址  IP address of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szIPv4GateWay;                                   /* IPv4的网关地址  Gateway of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public string szIPv4SubnetMask;                                /* IPv4的子网掩码  Subnet mask of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 480)]
        public byte[] byRes;                                           /* 保留字段  Reserved */
    }

}
