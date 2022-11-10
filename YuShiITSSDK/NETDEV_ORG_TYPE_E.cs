namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_ORG_TYPE_E
    {
        NETDEV_ORG_TYPE_GENERAL = 0,            /* 普通组织 */
        NETDEV_ORG_TYPE_CLOUD = 1,            /* 云端组织 */
        NETDEV_ORG_TYPE_VIRTUAL = 2,            /* 逻辑组织 */
        NETDEV_ORG_TYPE_FAVORITES = 3,            /* 收藏夹 */
        NETDEV_ORG_TYPE_DOMAIN = 4,            /* 域名组织 */
        NETDEV_ORG_TYPE_DOORGROUP = 5,            /* 门组 */
        NETDEV_ORG_TYPE_DEPT = 6,            /* 部门组织 */

        NETDEV_ORG_TYPE_INVALID = 0XFF          /* 无效值 */
    }

}
