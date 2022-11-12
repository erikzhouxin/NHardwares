using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_INFO_S
    {
        public Int32 dwCuriseID;                                     /* ID  Route ID */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szCuriseName;                    /* Route name */
        public Int32 dwSize;                                         /* Number of presets included in the route */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_CRUISEPOINT_NUM)]
        public NETDEV_CRUISE_POINT_S[] astCruisePoint;     /* Information of presets included in the route */
    }

}
