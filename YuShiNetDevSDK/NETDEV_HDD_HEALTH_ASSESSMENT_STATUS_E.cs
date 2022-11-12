namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_E
    {
        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_NORMAL = 0,         /* 健康状态良好 */
        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_PART_DAMAGE = 1,    /* 存在坏扇区 */
        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_FAULT = 2,          /* 故障 */

        NETDEV_HDD_HEALTH_ASSESSMENT_STATUS_INVALID = 0xFF      /* Invalid value */
    }

}
