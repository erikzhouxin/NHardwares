using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVPersonInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_INFO_S
    {
        public UInt32 udwPersonID;
        public UInt32 udwLastChange;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szPersonName;
        public UInt32 udwGender;                           /* See #NETDEV_GENDER_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szBirthday;           /* YYYYMMDD */
        public NETDEV_REGION_INFO_S stRegionInfo;
        public UInt32 udwTimeTemplateNum;
        public IntPtr pstTimeTemplateList;
        public UInt32 udwIdentificationNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8)]
        public NETDEV_IDENTIFICATION_INFO_S[] stIdentificationInfo;
        public UInt32 udwImageNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8)]
        public NETDEV_IMAGE_INFO_S[] stImageInfo;
        public UInt32 udwReqSeq;
        public Int32 bIsMonitored;
        public UInt32 udwBelongLibNum;
        public IntPtr pudwBelongLibList;
        public UInt32 udwCustomNum;
        public IntPtr pstCustomValueList;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szTelephone;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szAddress;
        public UInt32 udwCardNum;
        public UInt32 udwFingerprintNum;
        public UInt32 udwType;
        public NETDEV_STAFF_INFO_S stStaff;
        public NETDEV_VISITOR_INFO_S stVisitor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_480)]
        public byte[] szDesc;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public string szPersonCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public byte[] szRemarks;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 176)]
        public byte[] byRes;
    }

}
