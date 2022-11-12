using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVOutputSwitchActParamInfo
     * @brief 联动开关量输出
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S
    {
        public UInt32 udwNum;                                                                                 /* 联动的开关量输出个数*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_ALARM_OUT_NUM)]
        public NETDEV_OUTPUT_SWITCH_ALARM_STATUS_S[] astOutputAlarmStatusInfo;        /* 联动的开关量输出列表*/
    }

}
