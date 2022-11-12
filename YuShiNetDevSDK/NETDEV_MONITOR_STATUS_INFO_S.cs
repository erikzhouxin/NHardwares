using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_STATUS_INFO_S
    {
        public UInt32 udwDevID;               /* 设备ID */
        public UInt32 udwChlID;               /* 通道ID 仅布控任务到通道时携带 */
        public UInt32 udwMonitorStatus;       /* 布控状态 见 NETDEV_MONITOR_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字节 */
    };

}
