namespace System.Data.YuShiITSSDK
{
    /**
    * @enum NETDEV_STATUS_PORT_TYPE_E
    * @brief NETDEV_STATUS_PORT_TYPE_E
    * @attention 无 None
    */
    public enum NETDEV_STATUS_PORT_TYPE_E
    {
        NETDEV_STATUS_PORT_TYPE_LOCAL = 0,            /* 本地监听端口 */
        NETDEV_STATUS_PORT_TYPE_NAT = 1,               /* 端口映射后的事件端口 */
        NETDEV_STATUS_PORT_TYPE_INVALID = 0xFFFF        /* 无效值  Invalid value */
    }

}
