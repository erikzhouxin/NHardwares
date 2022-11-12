namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVMoveDirection
     * @brief 人员运动方向
     * @attention 
     */
    public enum NETDEV_MOVE_DIRECTION_E
    {
        NETDEV_MOVE_DIRECTION_STATIC = 1,                   /* 静止 */
        NETDEV_MOVE_DIRECTION_UP = 2,                   /* 向上 */
        NETDEV_MOVE_DIRECTION_DOWN = 3,                   /* 向下 */
        NETDEV_MOVE_DIRECTION_LEFT = 4,                   /* 向左 */
        NETDEV_MOVE_DIRECTION_RIGHT = 5,                   /* 向右 */
        NETDEV_MOVE_DIRECTION_LEFTUP = 6,                   /* 左上 */
        NETDEV_MOVE_DIRECTION_LEFTDOWN = 7,                   /* 左下 */
        NETDEV_MOVE_DIRECTION_RIGHTUP = 8,                   /* 右上 */
        NETDEV_MOVE_DIRECTION_RIGHTDOWN = 9,                   /* 右下 */
        NETDEV_MOVE_DIRECTION_UNKNOW = 255,                 /* 未知 */
        NETDEV_MOVE_DIRECTION_INVALID = 0xFFFF               /* 无效值 */
    }

}
