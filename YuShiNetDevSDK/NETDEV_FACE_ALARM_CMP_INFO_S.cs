using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVFaceAlarmCmpInfo
     * @brief 人脸抓拍告警记录比对信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_ALARM_CMP_INFO_S
    {
        public UInt32 udwSimilarity;                            /* 相似度 */
        public NETDEV_FACE_MEMBER_INFO_S stMemberInfo;          /* 人脸库成员信息 */
        public NETDEV_FACE_ALARM_SNAP_IMAGE_S stSnapshotImage;  /* 抓拍图片 */
        public IntPtr pstPersonInfo;                            /* 人脸库成员信息(NVR支持) 查询匹配成功/失败记录携带 需malloc申请内存，参见NETDEV_PERSON_INFO_S */
        public IntPtr pstFaceAttr;                              /* 人脸属性信息，参见NETDEV_FACE_ATTR_S */
        public IntPtr pstPersonAttr;                            /* 关联人员属性信息，参见NETDEV_PERSON_ATTR_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
        public byte[] byRes;                                    /* 保留字段  Reserved */
    }

}
