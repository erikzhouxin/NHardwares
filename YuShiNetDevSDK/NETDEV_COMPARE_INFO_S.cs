using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVCompareInfo
     * @brief 人脸对比信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_COMPARE_INFO_S
    {
        public NETDEV_FILE_INFO_S stPersonImage;                    /* 人员图片 */
        public NETDEV_FILE_INFO_S stSnapshotImage;                  /* 抓拍图片 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                       /* 保留字段 */
    }

}
