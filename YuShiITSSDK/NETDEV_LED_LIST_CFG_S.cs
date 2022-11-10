namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVLed
     * @brief     出入口设备Led屏显示配置
     * @attention
     */
    public struct NETDEV_LED_LIST_CFG_S
    {
        public Int32 dwPlateShowTime;                     /*屏显示车牌时长，单位：S，0-1000*/
        public Int32 dwSceneNum;                          /*配置屏数量，当前支持数量：1 */
        public NETDEV_LED_CFG_S stuLedLineInfo;
    }

}
