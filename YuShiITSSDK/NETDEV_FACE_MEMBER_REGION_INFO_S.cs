using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceMemberRegionInfo
     * @brief  
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_REGION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szNation;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szProvince;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szCity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                    /* Reserved */

    }

}
