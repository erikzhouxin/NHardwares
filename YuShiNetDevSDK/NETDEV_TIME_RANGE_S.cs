using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVTimeRange
     * @brief 时间范围信息，一个时间模板最多可包含8个时间范围，周一到周日和假日
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_RANGE_S
    {
        public Int32 dwSize;                                         /* 时间范围个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TIME_RANGE_NUM)]
        public NETDEV_TIME_DURATION_LIST_S[] astTimeRangeList;        /* 时间范围列表 */
    }

}
