namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVImageDirection
     * @brief 结构化场景中非机动车相对画面运动方向
     * @attention 
     */

    public enum NETDEV_IMAGE_DIRECTION_E
    {
        NETDEV_IMAGE_DIRECTION_UNKNOW = 0,                   /* 未知 */
        NETDEV_IMAGE_DIRECTION_STATIC = 1,                   /* 静止 */
        NETDEV_IMAGE_DIRECTION_UP = 2,                   /* 向上 */
        NETDEV_IMAGE_DIRECTION_DOWN = 3,                   /* 向下 */
        NETDEV_IMAGE_DIRECTION_LEFT = 4,                   /* 向左 */
        NETDEV_IMAGE_DIRECTION_RIGHT = 5,                   /* 向右 */
        NETDEV_IMAGE_DIRECTION_LEFTUP = 6,                   /* 左上 */
        NETDEV_IMAGE_DIRECTION_LEFTDOWN = 7,                   /* 左下 */
        NETDEV_IMAGE_DIRECTION_RIGHTUP = 8,                   /* 右上 */
        NETDEV_IMAGE_DIRECTION_RIGHTDOWN = 9,                   /* 右下 */
        NETDEV_IMAGE_DIRECTION_INVALID = 0xFF                 /* 无效值 */
    }

}
