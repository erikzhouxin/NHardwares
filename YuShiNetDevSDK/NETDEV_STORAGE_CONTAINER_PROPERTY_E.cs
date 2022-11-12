namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_STORAGE_CONTAINER_PROPERTY_E
    {
        NETDEV_STORAGE_CONTAINER_PROPERTY_RW = 0,               /* 读写 */
        NETDEV_STORAGE_CONTAINER_PROPERTY_R = 1,                /* 只读 */
        NETDEV_STORAGE_CONTAINER_PROPERTY_REDUNDANT = 2,        /* 冗余 */

        NETDEV_STORAGE_CONTAINER_PROPERTY_INVALID = 0xFF        /* Invalid value */
    }

}
