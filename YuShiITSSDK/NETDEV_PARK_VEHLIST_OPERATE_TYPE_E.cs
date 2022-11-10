namespace System.Data.YuShiITSSDK
{
    /**
     * @struct NETDEV_PARK_VEHLIST_OPERATE_TYPE_E
     * @brief 黑白名单数据库操作
     * @attention 无
     */
    public enum NETDEV_PARK_VEHLIST_OPERATE_TYPE_E
    {
        NETDEV_PARK_VEHLIST_OPERATE_SELECT = 0,         /**< 查询, No support */
        NETDEV_PARK_VEHLIST_OPERATE_ADD = 1,         /**< 增加, add */
        NETDEV_PARK_VEHLIST_OPERATE_UPDATE = 2,         /**< 修改, modify */
        NETDEV_PARK_VEHLIST_OPERATE_DELETE = 3,         /**< 删除, delete */
        NETDEV_PARK_VEHLIST_OPERATE_INVALID = 0xFFFF     /**< 无效值  Invalid value */
    };

}
