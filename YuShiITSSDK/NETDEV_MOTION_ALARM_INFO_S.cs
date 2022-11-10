using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @brief 运动检测分析信息 Motion detection analysis info
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MOTION_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                                                     /* 灵敏度 Sensitivity */
        public Int32 dwObjectSize;                                                      /* 物体大小 Objection Size */
        public Int32 dwHistory;                                                         /* 持续时间 History */
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = NETDEVSDK.NETDEV_SCREEN_INFO_ROW)]
        public NETDEV_SCREENINFO_COLUMN_S[] awScreenInfo;   /* 屏幕宏块信息 Screen Info */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;                            /* 保留字段 Reserved */
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
