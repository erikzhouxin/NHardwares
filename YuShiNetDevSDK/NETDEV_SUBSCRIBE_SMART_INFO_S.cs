using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVSubscribeSmartInfo
     * @brief 订阅智能事件信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SUBSCRIBE_SMART_INFO_S
    {
        public UInt32 udwNum;                /* 订阅智能告警数 */
        public IntPtr pudwSmartType;        /* 订阅的智能告警类型 参见枚举 NETDEV_SMART_ALARM_TYPE_E ，根据udwNum动态申请(UINT32*) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
