using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVBatchOperateList
     * @brief 批量操作列表 结构体定义 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATOR_LIST_S
    {
        public UInt32 udwNum;         /* 批量操作数量 */
        public UInt32 udwStatus;      /* 结果状态 */
        public IntPtr pstBatchList;   /* 批量操作信息 最大是2000个,需动态申请（参见 NETDEV_BATCH_OPERATOR_INFO_S ） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* 保留字段  Reserved */
    }

}
