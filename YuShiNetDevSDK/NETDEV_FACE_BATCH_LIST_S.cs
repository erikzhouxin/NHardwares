using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceBatchList
     * @brief 人脸识别模块批量操作列表 结构体定义 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_BATCH_LIST_S
    {
        public UInt32 udwNum;         /* 批量操作数量 */
        public IntPtr pstBatchList;   /* 批量操作信息 根据udwNum进行动态申请(NETDEV_FACE_BATCH_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;     /* 保留字段  Reserved */
    }

}
