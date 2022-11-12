namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEV_TRAFFIC_STATISTICS_COND_S
    {
        public Int32 dwChannelID;            /* Channel ID */
        public Int32 dwStatisticsType;       /* # NETDEV_TRAFFIC_STATISTICS_TYPE_E Statistics type */
        public Int32 dwFormType;             /* # NETDEV_FORM_TYPE_E Form type */
        public Int64 tBeginTime;             /* Begin time */
        public Int64 tEndTime;               /* End time */
    }

}
