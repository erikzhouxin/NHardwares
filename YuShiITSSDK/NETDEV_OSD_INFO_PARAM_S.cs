using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVOSDInfoParam（已废弃）
     * @brief OSD 叠加内容
     * @attention 无
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_INFO_PARAM_S
    {
        public Int32 ulInfoType;                                   /**< 叠加内容类型，参考: NETDEV_OSD_CONTENT_TYPE_E 等 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] szValue;                                  /**< 自定义 OSD 内容 */
    };

}
