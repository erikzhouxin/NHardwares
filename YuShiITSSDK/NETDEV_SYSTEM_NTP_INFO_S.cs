using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_NTP_INFO_S
    {
        public Int32 bSupportDHCP;                      /* DHCP  Support DHCP or not */
        public NETDEV_SYSTEM_IPADDR_S stAddr;          /* NTP   NTP information */
    };

}
