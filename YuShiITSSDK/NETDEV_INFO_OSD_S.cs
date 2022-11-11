using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct NETDEV_INFO_OSD_S（已废弃）
    * @brief 叠加OSD 参数
    * @attention 无
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_INFO_OSD_S
    {
        public Int32 ulIndex;                                                       /**< 叠加区域ID */
        public Int32 bEnable;                                                        /**< 使能开关 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8)]
        public NETDEV_OSD_INFO_PARAM_S astInfoParam;                          /**< 叠加内容 */
        public NETDEV_RECTANGLE_S stArea;                                            /**< 叠加区域 */
    };

}
