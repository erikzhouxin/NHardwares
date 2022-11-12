using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVNonMotorVehicleAttr
     * @brief 非机动车属性信息
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NO_MOTOR_VEH_ATTR_S
    {
        public UInt32 udwSpeedType;                                  /* 结构化场景中非机动车速度类型 详见 NETDEV_SPEED_TYPE_E */
        public UInt32 udwImageDirection;                             /* 结构化场景中非机动车相对画面运动方向 详见 NETDEV_IMAGE_DIRECTION_E */
        public UInt32 udwNonVehicleType;                            /* 非机动车类型 详见 NETDEV_NON_VEH_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                    /* 保留字段 */
    }

}
