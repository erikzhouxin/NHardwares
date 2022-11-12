namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVMaskFlag
     * @brief 是否戴口罩
     * @attention 
     */
    public enum NETDEV_MASK_FLAG_E
    {
        NETDEV_MASK_FLAG_UNKNOW = 0,                 /* 未知 */
        NETDEV_MASK_FLAG_NOT_WEAR = 1,                 /* 不戴 */
        NETDEV_MASK_FLAG_WEAR = 2,                 /* 戴 */
        NETDEV_MASK_FLAG_INVALID = 0xFF               /* 无效值 */
    }

}
