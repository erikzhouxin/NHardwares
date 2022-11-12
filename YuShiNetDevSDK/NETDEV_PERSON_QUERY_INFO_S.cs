using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVPersonQueryInfo
     * @brief 人员信息查询条件
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_QUERY_INFO_S
    {
        public UInt32 udwNum;             /* 查询条件数量 */
        public IntPtr pstQueryInfos;      /* 查询条件列表，Num为0时，不带此字段（参见NETDEV_QUERY_INFO_S）*/
        public UInt32 udwLimit;           /* 每次查询的数量，最大20 */
        public UInt32 udwOffset;          /* 从当前序号开始查询，序号从0开始 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;         /* 保留字段 */
    }

}
