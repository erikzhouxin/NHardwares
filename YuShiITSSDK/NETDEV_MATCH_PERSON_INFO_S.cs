using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVMatchPersonInfo
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_MATCH_PERSON_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szPersonName;
        public UInt32 udwGender;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szCardID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public byte[] szIdentityNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public byte[] szPersonCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
    }

}
