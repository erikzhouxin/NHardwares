using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SYSTEM_NTP_INFO_LIST_S
    {
        public Int64 ulNum;                      /*  NTP Server Number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public NETDEV_SYSTEM_IPADDR_INFO_S[] astNTPServerInfoList;          /* NTP   NTP information */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                               /* Reserved */
    };

}
