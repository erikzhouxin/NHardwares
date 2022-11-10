namespace System.Data.YuShiITSSDK
{
    /**
     * @brief  客流量统计信息 结构体定义 Passenger flow statistic infomation Sturcture definition
     * @attention 无 None
     */
    public struct NETDEV_PASSENGER_FLOW_STATISTIC_DATA_S
    {
        public Int32 dwChannelID;                  /* 通道号 Channel ID */
        public Int64 tReportTime;                  /* 上报时间（unix时间戳）Report time */
        public Int32 tInterval;                    /* 间隔时间 Interval time */
        public Int32 dwEnterNum;                   /* 进入人数Enter num */
        public Int32 dwExitNum;                    /* 离开人数 Exit num */
        public Int32 dwTotalEnterNum;              /* 所有进入人数 Total enter num */
        public Int32 dwTotalExitNum;               /* 所有离开人数 Total exit num */
    }

}
