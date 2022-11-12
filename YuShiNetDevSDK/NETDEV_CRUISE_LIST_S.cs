using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_LIST_S
    {
        public Int32 dwSize;                                         /* Number of patrol routes */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_CRUISEROUTE_NUM)]
        public NETDEV_CRUISE_INFO_S[] astCruiseInfo;      /* Information of patrol routes */
    };

}
