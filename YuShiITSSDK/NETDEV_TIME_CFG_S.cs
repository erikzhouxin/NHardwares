using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_CFG_S
    {
        public NETDEV_TIME_ZONE_E dwTimeZone;                      /* see NETDEV_TIME_ZONE_E */
        public NETDEV_TIME_S stTime;                               /* Time */
        public Int32 bEnableDST;             /* DST enable */
        public NETDEV_TIME_DST_CFG_S stTimeDSTCfg;           /* DST time config*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 220)]
        public byte[] byRes;                                       /* Reserved */
    };

}
