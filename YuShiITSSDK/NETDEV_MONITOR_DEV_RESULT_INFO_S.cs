using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVMonitorDevResultInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_DEV_RESULT_INFO_S
    {
        public UInt32 udwDevID;
        public NETDEV_BATCH_OPERATOR_LIST_S stMonitorResult;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /*Reserved */
    }

}
