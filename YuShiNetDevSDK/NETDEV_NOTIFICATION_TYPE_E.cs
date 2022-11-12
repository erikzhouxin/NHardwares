namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVNotificationType
    * @brief 通知类型
    * @attention 无 None
    */
    public enum NETDEV_NOTIFICATION_TYPE_E
    {
        NETDEV_NOTIFICATION_TYPE_REALTIME = 0,           /* 实时通知 */
        NETDEV_NOTIFICATION_TYPE_HISTORY = 1,           /* 历史通知 */
        NETDEV_NOTIFICATION_TYPE_EARLYWARN = 2            /* 预警通知 */
    }

}
