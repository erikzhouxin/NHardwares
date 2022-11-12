using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_DAY_PLAN_S
    {
        public Int32 udwIndex;                                                  /* 星期索引  day index */
        public Int32 udwSectionNum;                                             /* 每天时间段个数  Section Num NVR最大为8段,IPC最大为4段 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_TIME_SECTION_NUM)]
        public NETDEV_VIDEO_TIME_SECTION_S[] astTimeSection;                     /* 布防时间段配置 */
    };

}
