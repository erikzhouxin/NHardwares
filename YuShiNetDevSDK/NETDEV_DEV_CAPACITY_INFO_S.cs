using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVDevCapacityInfo
    * @brief 设备容量信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CAPACITY_INFO_S
    {
        public UInt32 udwDevID;               /* 设备ID */
        public UInt32 udwCapacity;            /* 设备布控人脸总数量 */
        public UInt32 udwMonitoredNum;        /* 已布控人脸数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */
    }

}
