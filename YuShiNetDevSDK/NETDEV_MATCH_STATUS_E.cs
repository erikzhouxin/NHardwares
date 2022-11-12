namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVMatchStatus
    * @brief 匹配状态
    * @attention 无 None
    */
    public enum NETDEV_MATCH_STATUS_E
    {
        NETDEV_MATCH_STATUS_SUCCESS = 1,          /* 核验成功 */
        NETDEV_MATCH_STATUS_FAIL = 2,          /* 核验失败（比对失败) */
        NETDEV_MATCH_STATUS_NO_MONITOR_TIME = 3,          /* 核验失败（对比成功，不在布控时间）*/
        NETDEV_MATCH_STATUS_BASE_MAP_COLLECT_SUCC = 4,          /* 底图采集成功 */
        NETDEV_MATCH_STATUS_BASE_MAP_COLLECT_FAIL = 5,          /* 底图采集失败 */
        NETDEV_MATCH_STATUS_INVALID = 0xff        /* 无效值 Invalid value */
    }

}
