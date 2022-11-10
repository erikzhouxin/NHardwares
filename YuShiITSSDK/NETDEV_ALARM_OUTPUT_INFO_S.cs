using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief  告警开关量输出信息 结构体定义 Alarm boolean outputs info Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szName;                                           /* 开关量名称  Boolean name */
        public Int32 dwChancelId;                                       /* 通道号 Channel number */
        public Int32 enDefaultStatus;                                   /* 输出开关量默认状态 参见#NETDEV_BOOLEAN_MODE_E Default status of boolean output, see enumeration #NETDEV_BOOLEAN_MODE_E */
        public Int32 dwDurationSec;                                     /* 告警持续时间 单位 S  Alarm duration (s) */
        public Int32 dwOutputNum;                                       /* 告警输出序号 Alarm output serial number */
    }

}
