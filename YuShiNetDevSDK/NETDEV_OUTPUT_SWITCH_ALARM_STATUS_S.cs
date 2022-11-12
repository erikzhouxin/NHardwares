using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @brief  输出开关量的逻辑报警状态(手动告警)
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OUTPUT_SWITCH_ALARM_STATUS_S
    {
        public Int32 dwBooleanId;                            /* 开关量编号  Boolean ID */
        public Int32 dwChannelId;                            /* 通道ID,设备本身为0 */
        public Int32 enAlarmStatus;                          /* 输出开关量报警状态 参见#NETDEV_RELAYOUTPUT_STATE_E */
    }

}
