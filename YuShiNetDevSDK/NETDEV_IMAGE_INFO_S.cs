using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVImageInfo
    * @brief 人脸图片信息列表
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_INFO_S
    {
        public UInt32 udwFaceID;                   /* 人脸照片ID */
        public NETDEV_FILE_INFO_S stFileInfo;      /* 照片信息 */
        public UInt32 udwModelStatus;              /* 建模状态,详见枚举值: NETDEV_MODEL_STATUS_E  ModelStatus,See NETDEV_MODEL_STATUS_E for details*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                  /* 保留字节 */
    }

}
