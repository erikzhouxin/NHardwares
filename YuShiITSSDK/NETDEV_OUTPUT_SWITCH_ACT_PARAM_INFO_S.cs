using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVOutputSwitchActParamInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_ALARM_OUT_NUM)]
        public NETDEV_OUTPUT_SWITCH_ALARM_STATUS_S[] astOutputAlarmStatusInfo;
    }

}
