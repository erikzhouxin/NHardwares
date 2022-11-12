namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVACSVisitStaus
     * @brief 访客状态
     * @attention 无 None
     */
    public enum NETDEV_ACS_VISIT_STATUS_E
    {
        NETDEV_ACS_VISIT_STATUS_SCHEDULE = 0,               /* 预约 */
        NETDEV_ACS_VISIT_STATUS_VISITING = 1,               /* 在访 */
        NETDEV_ACS_VISIT_STATUS_LEAVE = 2,               /* 离访 */
        NETDEV_ACS_VISIT_STATUS_SCHEDULE_CANCEL = 3,               /* 预约取消 */
        NETDEV_ACS_VISIT_STATUS_TIMEOUT = 4,               /* 超时 */

        NETDEV_ACS_VISIT_STATUS_INVALID = 0xFF             /* 无效值 */
    }

}
