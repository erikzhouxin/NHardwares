using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
 * @struct tagPrivacyMaskPara
 * @brief  Privacy mask configuration information
 * @attention
 */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_CFG_S
    {
        public Int32 dwSize;                                     /* Mask area number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM)]
        public NETDEV_PRIVACY_MASK_AREA_INFO_S[] astArea;  /* Mask area parameters */
    }

}
