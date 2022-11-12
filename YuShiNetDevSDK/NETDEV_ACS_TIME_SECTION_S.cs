using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagACSTimeSection
     * @brief 时间信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_TIME_SECTION_S
    {
        public Int64 tStartTime;                                      /* 起始时间 UTC时间 单位秒s */
        public Int64 tEndTime;                                        /* 结束时间 UTC时间 单位秒s */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                                       /* 保留字段 */
    }

}
