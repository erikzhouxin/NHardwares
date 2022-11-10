using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVDevCapacityInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CAPACITY_INFO_S
    {
        public UInt32 udwDevID;
        public UInt32 udwCapacity;
        public UInt32 udwMonitoredNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* Reserved */
    }

}
