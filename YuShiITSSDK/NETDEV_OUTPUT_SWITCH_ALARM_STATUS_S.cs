using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief  
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OUTPUT_SWITCH_ALARM_STATUS_S
    {
        public Int32 dwBooleanId;                            /* Boolean ID */
        public Int32 dwChannelId;                            /* 0 */
        public Int32 enAlarmStatus;                          /* See#NETDEV_RELAYOUTPUT_STATE_E */
    }

}
