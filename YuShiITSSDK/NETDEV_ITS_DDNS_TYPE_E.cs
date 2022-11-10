namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_DDNS_TYPE_E
    * @brief DDNS域名检测完成
    * @attention 无 None
    */
    public enum NETDEV_ITS_DDNS_TYPE_E
    {
        NETDEV_ITS_DDNS_TYPE_NOCHANGE = 0,                        /**< 改变*/
        NETDEV_ITS_DDNS_TYPE_CHANGE = 1,                        /**< 不改变*/
        NETDEV_ITS_DDNS_TYPE_INVALID = 0xFFFF                    /* 无效值  Invalid value */
    }

}
