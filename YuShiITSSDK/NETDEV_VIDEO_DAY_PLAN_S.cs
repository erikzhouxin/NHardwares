using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_DAY_PLAN_S
    {
        public Int32 udwIndex;                                                  /* day index */
        public Int32 udwSectionNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_PLAN_NUM_AWEEK)]
        public NETDEV_VIDEO_TIME_SECTION_S[] astTimeSection;
    };

}
