using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVFaceMemberInfo
     * @brief Device information Structure definition
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FACE_MEMBER_INFO_S
    {
        public UInt32 udwReqSeq;
        public UInt32 udwMemberID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_FACE_MEMBER_NAME_LEN)]
        public byte[] szMemberName;
        public UInt32 udwMemberGender;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_FACE_MEMBER_BIRTHDAY_LEN)]
        public string szMemberBirthday;
        public NETDEV_FACE_MEMBER_REGION_INFO_S stMemberRegionInfo;
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;
        public NETDEV_FILE_INFO_S stMemberImageInfo;
        public NETDEV_FILE_INFO_S stMemberSemiInfo;
        public UInt32 udwCustomNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_FACE_MEMBER_CUSTOM_NUM)]
        public NETDEV_CUSTOM_VALUE_S[] stCustomValue;
        public Int32 bIsMonitored;
        public UInt32 udwDBNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public UInt32[] audwDBIDList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                                                 /* Reserved */

    }

}
