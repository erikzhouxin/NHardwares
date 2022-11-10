namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagMwIVALEDInfo
     * @brief   车位灯信息
     * @attention 
     */
    public struct NETDEV_IVA_LED_INFO_S
    {
        public Int32 ulLEDStatus;                         /**< 指示灯状态，0-熄灭，1-长亮，2-闪烁 */
        public Int32 ulLEDColour;                         /**< 指示灯颜色, 1-红色，2-黄色，3-绿色*/
    }

}
