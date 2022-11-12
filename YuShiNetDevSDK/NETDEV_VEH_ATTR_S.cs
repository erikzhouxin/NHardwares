using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVVehAttr
     * @brief 车辆属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_ATTR_S
    {
        public UInt32 udwType;                                       /* 车辆类型 详见 NETDEV_VEHICLE_TYPE_E */
        public UInt32 udwColor;                                      /* 车身颜色 详见 NETDEV_PLATE_COLOR_E */
        public UInt32 udwSpeedUnit;                                  /* 车辆速度单位 0：公里/每小时 1：英里/每小时 */
        public Single fSpeedValue;                                   /* 车辆速度 */
        public UInt32 udwSpeedType;                                  /* 结构化场景中的机动车车辆速度类型 详见 NETDEV_SPEED_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szVehicleBrand;                 /* 车辆车标编码（自行编码) */
        public UInt32 udwImageDirection;                             /* 结构化场景中的机动车在画面坐标系中的行驶方向 详见 NETDEV_IMAGE_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* 保留字段  Reserved */
    }

}
