using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVMonitorDefenceInfo
     * @brief 布防信息 结构体定义
     * @attention 仅PTS VMS使用
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_DEFENCE_INFO_S
    {
        public Int64 tBegin;                  /* 时间模板生效起始时间(unix时间戳) */
        public Int64 tEnd;                    /* 时间模板生效结束时间(unix时间戳) */
        public UInt32 udwTimeTemplateID;       /* 时间模板索引，若未配置，则填写0 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字段 */
    }

}
