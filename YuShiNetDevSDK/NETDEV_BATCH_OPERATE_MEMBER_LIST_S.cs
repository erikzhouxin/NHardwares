using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVBatchOperateMemberList
     * @brief 批量操作成员列表 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_BATCH_OPERATE_MEMBER_LIST_S
    {
        public UInt32 udwTaskNo;             /* 操作任务号，仅NVR支持 */
        public UInt32 udwMemberNum;          /* 成员数量 */
        public IntPtr pstMemberIDList;       /* 成员列表 根据udwNum进行动态申请(UINT32*) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */

    }

}
