using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_LIST_S
    {
        public Int32 dwSize;                                           /* Number of input alarms */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_ALARM_IN_NUM)]
        public NETDEV_ALARM_INPUT_INFO_S[] astAlarmInputInfo;       /* Configuration information of input alarms */
    }

}
