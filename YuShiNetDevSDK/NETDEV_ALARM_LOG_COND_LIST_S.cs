using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVAlarmLogCondList
     * @brief 告警日志所有查询条件
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_LOG_COND_LIST_S
    {
        public Int32 dwPageRow;                                                      /* 每页最大条数 */
        public Int32 dwFirstRow;                                                     /* 分页查询中第一条数据的序号 */
        public Int32 dwCondSize;                                                     /* 查询条件数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LOG_QUERY_COND_NUM)]
        public NETDEV_QUERY_INFO_S[] astCondition;            /* 查询条件右值 */
    }

}
