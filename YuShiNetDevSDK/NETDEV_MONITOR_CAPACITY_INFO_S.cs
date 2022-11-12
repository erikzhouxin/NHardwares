using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVMonitorCapacityInfo
    * @brief 容量布控信息结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_CAPACITY_INFO_S
    {
        public UInt32 udwMonitorType;         /* 布控类型 0：人脸布控   1：车辆布控 */
        public UInt32 udwNum;                 /* 设备数量 */
        public IntPtr pudwDevIDList;         /* 设备ID列表 根据udwNum动态申请(UINT32*)*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;             /* 保留字段  Reserved */
    }

}
