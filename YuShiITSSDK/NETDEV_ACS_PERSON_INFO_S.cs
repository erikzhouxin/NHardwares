using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVACSPersonInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERSON_INFO_S
    {
        public UInt32 udwReqSeq;
        public UInt32 udwPersonID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szName;
        public UInt32 udwGender;
        public NETDEV_FACE_MEMBER_ID_INFO_S stMemberIDInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szTelephone;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szAddress;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_480)]
        public byte[] szDesc;

        public UInt32 udwCardNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_6)]
        public NETDEV_ACS_PERSON_CARD_INFO_S[] stACSPersonCardList;
        public NETDEV_ACS_FACE_IMAGE_S stFaceImage;
        public UInt32 udwType;
        public NETDEV_ACS_STAFF_INFO_S stStaffInfo;
        public NETDEV_ACS_VISITOR_INFO_S stVisitor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
