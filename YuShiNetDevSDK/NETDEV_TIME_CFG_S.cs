using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_CFG_S
    {
        public NETDEV_TIME_ZONE_E dwTimeZone;             /* see NETDEV_TIME_ZONE_E */
        public NETDEV_TIME_S stTime;                 /* Time */
        public Int32 bEnableDST;             /* 夏令时使能 DST enable */
        public NETDEV_TIME_DST_CFG_S stTimeDSTCfg;           /* 夏令时配置 DST time config*/
        public UInt32 udwDateFormat;          /* 日期格式 0：YYYY-MM-DD 年月日 1：MM-DD-YYYY 月日年 2：DD-MM-YYYY 日月年*/
        public UInt32 udwHourFormat;          /* 时间格式 0 ：12小时制  1:24 小时制*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 212)]
        public byte[] byRes;                  /* Reserved */
    };

}
