namespace System.Data.YuShiITSSDK
{
    /**
    * @enum NETDEV_ITS_POLARIZER_TYPE_E
    * @brief 偏振镜状态 
    * @attention 无 None
    */
    public enum NETDEV_ITS_POLARIZER_TYPE_E
    {
        NETDEV_ITS_POLARIZER_TYPE_INUSE = 0,             /**< 正在使用 */
        NETDEV_ITS_POLARIZER_TYPE_UNUSE = 1,             /**< 未使用 */
        NETDEV_ITS_POLARIZER_TYPE_DOWNING = 2,             /**< 正在下降 */
        NETDEV_ITS_POLARIZER_TYPE_UPING = 3,             /**< 正在上升 */
        NETDEV_ITS_POLARIZER_TYPE_UNKNOWN = 4,             /**< 异常 */
        NETDEV_ITS_POLARIZER_TYPE_SWITCHING = 5,             /**< 切换中 */
        NETDEV_ITS_POLARIZER_TYPE_INVALID = 0xFFFF        /* 无效值  Invalid value */
    }

}
