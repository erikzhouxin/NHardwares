using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVTimeDuration
     * @brief 
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DURATION_S
    {
        public Int64 tBeginTime;
        public Int64 tEndTime;
        public Int32 dwPlanType;                              /*See #NETDEV_TIME_TEMPLATE_PLAN_TYPE_E */
    }

}
