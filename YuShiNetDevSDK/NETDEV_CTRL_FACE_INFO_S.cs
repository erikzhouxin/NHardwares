using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVCtrlFaceInfo
    * @brief 人脸信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_FACE_INFO_S
    {
        public UInt32 udwID;                                           /* 记录ID */
        public UInt32 udwTimestamp;                                    /* 采集时间 UTC格式，单位秒 */
        public UInt32 udwCapSrc;                                       /* 采集来源 详见 NETDEV_CAP_SRC_E FaceInfo选择1 */
        public UInt32 udwFeatureNum;                                   /* 半结构化特征数目 范围：[0, 2] */
        public IntPtr pstFeatureInfo;                 /* 半结构化特征列表 需动态分配内存(NETDEV_FEATURE_INFO_S[]) */
        public NETDEV_FILE_INFO_S stPanoImage;                         /* 人脸全景图 */
        public NETDEV_FILE_INFO_S stFaceImage;                         /* 人脸小图 */
        public NETDEV_FACE_POSITION_INFO_S stFaceArea;                 /* 人脸全景图人脸区域坐标 */
        public float fTemperature;                                    /* 人员体温 单位：摄氏度，注：小数点后1位 */
        public UInt32 udwMaskFlag;                                     /* 是否戴口罩，0：未知或未启用检测；1：未戴口罩；2：戴口罩 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        public byte[] byRes;                                      /* 保留字节 */
    }

}
