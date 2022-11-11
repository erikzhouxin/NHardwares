using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVAlarmLogCondList
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_LOG_COND_LIST_S
    {
        public Int32 dwPageRow;
        public Int32 dwFirstRow;
        public Int32 dwCondSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LOG_QUERY_COND_NUM)]
        public NETDEV_QUERY_INFO_S[] astCondition;
    }

}
