using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DST_CFG_S
    {
        public NETDEV_TIME_DST_S stBeginTime;        /* See# NETDEV_TIME_DST_S  DST begin time see enumeration NETDEV_TIME_DST_S */
        public NETDEV_TIME_DST_S stEndTime;          /* See# NETDEV_TIME_DST_S  DST end time see enumeration NETDEV_TIME_DST_S */
        public Int32 dwOffsetTime;       /* See# NETDEV_DST_OFFSET_TIME  DST saving time see enumeration NETDEV_DST_OFFSET_TIME */
    };

}
