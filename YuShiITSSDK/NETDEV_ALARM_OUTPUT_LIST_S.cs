using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_OUTPUT_LIST_S
    {
        public Int32 dwSize;                                                 /* Number of booleans  */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_ALARM_OUT_NUM)]
        public NETDEV_ALARM_OUTPUT_INFO_S[] astAlarmOutputInfo;           /* Boolean configuration information */
    };

}
