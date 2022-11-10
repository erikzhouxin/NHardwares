using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVTimeDurationList
     * @brief 
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_DURATION_LIST_S
    {
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_TIME_DURATION_NUM)]
        public NETDEV_TIME_DURATION_S[] astTimeDurationList;
    }

}
