namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_EVENT_ACTION_TYPE_E
    {
        NETDEV_EVENT_ACTION_TYPE_ADD = 0,                /* 事件动作类型：增加 */
        NETDEV_EVENT_ACTION_TYPE_DELETE = 1,                /* 事件动作类型：删除 */
        NETDEV_EVENT_ACTION_TYPE_MODIFY = 2,                /* 事件动作类型：修改 */
        NETDEV_EVENT_ACTION_TYPE_ONLINE = 3,                /* 事件动作类型：上线 */
        NETDEV_EVENT_ACTION_TYPE_OFFLINE = 4,                /* 事件动作类型：离线 */
        NETDEV_EVENT_ACTION_TYPE_EMAP_ALARM = 5,                /* 事件动作类型：电子地图告警 */

        NETDEV_EVENT_ACTION_TYPE_INVALID = 0xFF              /* 无效值 */
    }

}
