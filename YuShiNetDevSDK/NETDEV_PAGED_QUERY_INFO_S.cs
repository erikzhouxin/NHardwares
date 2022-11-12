using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPagedQueryInfo
    * @brief 查询条件
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PAGED_QUERY_INFO_S
    {
        public UInt32 udwLimit;        /* 每次查询的数量 */
        public UInt32 udwOffset;       /* 从当前序号开始查询 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;      /* 保留字节 */
    }

}
