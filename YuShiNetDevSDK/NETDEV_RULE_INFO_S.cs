using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVRuleInfo
     * @brief 规则信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RULE_INFO_S
    {
        public UInt32 udwRuleType;        /* 规则类型 参见 NETDEV_RULE_TYPE_E */
        public UInt32 udwTrigerType;      /* 规则触发类型 参见 NETDEV_RULE_TRIGGER_TYPE_E */
        public UInt32 udwPointNum;        /* 规则坐标点数量 */
        public IntPtr pstPointInfo;       /* 检测区域图形各顶点坐标,在顶点个数为0时，这个节点可以没有,NETDEV_POINT_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] byRes;              /* 保留字段 */
    };

}
