namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_ADDR_TYPE_E
    {
        NETDEV_ADDR_TYPE_IPV4 = 0,              /* IPV4 */
        NETDEV_ADDR_TYPE_IPV6 = 1,              /* IPV6 */
        NETDEV_ADDR_TYPE_DOMAIN = 2,            /* 域名 */
        NETDEV_ADDR_TYPE_IPV4_IPV6 = 3,         /* IPV4和IPV6都需要 */
        NETDEV_ADDR_TYPE_INVALID = 0XFFFF       /* 无效值 */
    }

}
