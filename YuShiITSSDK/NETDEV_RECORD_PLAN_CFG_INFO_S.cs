using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_PLAN_CFG_INFO_S
    {
        public Int32 bPlanEnable;
        public Int32 bRedundantStorage;
        public NETDEV_RECORD_RULE_S stRecordRule;
        public NETDEV_VIDEO_WEEK_PLAN_S stWeekPlan;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
