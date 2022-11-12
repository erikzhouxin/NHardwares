using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVFaceRecordSnapshotInfo
     * @brief 人脸识别记录
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_RECORD_SNAPSHOT_INFO_S
    {
        public UInt32 udwRecordID;                                       /* 人脸识别记录ID */
        public UInt32 udwRecordType;                                     /* 人脸识别记录类型 参见# NETDEV_FACE_PASS_RECORD_TYPE_E */
        public UInt32 udwPassTime;                                       /* 过人时间 UTC格式 */
        public UInt32 udwEventType;                                      /* 事件类型 按BIT位进行类型描述，相应BIT为1，表示属于该类型，为0表示不属于该类型。BIT0:人脸抓拍BIT1:人脸匹配告警BIT2:人脸不匹配告警*/
        public UInt32 udwChannelID;                                      /* 通道ID */
        public UInt32 udwMonitorRuleID;                                  /* 告警对应的布控ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szChannelName;                     /* 抓拍通道名称 */
        public NETDEV_FACE_ALARM_CMP_INFO_S stCompareInfo;                /* 比对信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;                                        /* 保留字段  Reserved */
    }

}
