namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_DEVICE_STATUS_E
    {
        NETDEV_DEV_STATUS_OFFLINE = 0,                /* 离线 */
        NETDEV_DEV_STATUS_ONLINE = 1,                /* 在线 */
        NETDEV_DEV_STATUS_CONNECTING = 2,                /* 连接中 */

        NETDEV_DEV_STATUS_INVALID = 0XFF              /* 无效值 */
    }

}
