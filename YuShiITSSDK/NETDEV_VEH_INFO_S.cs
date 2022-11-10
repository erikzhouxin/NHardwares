using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVVehicleInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEH_INFO_S
    {
        public UInt32 udwID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;
        public UInt32 udwSmallPicAttachIndex;
        public UInt32 udwLargePicAttachIndex;
        public UInt32 udwPlatePicAttachIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szFeatureVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[] szFeature;
        public NETDEV_VEH_ATTR_S stVehAttr;
        public NETDEV_PLATE_ATTR_S stPlateAttr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
