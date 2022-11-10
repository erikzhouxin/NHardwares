using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVMonitorDefenceInfo
     * @brief 
     * @attention 
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_DEFENCE_INFO_S
    {
        public Int64 tBegin;
        public Int64 tEnd;
        public UInt32 udwTimeTemplateID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
