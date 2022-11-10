namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_CHN_TYPE_E
    {
        NETDEV_CHN_TYPE_ENCODE = 0,                /* 编码通道, 通道状态参见NETDEV_CHN_STATUS_E */
        NETDEV_CHN_TYPE_ALARMIN = 1,                /* 告警输入通道, 通道状态参见NETDEV_ALARM_RUNMODE_E */
        NETDEV_CHN_TYPE_ALARMOUT = 2,                /* 告警输出通道, 通道状态参见NETDEV_ALARMOUT_CHN_STATUS_E */
        NETDEV_CHN_TYPE_DECODE = 3,                /* 解码通道 */
        NETDEV_CHN_TYPE_AUDIO = 4,                /* 音频通道 */
        NETDEV_CHN_TYPE_NIC = 5,                /* 网卡通道 */
        NETDEV_CHN_TYPE_ALARMPOINT = 6,                /* 报警点 */
        NETDEV_CHN_TYPE_DOOR = 7,                /* 门 */
        NETDEV_CHN_TYPE_ADU_ENCODE = 8,                /* ADU本地编码通道, 通道状态参见NETDEV_CHN_STATUS_E */
        NETDEV_CHN_TYPE_EMERGENCY = 9,                /* 紧急铃通道 */

        NETDEV_CHN_TYPE_INVALID = 0xFF              /* 无效值 */
    }

}
