using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVMonitorCapacityList
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_CAPACITY_LIST_S
    {
        public UInt32 udwDevNum;
        public IntPtr pstDevCapacityList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /*Reserved */
    }

}
