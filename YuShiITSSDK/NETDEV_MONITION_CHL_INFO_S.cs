using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVMonitorChlInfo
     * @brief
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_CHL_INFO_S
    {
        public UInt32 udwChannelID;
        public UInt32 udwResultCode;
        public UInt32 udwMonitorID;
    }

}
