using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEV_TRAFFIC_STATISTICS_DATA_S
    {
        public Int32 dwSize;                                          /* */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwEnterCount;        /* */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwExitCount;         /* */
    }

}
