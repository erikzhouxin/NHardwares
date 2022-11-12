using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagstNETDEVMonitorAlarmInfo
    * @brief 车牌告警布控信息(无法增加预留，会导致NETDEV_VEHICLE_RECORD_INFO_S预留不够)
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_ALARM_INFO_S
    {
        public UInt32 udwMonitorReason;                          /* 布控原因类型 */
        public UInt32 udwMonitorAlarmType;                       /* 布控告警类型 0：匹配告警 1：不匹配告警 */
        public UInt32 udwMemberID;                               /* 车辆成员ID */
    }

}
