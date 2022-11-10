namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 客流量统计命令 结构体定义 Command of Passenger flow statistic Structure definition
     * @attention 无 None
     */
    public struct NETDEV_TRAFFIC_STATISTICS_COND_S
    {
        public Int32 dwChannelID;            /* 通道号 Channel ID */
        public Int32 dwStatisticsType;       /* 统计模式 参考# NETDEV_TRAFFIC_STATISTICS_TYPE_E Statistics type */
        public Int32 dwFormType;             /* 统计报表 参考# NETDEV_FORM_TYPE_E Form type */
        public Int64 tBeginTime;             /* 起始时间  Begin time */
        public Int64 tEndTime;               /* 结束时间  End time */
    }

}
