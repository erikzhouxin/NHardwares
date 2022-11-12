using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVStructDataInfo
     * @brief 结构化数据信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_DATA_INFO_S
    {
        public NETDEV_OBJECT_INFO_S stObjectInfo;                    /* 目标信息 */
        public UInt32 udwImageNum;                                   /* 图像个数 */
        public IntPtr pstImageInfo;            /* 图像相关信息 需动态申请内存( NETDEV_STRUCT_IMAGE_INFO_S[]) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
