namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVGenderType
     * @brief 成员性别
     * @attention 无 None
     */
    public enum NETDEV_GENDER_TYPE_E
    {
        NETDEV_GENDER_TYPE_UNKNOW = 0,        /* 0-未知的性别 */
        NETDEV_GENDER_TYPE_MAN = 1,        /* 1-男 */
        NETDEV_GENDER_TYPE_WOMAN = 2,        /* 2-女 */
        NETDEV_GENDER_TYPE_UNEXPLAINED = 9,        /* 9-未说明的性别 */
        NETDEV_GENDER_TYPE_INVALID = 0xFF      /* 无效值 */
    }

}
