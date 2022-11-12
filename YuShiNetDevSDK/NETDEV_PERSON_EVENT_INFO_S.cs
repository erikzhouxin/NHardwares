using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonEventInfo
    * @brief 人员报警信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_EVENT_INFO_S
    {
        public UInt32 udwID;                                   /* 通知记录ID */
        public UInt32 udwTimestamp;                            /* 通知上报时间 UTC格式，单位秒*/
        public UInt32 udwNotificationType;                     /* 通知类型 0：实时通知1：历史通知 */
        public UInt32 udwFaceInfoNum;                          /* 人脸信息数目 范围：[0, 1] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_2)]
        public NETDEV_FACE_PASS_RECORD_INFO_S[] stCtrlFaceInfo;            /* 人脸信息列表，当采集信息没有人脸时，可不带FaceInfo相关字段 */
        public UInt32 udwFinishFaceNum;                        /* 人脸结束数量 范围：[0, 40] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_40)]
        public UInt32[] audwFinishFaceList;       /* 人脸结束列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 92)]
        public byte[] byRes;                               /* 保留字段 */
    }

}
