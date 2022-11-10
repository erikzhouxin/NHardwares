using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceMonitorInfo
     * @brief Device information Structure definition
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_INFO_S
    {
        public UInt32 udwID;
        public NETDEV_MONITION_RULE_INFO_S stMonitorRuleInfo;
        public UInt32 udwLinkStrategyNum;
        public IntPtr pstLinkStrategyList;
        public NETDEV_VIDEO_WEEK_PLAN_S stWeekPlan;
        public NETDEV_MONITOR_DEFENCE_INFO_S stMonitorDefenceInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public byte[] byRes;                   /* Reserved */
    }

}
