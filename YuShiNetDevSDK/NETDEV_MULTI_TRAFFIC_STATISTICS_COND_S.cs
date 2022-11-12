using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MULTI_TRAFFIC_STATISTICS_COND_S
    {
        public NETDEV_OPERATE_LIST_S stChannelIDs; /* Channel ID List*/
        public UInt32 udwStatisticsType;           /* # NETDEV_TRAFFIC_STATISTICS_TYPE_E Statistics type */
        public UInt32 udwFormType;                 /* # NETDEV_TRAFFIC_STATIC_FORM_TYPE_E Form type */
        public Int64 tBeginTime;                   /* Begin time */
        public Int64 tEndTime;                     /* End time */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                       /* Reserved */
    }

}
