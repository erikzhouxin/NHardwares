using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVTimeRange
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_RANGE_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_TIME_RANGE_NUM)]
        public NETDEV_TIME_DURATION_LIST_S[] astTimeRangeList;
    }

}
