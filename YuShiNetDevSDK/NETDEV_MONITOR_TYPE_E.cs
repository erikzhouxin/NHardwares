namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVMonitorType
     * @brief 布控任务类型
     * @attention 无 None
     */
    public enum NETDEV_MONITOR_TYPE_E
    {
        NETDEV_MONITOR_TYPE_FACE = 0,                /* 人脸 */
        NETDEV_MONITOR_TYPE_VEHICLE = 1,                /* 车牌 */
        NETDEV_MONITOR_TYPE_INVALID = 0xFF              /* 无效值*/
    }

}
