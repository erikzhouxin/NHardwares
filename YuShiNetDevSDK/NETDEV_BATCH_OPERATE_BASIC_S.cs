using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVBatchOperateBasicInfo
     * @brief 批量查询返回的基本信息 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATE_BASIC_S
    {
        public UInt32 udwTotal;       /* 数量 */
        public UInt32 udwOffset;      /* 查询起始序号 */
        public UInt32 udwNum;         /*查询结果总数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* 保留字段  Reserved */
    }

}
