using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceStructInfo
     * @brief 人脸信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_STRUCT_INFO_S
    {
        public UInt32 udwFaceID;                                     /* 人脸ID */
        public UInt32 udwFaceDoforPersonID;                          /* 人脸所属人员ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szPosition;                     /* 人脸位置信息 */
        public UInt32 udwSmallPicAttachIndex;                        /* 人脸对应的小图在图像列表中的索引 */
        public UInt32 udwLargePicAttachIndex;                        /* 人脸对应的大图在图像列表中的索引 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szFeaturVersion;                /* 半结构化特征厂商类型版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_1024)]
        public byte[] szFeature;                    /* 基于人脸提取出来的特征信息 采用base64编码 前加密前512 Bytes */
        public NETDEV_FACE_ATTR_S stFaceAttr;                        /* 人脸属性信息 */
        public IntPtr pstRuleInfo;                                   /* 规则信息 需动态申请内存,NETDEV_RULE_INFO_S */
        public UInt32 udwFaceDoforNonMotorID;                        /* 人脸所属非机动车ID */
        public UInt32 udwFaceDoforVehicleID;                         /* 人脸所属机动车ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
