namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_STORAGE_CONTAINER_STATUS_E
    {
        NETDEV_STORAGE_CONTAINER_STATUS_NO = 0,                 /* 无硬盘/空闲 */
        NETDEV_STORAGE_CONTAINER_STATUS_UNFORMATTED = 1,        /* 未格式化 */
        NETDEV_STORAGE_CONTAINER_STATUS_FORMATTING = 2,         /* 正在格式化 */
        NETDEV_STORAGE_CONTAINER_STATUS_NORMAL = 3,             /* 硬盘状态良好 */
        NETDEV_STORAGE_CONTAINER_STATUS_SLEEP = 4,              /* 休眠 */
        NETDEV_STORAGE_CONTAINER_STATUS_ABNORMAL = 5,           /* 异常 */
        NETDEV_STORAGE_CONTAINER_STATUS_SWITCH = 6,             /* 切换中 */
        NETDEV_STORAGE_CONTAINER_STATUS_UNINSTALLED = 7,        /* 已卸载 */

        NETDEV_STORAGE_CONTAINER_STATUS_INVALID = 0xFF          /* Invalid value */

    }

}
