using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REPORT_INFO_S
    {
        public Int32 dwReportType;       /* See #NETDEV_REPORT_TYPE_E */
        public NETDEV_ALARM_INFO_V30_S stAlarmInfo;
        public NETDEV_EVENT_INFO_S stEventInfo;
    };

}
