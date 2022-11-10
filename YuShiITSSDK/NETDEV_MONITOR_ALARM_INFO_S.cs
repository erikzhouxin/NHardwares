using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagstNETDEVMonitorAlarmInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_ALARM_INFO_S
    {
        public UInt32 udwMonitorReason;
        public UInt32 udwMonitorAlarmType;
        public UInt32 udwMemberID;
    }

}
