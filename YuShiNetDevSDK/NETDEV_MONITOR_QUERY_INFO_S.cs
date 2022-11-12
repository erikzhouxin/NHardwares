using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVMonitorQueryInfo
     * @brief 布控信息查询条件
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_QUERY_INFO_S
    {
        public UInt32 udwLimit;           /* 每次查询的数量，最大20 */
        public UInt32 udwOffset;          /* 从当前序号开始查询，序号从0开始 */
        public Int32 bIsQueryAll;        /* 是否查询所有，是:TRUE,否:FALSE */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;         /* 保留字段 */
    }

}
