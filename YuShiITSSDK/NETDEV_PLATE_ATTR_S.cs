using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVPlateAttr
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLATE_ATTR_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public byte[] szPlateNo;
        public UInt32 udwColor;
        public UInt32 udwType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
