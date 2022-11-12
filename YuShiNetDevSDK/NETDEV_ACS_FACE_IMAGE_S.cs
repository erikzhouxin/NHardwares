using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
 * @struct tagNETDEVACSFaceImage
 * @brief 图片信息
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_FACE_IMAGE_S
    {
        public UInt32 udwNum;                            /* 照片数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public NETDEV_FILE_INFO_S[] stImageList;        /* 人脸照片列表 */
        public UInt32 udwMajorImageIndex;                /* 主照片索引 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                        /* 保留字段 */
    }

}
