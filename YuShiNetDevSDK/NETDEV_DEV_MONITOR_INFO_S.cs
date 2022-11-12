using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVDevMonitorInfo
    * @brief 成员布控设备信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_MONITOR_INFO_S
    {
        public UInt32 udwDevID;               /* 设备ID */
        public UInt32 udwMonitorStatus;       /* 设备布控状态 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字节 */
    }

}
