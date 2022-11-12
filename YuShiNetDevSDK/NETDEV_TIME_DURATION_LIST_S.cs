using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVTimeDurationList
     * @brief 每天的时间段信息列表，一天最多24个时间段
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DURATION_LIST_S
    {
        public Int32 dwSize;                                                      /* 时间段个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_TIME_DURATION_NUM)]
        public NETDEV_TIME_DURATION_S[] astTimeDurationList;               /* 时间段信息列表 */
    }

}
