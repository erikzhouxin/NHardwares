using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_WEEK_PLAN_S
    {
        public Int32 bEnabled;           /* 布防计划是否使能,仅IPC支持该字段 */
        public Int32 udwDayNum;           /* 计划天数,NVR最大为8(一周七天和假日);IPC最大为7(一周七天) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_DAY_NUM)]
        public NETDEV_VIDEO_DAY_PLAN_S[] astDayPlan;                     /* 一周内每天的布防计划列表*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;              /*   Reserved field*/
    };

}
