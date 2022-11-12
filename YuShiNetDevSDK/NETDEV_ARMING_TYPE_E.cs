namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_ARMING_TYPE_E
    {
        NETDEV_ARMING_TYPE_TIMING = 0,        /* 定时 */
        NETDEV_ARMING_TYPE_MOTIONDETEC = 1,        /* 动检 */
        NETDEV_ARMING_TYPE_ALARM = 2,        /* 报警 */
        NETDEV_ARMING_TYPE_MOTIONDETEC_AND_ALARM = 3,        /* 动检和报警 */
        NETDEV_ARMING_TYPE_MOTIONDETEC_OR_ALARM = 4,        /* 动检或报警 */
        NETDEV_ARMING_TYPE_NO_PLAN = 5,        /* 无计划 */
        NETDEV_ARMING_TYPE_EVENT = 10        /* 事件 */
    }

}
