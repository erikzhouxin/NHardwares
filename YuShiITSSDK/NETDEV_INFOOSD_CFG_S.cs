namespace System.Data.YuShiITSSDK
{
    /**
     * @struct NETDEV_INFOOSD_CFG_S（已废弃）
     * @brief  OSD叠加内容
     * @attention 无
     */
    public struct NETDEV_INFOOSD_CFG_S
    {
        public Int32 ulAreaNum;                              /**< 叠加区域个数 */
        public IntPtr astInfoOSD;                /**< 叠加OSD 配置，区域最大个数为: NETDEV_LEN_32, See NETDEV_INFO_OSD_S */
    };

}
