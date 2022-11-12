using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVVehicleMemberAttr
     * @brief 车辆信息(不能增加预留，会导致NETDEV_VEHICLE_DETAIL_INFO_S预留不够)
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_MEMBER_ATTR_S
    {
        public UInt32 udwColor;                                      /* 车身颜色 详见枚举NETDEV_PLATE_COLOR_E*/
        public NETDEV_FILE_INFO_S stVehicleImage;                    /* 车辆图片 图片加密后大小不超过4M */
    }

}
