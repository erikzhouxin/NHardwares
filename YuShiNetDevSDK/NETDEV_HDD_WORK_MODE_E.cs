namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_HDD_WORK_MODE_E
    {
        NETDEV_HDD_WORK_MODE_COMMON = 0,            /* 普通盘 */
        NETDEV_HDD_WORK_MODE_RAID = 1,              /* 阵列盘 */
        NETDEV_HDD_WORK_MODE_HOT_BACKUP = 2,        /* 热备盘 */

        NETDEV_HDD_WORK_MODE_INVALID = 0xFF         /* Invalid value */
    }

}
