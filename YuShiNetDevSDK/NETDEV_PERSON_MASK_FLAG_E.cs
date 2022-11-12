namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVPersonMaskFlag
     * @brief 是否戴口罩
     * @attention 
     */
    public enum NETDEV_PERSON_MASK_FLAG_E
    {
        NETDEV_PERSON_MASK_FLAG_NOT_WEAR = 1,                 /* 不戴 */
        NETDEV_PERSON_MASK_FLAG_WEAR = 2,                 /* 戴 */
        NETDEV_PERSON_MASK_FLAG_UNKNOW = 255,               /* 未知 */
        NETDEV_PERSON_MASK_FLAG_INVALID = 0xFFFF             /* 无效值 */
    }

}
