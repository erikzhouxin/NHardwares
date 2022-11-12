namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVTimeTemplatePlanType
     * @brief 时间模板计划类型
     */
    public enum NETDEV_TIME_TEMPLATE_PLAN_TYPE_E
    {
        NETDEV_TIME_TEMPLATE_PLAN_COMMON = 0,                /* 常规存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MOTION = 1,                /* 运动检测存储 */
        NETDEV_TIME_TEMPLATE_PLAN_ALARM = 2,                /* 告警存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MOTION_AND_ALARM = 3,                /* 运动检测和告警存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MOTION_OR_ALARM = 4,                /* 运动检测或告警存储 */
        NETDEV_TIME_TEMPLATE_PLAN_MANUL = 5,                /* 手动存储 */
        NETDEV_TIME_TEMPLATE_PLAN_DISCONNECT = 6,                /* 断网报警 */
        NETDEV_TIME_TEMPLATE_PLAN_THIRD_STREAM = 7,                /* 第三流存储 */
        NETDEV_TIME_TEMPLATE_PLAN_VIDEO_LOSS = 8,                /* 视频丢失告警 */
        NETDEV_TIME_TEMPLATE_PLAN_AUDIODETECT = 9,                /* 音频检测 */
        NETDEV_TIME_TEMPLATE_PLAN_EVENT_ALL_ALARM = 10,               /* 事件类型，包涵所有告警类型 */
        NETDEV_TIME_TEMPLATE_PLAN_ALL_RECORD_TYPE = 11,               /* 所有录像类型 */

        NETDEV_TIME_TEMPLATE_PLAN_INVALID = 0xFF              /* 无效值 */
    }

}
