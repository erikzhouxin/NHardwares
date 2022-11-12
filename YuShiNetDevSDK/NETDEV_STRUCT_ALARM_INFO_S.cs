using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVStructAlarmInfo
     * @brief 结构化告警上报信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_ALARM_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szReference;                   /* 描述信息 */
        public UInt32 udwTimeStamp;                                  /* 告警时间 从1970年1月1日0点开始的秒数 */
        public UInt32 udwSeq;                                        /* 告警序号 */
        public UInt32 udwSrcID;                                      /* 告警源ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public byte[] szSrcName;                     /* 告警源名称 */
        public UInt32 udwNotificationType;                           /* 通知类型 0：实时通知 1：历史通知 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szDeviceID;                     /* 告警设备ID，国标协议接入时填写国标注册码。长度[1,32] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szRelatedID;                    /* 关联ID，告警和数据关联；或多通道目标数据的关联，同一个相机内全局唯一。长度为15个字符 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
