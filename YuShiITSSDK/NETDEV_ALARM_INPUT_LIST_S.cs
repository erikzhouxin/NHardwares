using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief  所有告警开关量输入信息 结构体定义  All Alarm boolean inputs info Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_LIST_S
    {
        public Int32 dwSize;                                           /*输入开关量数量 Number of input alarms */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_MAX_ALARM_IN_NUM)]
        public NETDEV_ALARM_INPUT_INFO_S[] astAlarmInputInfo;          /* 输入开关量配置信息 Configuration information of input alarms */
    }

}
