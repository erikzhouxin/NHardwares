namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_RADER_MODE_E
    * @brief 雷达 工作模式
    * @attention 无 None
    */
    public enum NETDEV_ITS_RADER_MODE_E
    {
        NETDEV_ITS_RADAR_MODE_CONTINUOUS = 0,             /**< 连续模式 */
        NETDEV_ITS_RADER_MODE_FRONT_TRIGGER = 1,             /**< 车头触发模式 */
        NETDEV_ITS_RADER_MODE_REAR_TRIGGER = 2,             /**< 车尾触发模式 */
        NETDEV_ITS_RADER_MODE_DOUBLE_TRIGGER = 3,             /**< 双触发模式 */
        NETDEV_ITS_RADER_MODE_INVALID = 0xFFFF          /* 无效值  Invalid value */
    }

}
