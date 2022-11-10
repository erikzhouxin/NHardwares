using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVMonitorResultInfo
     * @brief  Device information Structure definition
     * @attention  None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_RESULT_INFO_S
    {
        public UInt32 udwChannelNum;
        public IntPtr pstMonitorChlInfos;             /* malloc by caller （参见NETDEV_MONITION_CHL_INFO_S）*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 250)]
        public byte[] byRes;                     /* Reserved */
    }

}
