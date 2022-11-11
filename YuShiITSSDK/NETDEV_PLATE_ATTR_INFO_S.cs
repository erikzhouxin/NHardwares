using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagstNETDEVPlateAttrInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLATE_ATTR_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_16)]
        public byte[] szPlateNo;
        public UInt32 udwColor;
        public UInt32 udwType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
    }

}
