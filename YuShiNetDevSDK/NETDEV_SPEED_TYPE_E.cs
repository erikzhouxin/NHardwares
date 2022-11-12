namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVSpeedType
     * @brief 结构化场景中非机动车速度类型
     * @attention 
     */
    public enum NETDEV_SPEED_TYPE_E
    {
        NETDEV_SPEED_TYPE_UNKNOW = 0,                   /* 未知 */
        NETDEV_SPEED_TYPE_STATIC = 1,                   /* 静止 */
        NETDEV_SPEED_TYPE_SLOW = 2,                   /* 慢速 */
        NETDEV_SPEED_TYPE_MEDIUM = 3,                   /* 中速 */
        NETDEV_SPEED_TYPE_FAST = 4,                   /* 快速 */
        NETDEV_SPEED_TYPE_INVALID = 0xFF                 /* 无效值 */
    }

}
