using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REPORT_INFO_S
    {
        public Int32 dwReportType;       /* 上报类型，参见枚举#NETDEV_REPORT_TYPE_E */
        public NETDEV_ALARM_INFO_V30_S stAlarmInfo;        /* 告警信息，当dwReportType为NETDEV_REPORT_TYPE_ALARM时有效 */
        public NETDEV_EVENT_INFO_S stEventInfo;        /* 事件信息，当dwReportType为NETDEV_REPORT_TYPE_EVENT时有效 */
    };

}
