namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVPeopleLibType
    * @brief 人员库类型
    * @attention 无 None
    */
    public enum NETDEV_PEOPLE_LIB_TYPE_E
    {
        NETDEV_PEOPLE_LIB_TYPE_DEFAULT = 0,        /* 默认无效值 */
        NETDEV_PEOPLE_LIB_TYPE_BLACKLIST = 1,        /* 黑名单 */
        NETDEV_PEOPLE_LIB_TYPE_STRANGER = 2,        /* 灰名单/陌生人 */
        NETDEV_PEOPLE_LIB_TYPE_STAFF = 3,        /* 员工 */
        NETDEV_PEOPLE_LIB_TYPE_VISITOR = 4,        /* 访客 */
        NETDEV_PEOPLE_LIB_TYPE_INVALID = 0xFF      /* 无效值 */
    }

}
