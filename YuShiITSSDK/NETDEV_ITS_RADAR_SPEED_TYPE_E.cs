namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_RADAR_SPEED_TYPE_E
    * @brief 雷达 车速格式
    * @attention 无 None
    */
    public enum NETDEV_ITS_RADAR_SPEED_TYPE_E
    {
        NETDEV_ITS_RADAR_SPEED_SINGLE_BYTE = 0,             /**< 单字节 */
        NETDEV_ITS_RADAR_SPEED_DOUBLE_BYTE = 1,             /**< 双字节 */
        NETDEV_ITS_RADAR_SPEED_ASCII_FORMAT = 2,             /**< ASCII 格式 */
        NETDEV_ITS_RADAR_SPEED_INVALID = 0xFFFF      /* 无效值  Invalid value */
    }

}
