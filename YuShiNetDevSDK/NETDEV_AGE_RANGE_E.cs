namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVAgeRange
     * @brief 年龄段
     * @attention 
     */
    public enum NETDEV_AGE_RANGE_E
    {
        NETDEV_AGE_RANGE_UNKNOW = 0,                /* 未知 */
        NETDEV_AGE_RANGE_CHILD = 1,                /* 儿童 */
        NETDEV_AGE_RANGE_JUVENILE = 2,                /* 少年 */
        NETDEV_AGE_RANGE_Youth = 3,                /* 青年 */
        NETDEV_AGE_RANGE_MIDDLEAGE = 4,                /* 中年 */
        NETDEV_AGE_RANGE_OLDAGE = 5,                /* 老年 */
        NETDEV_AGE_RANGE_INVALID = 0xFF              /* 无效年龄段 */
    }

}
