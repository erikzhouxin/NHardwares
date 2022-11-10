namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_RADER_DIRECTION_MODE_E
    * @brief 雷达 方向过滤模式
    * @attention 无 None
    */
    public enum NETDEV_ITS_RADER_DIRECTION_MODE_E
    {
        NETDEV_ITS_RADAR_DIRECTION_NONE_FILTER = 0,             /**< 不过滤 */
        NETDEV_ITS_RADER_DIRECTION_COME = 1,             /**< 输出来向车速 */
        NETDEV_ITS_RADER_DIRECTION_GONE = 2,             /**< 输出去向车速 */
        NETDEV_ITS_RADER_DIRECTION_INVALID = 0xFFFF      /* 无效值  Invalid value */
    }

}
