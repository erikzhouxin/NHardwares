using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVTimeDuration
     * @brief 每天的时间段信息
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DURATION_S
    {
        public Int64 tBeginTime;                              /* 起始时间 */
        public Int64 tEndTime;                                /* 结束时间 */
        public Int32 dwPlanType;                              /* 参见 NETDEV_TIME_TEMPLATE_PLAN_TYPE_E */
    }

}
