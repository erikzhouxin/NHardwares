namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagSDKCarPortControlLed
     * @brief SDK车位内置指示灯控制
     * @attention
     */
    public struct NETDEV_CARPORT_CONTROLLED_S
    {
        public Int32 ulControlMode;                       /**< 0 - 智能控制，1 - SDK控制 */
        public NETDEV_IVA_LED_INFO_S stCurrLEDCfg;        /**< 当前实际车位灯配置 */
    }

}
