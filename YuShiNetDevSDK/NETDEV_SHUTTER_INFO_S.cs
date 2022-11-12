using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SHUTTER_INFO_S
    {
        public Int32 udwShutterTime;       /* 快门时间 枚举见#NETDEV_SHUTTER_TIME_RANGE_E,快门时间单位  0：微秒 1：秒*/
        public Int32 udwMinShutterTime;    /* 快门时间最小值 MinShutter 枚举见#NETDEV_SHUTTER_TIME_RANGE_E*/
        public Int32 udwMaxShutterTime;    /* 快门时间最大值 MaxShutter 枚举见#NETDEV_SHUTTER_TIME_RANGE_E*/
        public Int32 udwIsEnableSlowShutter;  /* 慢快门使能。非光圈优先模式下可用：0：不使能  1：使能*/
        public Int32 udwSlowestShutter; /* 最慢慢快门,慢快门使能后可用。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
