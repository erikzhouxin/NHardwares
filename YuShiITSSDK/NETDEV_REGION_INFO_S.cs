using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVRegionInfo
    * @brief 
    * @attention  None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_REGION_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public byte[] szNation;          /* [1-63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public byte[] szProvince;        /* [1-63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_128)]
        public byte[] szCity;            /* [1-63] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
