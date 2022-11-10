namespace System.Data.YuShiITSSDK
{
    /**
    * @enum NETDEV_ITS_LEDSTROBE_TYPE_E
    * @brief LED灯状态  
    * @attention 无 None
    */
    public enum NETDEV_ITS_LEDSTROBE_TYPE_E
    {
        NETDEV_ITS_LED_STROBE_TYPE_ON = 0,               /**< 打开 */
        NETDEV_ITS_LED_STROBE_TYPE_OFF = 1,               /**< 关闭 */
        NETDEV_ITS_LED_STROBER_TYPE_INVALID = 0xFFFF         /* 无效值  Invalid value */
    }

}
