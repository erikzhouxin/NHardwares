namespace System.Data.YuShiNetDevSDK
{
    public struct NETDEV_PASSENGER_FLOW_STATISTIC_DATA_S
    {
        public Int32 dwChannelID;                  /* Channel ID */
        public Int64 tReportTime;                  /* unix Report time */
        public Int32 tInterval;                    /* Interval time */
        public Int32 dwEnterNum;                   /* Enter num */
        public Int32 dwExitNum;                    /* Exit num */
        public Int32 dwTotalEnterNum;              /* Total enter num */
        public Int32 dwTotalExitNum;               /* Total exit num */
    }

}
