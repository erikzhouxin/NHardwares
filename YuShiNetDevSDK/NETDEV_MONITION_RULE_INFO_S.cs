using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVMonitorRuleInfo
     * @brief 布控任务配置信息 结构体定义 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITION_RULE_INFO_S
    {
        public Int32 bEnabled;                                              /* 布控任务使能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MONITOR_RULE_NAME_LEN)]
        public byte[] szName;             /* 布控任务的布控名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MONITOR_RULE_REASON_LEN)]
        public byte[] szReason;         /* 布控的布控原因 */
        public UInt32 udwLibNum;                                             /* 任务对应的库数量,最大16个 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public UInt32[] audwLibList;                            /* 库ID列表 */
        public UInt32 udwMonitorType;                                        /* 布控告警类型，0：匹配告警,1：不匹配告警 */
        public UInt32 udwMultipleValue;                                      /* 人脸1：N比较置信度阀值 */
        public UInt32 udwMonitorReason;                                      /*  车辆布控原因：0：被抢车 1：被盗车 2：嫌疑车 3：交通违法车 4：紧急查控车*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_512)]
        public byte[] szMatchSucceedMsg;                     /* 比对成功提示语 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_512)]
        public byte[] szMatchFailedMsg;                      /* 比对失败提示语 */
        public UInt32 udwMemberNum;                                          /* 成员数量 [0-32] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public NETDEV_MEMBER_INFO_S[] stMemberInfo;                           /* 成员信息列表 */
        public UInt32 udwChannelNum;                                         /* 人脸布控任务的布控通道个数 获取单个布控任务详情时必带 */
        public IntPtr pudwMonitorChlIDList;                                 /* 人脸布控任务的布控通道列表 根据udwChannelNum动态确定 上层申请内存(UINT32*) */
        public UInt32 udwDevNum;                                             /* 布控任务的布控设备个数 最多四个,仅VMS支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_16)]
        public UInt32[] audwMonitorDevIDList;                   /* 布控任务的布控设备列表 根据DevNum动态确定,仅VMS支持*/
        public UInt32 udwMonitorRuleType;                       /* 布控任务智能类型，0：本地智能布控,1：前端智能布控 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
        public byte[] byRes;                                            /* 保留字段  Reserved */
    }

}
