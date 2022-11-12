using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceMonitorInfo
     * @brief 布控任务信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_INFO_S
    {
        public UInt32 udwID;                        /* 人脸布控任务序号 添加布控不再返回该字段 */
        public NETDEV_MONITION_RULE_INFO_S stMonitorRuleInfo;            /* 人脸布控任务配置信息 */
        public UInt32 udwLinkStrategyNum;           /* 告警联动策略数量 */
        public IntPtr pstLinkStrategyList;          /* 告警联动策略配置信息，需动态分配内存（参见NETDEV_LINKAGE_STRATEGY_S）*/
        public NETDEV_VIDEO_WEEK_PLAN_S stWeekPlan;                   /* 人脸布控任务布防计划,仅NVR IPC使用 */
        public NETDEV_MONITOR_DEFENCE_INFO_S stMonitorDefenceInfo;         /* 布防信息，仅PTS VMS使用 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public byte[] byRes;                   /* 保留字段  Reserved */
    }

}
