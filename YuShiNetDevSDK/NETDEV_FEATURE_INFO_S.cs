using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVFeatureInfo
    * @brief 半结构化特征信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FEATURE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szFeatureVersion;        /* 人脸半结构化特征提取算法版本号 [0, 20] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_FEATURE_SIZE)]
        public byte[] szFeature;    /* 基于人脸提取出来的特征信息 目前加密前512B */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                             /* 保留字节 */
    }

}
