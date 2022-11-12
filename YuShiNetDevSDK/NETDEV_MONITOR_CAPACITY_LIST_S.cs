using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVMonitorCapacityList
    * @brief 容量布控操作列表结构体定义
    * @attention 无None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MONITOR_CAPACITY_LIST_S
    {
        public UInt32 udwDevNum;              /* 设备数量 */
        public IntPtr pstDevCapacityList;     /* 容量列表 根据DevNum动态申请（参见NETDEV_DEV_CAPACITY_INFO_S） */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
