using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmLogResultInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_ALARM_LOG_RESULT_INFO_S
    {
        public UInt32 udwTotal;
        public UInt32 udwOffset;
        public UInt32 udwNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                   /* Reserved */
    }

}
