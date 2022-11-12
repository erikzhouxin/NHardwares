using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVVehicleInfoList
     * @brief 车辆信息列表 结构体定义 Device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_INFO_LIST_S
    {
        public UInt32 udwVehicleNum;          /* 车辆成员数量 */
        public IntPtr pstMemberInfoList;      /* 车辆成员列表 根据udwNum进行动态申请(参见NETDEV_VEHICLE_DETAIL_INFO_S) */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
