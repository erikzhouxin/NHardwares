using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tafNETDEVCtrlCardInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CTRL_CARD_INFO_S
    {
        public UInt32 udwID;
        public UInt32 udwTimestamp;
        public UInt32 udwCapSrc;
        public UInt32 udwCardType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szCardID;
        public UInt32 udwCardStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szName;
        public UInt32 udwGender;
        public UInt32 udwEthnicity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szBirthday;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public byte[] szResidentialAddress;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szIdentityNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public byte[] szIssuingAuthority;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szIssuingDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szValidDateStart;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szValidDateEnd;
        public NETDEV_FILE_INFO_S stIDImage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
