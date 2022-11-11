using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_WEEK_PLAN_S
    {
        public Int32 bEnabled;
        public Int32 udwDayNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_PLAN_NUM_AWEEK)]
        public NETDEV_VIDEO_DAY_PLAN_S[] astDayPlan;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
