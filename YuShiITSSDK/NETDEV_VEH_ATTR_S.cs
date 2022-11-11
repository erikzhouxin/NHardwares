using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVVehAttr
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_ATTR_S
    {
        public UInt32 udwType;                                       /* See #NETDEV_VEHICLE_TYPE_E */
        public UInt32 udwColor;                                      /* See #NETDEV_PLATE_COLOR_E */
        public UInt32 udwSpeedUnit;
        public Single fSpeedValue;
        public UInt32 udwSpeedType;                                  /* See #NETDEV_SPEED_TYPE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szVehicleBrand;
        public UInt32 udwImageDirection;                             /* See #NETDEV_IMAGE_DIRECTION_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;              /* Reserved */
    }

}
