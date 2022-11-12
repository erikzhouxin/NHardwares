using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVFacePassRecordInfo
    * @brief 人脸 通过记录信息
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_PASS_RECORD_INFO_S
    {
        public UInt32 udwRecordID;                        /* 人脸通行记录ID */
        public UInt32 udwType;                            /* 人脸通行类型，参见枚举NETDEV_FACE_PASS_RECORD_TYPE_E */
        public Int64 tPassingTime;                       /* 过人时间，UTC格式，单位秒 */
        public UInt32 udwChannelID;                       /* 通道ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public byte[] szChlName;          /* 抓拍通道名称，范围[1,63] */
        public NETDEV_PERSON_COMPARE_INFO_S stCompareInfo;                      /* 比对信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                         /* 保留字段 */
    }

}
