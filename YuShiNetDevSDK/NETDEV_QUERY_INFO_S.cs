using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVAlarmLogCond
     * @brief 告警日志查询条件
     * @attention  查询“告警类型”时，携带的告警主类型或子类型数量均不能超过16个。
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_QUERY_INFO_S
    {
        public Int32 dwQueryType;                                /* 查询条件类型，参见# NETDEV_QUERYCOND_TYPE_E */
        public Int32 dwLogicFlag;                                /* 查询条件逻辑类型，参见#NETDEV_QUERYCOND_LOGICTYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_CODE_STR_MAX_LEN)]
        public byte[] szConditionData;   /* 查询条件右值 */
    }

}
