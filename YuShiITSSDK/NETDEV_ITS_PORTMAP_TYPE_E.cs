namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_PORTMAP_TYPE_E
    * @brief UPNP端口映射状态改变标志位
    * @attention 无 None
    */
    public enum NETDEV_ITS_PORTMAP_TYPE_E
    {
        NETDEV_ITS_PORTMAP_TYPE_NOCHANGE = 0,                     /**< 改变*/
        NETDEV_ITS_PORTMAP_TYPE_CHANGE = 1,                     /**< 不改变*/
        NETDEV_ITS_PORTMAP_TYPE_INVALID = 0xFFFF                 /* 无效值  Invalid value */
    }

}
