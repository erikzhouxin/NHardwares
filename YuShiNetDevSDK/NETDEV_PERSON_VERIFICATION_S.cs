using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVPersonVerification
    * @brief 人员核验
    * @attention 无 None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_VERIFICATION_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public byte[] szReference;                                      /* 用于客户端确认推送消息的url */
        public UInt32 udwSeq;                                                           /* 通知记录序号 */
        public UInt32 udwChannelID;                                                     /* 通道ID VMS支持*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szChannelName;                                    /* 通道名称，长度 [1,64]，VMS支持 */
        public UInt32 udwTimestamp;                                                     /* 通知上报时间 UTC格式，单位秒*/
        public UInt32 udwNotificationType;                                              /* 通知类型 0：实时通知1：历史通知 */
        public UInt32 udwFaceInfoNum;                                                   /* 人脸信息数目 范围：[0, 1] */
        public IntPtr pstCtrlFaceInfo;                               /* 人脸信息 需动态申请内存(NETDEV_CTRL_FACE_INFO_S[])*/
        public UInt32 udwCardInfoNum;                                                   /* 卡信息数目 范围：[0, 1] */
        public IntPtr pstCtrlCardInfo;                               /* 卡信息 需动态申请内存(NETDEV_CTRL_CARD_INFO_S[])*/
        public UInt32 udwGateInfoNum;                                                   /* 闸机信息数目 范围：[0, 1] */
        public IntPtr pstCtrlGateInfo;                               /* 闸机信息 需动态申请内存(NETDEV_CTRL_GATE_INFO_S[])*/
        public UInt32 udwLibMatInfoNum;                                                 /* 库比对信息数目 范围：[0, 16] */
        public IntPtr pstLibMatchInfo;                          /* 库比对信息 需动态申请内存(NETDEV_CTRL_LIB_MATCH_INFO_S[])*/
        public UInt32 udwTemperatureInfoNum;                    /* 温度信息数目 */
        public IntPtr pstTemperatureInfo;                       /* 温度信息列表，需动态申请内存，NETDEV_CTRL_TEMPERATURE_INFO */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        public byte[] byRes;                                                       /* 保留字节 */
    }

}
