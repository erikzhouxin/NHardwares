using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVMonitorCapacityInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_CAPACITY_INFO_S
    {
        public UInt32 udwMonitorType;
        public UInt32 udwNum;
        public IntPtr pudwDevIDList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /*Reserved */
    }

}
