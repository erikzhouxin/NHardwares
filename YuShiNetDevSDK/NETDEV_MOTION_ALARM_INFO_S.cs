using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
 * @struct tagNETDEVMotionAlarmInfo
 * @brief 
 * @attention  None
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MOTION_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                                                     /* Sensitivity */
        public Int32 dwObjectSize;                                                      /* Objection Size */
        public Int32 dwHistory;                                                         /* History */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_SCREEN_INFO_ROW)]
        public NETDEV_Int16Array[] awScreenInfo;    /* Screen Info */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                            /* Reserved */
    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    public struct NETDEV_MOTION_ALARM_INFO_S
    //{
    //    public Int32  dwSensitivity;                                                     /* Sensitivity */
    //    public Int32  dwObjectSize;                                                      /* Objection Size */
    //    public Int32  dwHistory;                                                         /* History */
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_SCREEN_INFO_ROW)]
    //    public array[] awScreenInfo;                                                       /* Screen Info */
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
    //    public byte[] byRes;                                                             /* Reserved */
    //};

}
