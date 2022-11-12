using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagNETDEVFaceMemberRegionInfo
     * @brief 人脸库成员地区信息 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_REGION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szNation;                       /* 国籍 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szProvince;                     /* 省份 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_FACE_MEMBER_REGION_LEN)]
        public byte[] szCity;                         /* 城市 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                                    /* 保留字段  Reserved */

    }

}
