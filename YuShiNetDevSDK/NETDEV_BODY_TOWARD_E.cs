namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVBodyToward
     * @brief 身体抓拍朝向
     * @attention 
     */
    public enum NETDEV_BODY_TOWARD_E
    {
        NETDEV_BODY_TOWARD_UNKNOW = 0,                 /* 未知 */
        NETDEV_BODY_TOWARD_POSITIVE = 1,                 /* 正面 */
        NETDEV_BODY_TOWARD_SIDE = 2,                 /* 侧面 */
        NETDEV_BODY_TOWARD_BACK = 3,                 /* 背面 */
        NETDEV_BODY_TOWARD_INVALID = 0xFF               /* 无效值 */
    }

}
