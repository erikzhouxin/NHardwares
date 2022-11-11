using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVACSPersonBaseInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_BASE_INFO_S
    {
        public UInt32 udwPersonID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szName;
        public UInt32 udwGender;
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public byte[] szTelephone;
        public UInt32 udwCardID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szCardNo;
        public UInt32 udwType;
        public NETDEV_ACS_STAFF_INFO_S stStaffInfo;
        public NETDEV_ACS_VISITOR_INFO_S stVisitor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
