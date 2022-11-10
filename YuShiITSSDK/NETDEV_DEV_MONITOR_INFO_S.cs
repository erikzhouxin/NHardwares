using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVDevMonitorInfo
    * @brief
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_MONITOR_INFO_S
    {
        public UInt32 udwDevID;
        public UInt32 udwMonitorStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
    }

}
