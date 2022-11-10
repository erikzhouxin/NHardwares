namespace System.Data.YuShiITSSDK
{
    /**
     * @struct NETDEV_OSDSTYLE_CFG_S（已废弃）
     * @brief OSD 叠加样式
     * @attention 无
     */
    public struct NETDEV_OSDSTYLE_CFG_S
    {
        public Int32 ulFontStyle;     /**< 字体形式, 参见: NETDEV_OSD_FONT_STYLE_E 等 */
        public Int32 ulFontSize;      /**< 字体大小, 参见: NETDEV_OSD_FONT_SIZE_E 等 */
        public Int32 ulFontType;      /**< 字体, 暂不支持设置 */
        public Int32 ulColor;
        public Int32 ulAlpha;         /**< 透明度, 参见: NETDEV_OSD_MIN_MARGIN_E 等 */
        public Int32 ulTimeFormat;    /**< 时间格式, 参见: NETDEV_OSD_TIME_FORMAT_E 等 */
        public Int32 ulDateFormat;    /**< 日期格式, 参见: NETDEV_OSD_DATA_FORMAT_E 等 */
    };

}
