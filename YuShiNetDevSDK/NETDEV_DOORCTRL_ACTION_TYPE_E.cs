namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVAlarmPointActionType
     * @brief 报警点通道控制命令
     * @attention
     */
    public enum NETDEV_DOORCTRL_ACTION_TYPE_E
    {
        NETDEV_DOORCTRL_ACTION_TYPE_OPEN = 0,                /* 开门 */
        NETDEV_DOORCTRL_ACTION_TYPE_CLOSE = 1,                /* 关门 */

        NETDEV_DOORCTRL_ACTION_TYPE_INVALID = 0xFF              /* 无效值 */
    }

}
