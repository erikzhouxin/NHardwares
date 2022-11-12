namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVNonVehType
     * @brief 非机动车类型
     * @attention 
     */
    public enum NETDEV_NON_VEH_TYPE_E
    {
        NETDEV_NON_VEH_TYPE_UNKNOW = 0,                   /* 未知 */
        NETDEV_NON_VEH_TYPE_BICYCLE = 1,                   /* 人力自行车 */
        NETDEV_NON_VEH_TYPE_TRIYCLE = 2,                   /* 三轮车 */
        NETDEV_NON_VEH_TYPE_MOTORCYCLE = 3,                   /* 摩托车 */
        NETDEV_NON_VEH_TYPE_ELECTRIC_BICYCLE = 4,                   /* 电动自行车 */
        NETDEV_NON_VEH_TYPE_TWOWHEEL_VEHICLE = 5,                   /* 二轮车（摩托车/人力自行车/电动自行车) */
        NETDEV_NON_VEH_TYPE_INVALID = 0xFF                 /* 无效值 */
    }

}
