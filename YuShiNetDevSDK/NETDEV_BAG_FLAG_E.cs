namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVBagFlag
     * @brief 是否携包标志
     * @attention 
     */
    public enum NETDEV_BAG_FLAG_E
    {
        NETDEV_BAG_FLAG_NO = 0,                   /* 未带包 */
        NETDEV_BAG_FLAG_CARRY = 1,                   /* 拎包 */
        NETDEV_BAG_FLAG_BACK = 2,                   /* 背包 */
        NETDEV_BAG_FLAG_INVALID = 0xFF                 /* 无效值 */
    }

}
