namespace System.Data.YuShiITSSDK
{
    /**
     * @struct NETDEV_DB_OPERATE_E (已废弃)
     * @brief  黑白名单数据库操作, blacklist/whitelist 
     * @attention 
    */
    public enum NETDEV_DB_OPERATE_E
    {
        NETDEV_DB_OPERATE_SELECT = 0,     /**< 查询, No support*/
        NETDEV_DB_OPERATE_ADD,            /**< 增加, add */
        NETDEV_DB_OPERATE_UPDATE,         /**< 修改, modify */
        NETDEV_DB_OPERATE_DELETE          /**< 删除, delete */
    };

}
