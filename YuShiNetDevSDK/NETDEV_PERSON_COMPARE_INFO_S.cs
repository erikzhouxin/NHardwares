using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonCompareInfo
    * @brief 人脸 比对信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_COMPARE_INFO_S
    {
        public UInt32 udwSimilarity;                                  /* 相似度 */
        public NETDEV_PERSON_INFO_S stPersonInfo;                                   /* 人脸库成员信息 */
        public NETDEV_FILE_INFO_S stPanoImage;                                    /* 人脸大图  */
        public NETDEV_FILE_INFO_S stFaceImage;                                    /* 人脸小图 */
        public NETDEV_FACE_POSITION_INFO_S stFaceArea;                                     /* 人脸区域坐标 */
        public UInt32 udwCapSrc;                                      /* 采集来源 */
        public UInt32 udwFeatureNum;                                  /* 半结构化特征数目 如果没有半结构化特征，可不带相关字段 PTS必带 */
        public IntPtr pstFeatureInfo;                                 /* 半结构化特征列表 如果没有半结构化特征，可不带相关字段  PTS必带(NETDEV_FEATURE_INFO_S[]) */
        public NETDEV_FACE_ATTR_S stFaceAttr;                         /* 人脸属性信息 */
        public NETDEV_PERSON_ATTR_S stPersonAttr;                     /* 关联人员属性信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 248)]
        public byte[] byRes;                                     /* 保留字段 */
    }

}
