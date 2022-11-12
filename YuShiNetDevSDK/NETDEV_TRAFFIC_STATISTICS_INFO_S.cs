using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TRAFFIC_STATISTICS_INFO_S
    {
        public Int32 bIsSuccess;                   /* The success of the query*/
        public Int32 dwChannelID;                  /* Channel ID  */
        public Int32 dwSize;                       /* Number of periods */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwEnterCount;              /* Enter the number of statistics */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM)]
        public Int32[] adwExitCount;               /* Leave the number of statistics */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] byRes;                       /* Reserved */
    }

}
