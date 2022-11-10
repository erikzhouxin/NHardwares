namespace System.Data.YuShiITSSDK
{
    /**
    * @enum NETDEV_ITS_SDSTATUS_TYPE_E
    * @brief SD卡状态类型
    * @attention 无 None
    */
    public enum NETDEV_ITS_SDSTATUS_TYPE_E
    {
        NETDEV_ITS_SD_TYPE_NOEXIS = 0,            /**< 不存在 */
        NETDEV_ITS_SD_TYPE_FAUL = 1,             /**< 故障 */
        NETDEV_ITS_SD_TYPE_CHECKING = 2,             /**< 检测中 */
        NETDEV_ITS_SD_TYPE_NORMAL = 3,            /**< 正常 */
        NETDEV_ITS_SD_TYPE_EXIST = 4,            /**< 设备存在 */
        NETDEV_ITS_SD_TYPE_INVALID = 0xFFFF        /* 无效值  Invalid value */
    }

}
