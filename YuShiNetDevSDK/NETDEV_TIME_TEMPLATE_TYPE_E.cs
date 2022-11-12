namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVTimeTemplateType
     * @brief 时间模板类型
     * @attention 无 None
     */
    public enum NETDEV_TIME_TEMPLATE_TYPE_E
    {
        NETDEV_TIMETEMPLATE_TYPE_RECORD = 0,                /* 录像计划 */
        NETDEV_TIMETEMPLATE_TYPE_ALARM = 1,                /* 告警计划 */
        /* 2和3CS暂不使用，web端使用 2是用户时间模板， 3是微信小程序使用 */
        NETDEV_TIMETEMPLATE_TYPE_SEQUENCE = 4,                /* 轮巡 */
        NETDEV_TIMETEMPLATE_TYPE_ACS = 5,                /* 门禁管理 */
        NETDEV_TIMETEMPLATE_TYPE_INVALID = 0xFF              /* 无效 */
    }

}
