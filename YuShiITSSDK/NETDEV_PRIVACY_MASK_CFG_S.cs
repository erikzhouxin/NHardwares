using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 隐私遮盖配置信息 Privacy mask configuration information
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PRIVACY_MASK_CFG_S
    {
        public Int32 dwSize;                                     /*区域个数 Mask area number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM)]
        public NETDEV_PRIVACY_MASK_AREA_INFO_S[] astArea;  /*遮盖区域参数 Mask area parameters */
    }

}
