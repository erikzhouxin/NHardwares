namespace System.Data.YuShiITSSDK
{
    /**
    * @enum NETDEV_ITS_COIL_STATUS_E
    * @brief 线圈状态
    * @attention 无 None
    */
    public enum NETDEV_ITS_COIL_STATUS_E
    {
        NETDEV_ITS_COIL_STATUS_DISCONNECT = 0,             /**< 线圈断开 */
        NETDEV_ITS_COIL_STATUS_CONNECT = 1,             /**< 线圈连接 */
        NETDEV_ITS_COIL_STATUS_UNUSE = 2,             /**< 线圈未使用 */
        NETDEV_ITS_COIL_STATUS_INVALID = 0xFFFF             /* 无效值  Invalid value */
    }

}
