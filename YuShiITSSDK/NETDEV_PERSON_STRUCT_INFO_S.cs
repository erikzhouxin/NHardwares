using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVPersonStructInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_STRUCT_INFO_S
    {
        public UInt32 udwPersonID;
        public UInt32 udwPersonDoforFaceID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;
        public UInt32 udwSmallPicAttachIndex;
        public UInt32 udwLargePicAttachIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szFeaturVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_1024)]
        public byte[] szFeature;
        public NETDEV_PERSON_ATTR_S stPersonAttr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
