using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DST_CFG_S
    {
        public NETDEV_TIME_DST_S stBeginTime;        /* 夏令时开始时间 参见枚举#NETDEV_TIME_DST_S  DST begin time see enumeration NETDEV_TIME_DST_S */
        public NETDEV_TIME_DST_S stEndTime;          /* 夏令时结束时间 参见枚举#NETDEV_TIME_DST_S  DST end time see enumeration NETDEV_TIME_DST_S */
        public Int32 dwOffsetTime;       /* 夏令时节约时间 参见枚举# NETDEV_DST_OFFSET_TIME  DST saving time see enumeration NETDEV_DST_OFFSET_TIME */
    };

}
