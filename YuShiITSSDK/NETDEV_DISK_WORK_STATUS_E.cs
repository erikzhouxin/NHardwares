namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_DISK_WORK_STATUS_E
    {
        NETDEV_DISK_WORK_STATUS_EMPTY = 0,            /* Empty */
        NETDEV_DISK_WORK_STATUS_UNFORMAT = 1,            /* Unformat */
        NETDEV_DISK_WORK_STATUS_FORMATING = 2,            /* Formating */
        NETDEV_DISK_WORK_STATUS_RUNNING = 3,            /* Running */
        NETDEV_DISK_WORK_STATUS_HIBERNATE = 4,            /* Hibernate */
        NETDEV_DISK_WORK_STATUS_ABNORMAL = 5,            /* Abnormal */
        NETDEV_DISK_WORK_STATUS_UNKNOWN = 6,            /* Unknown */

        NETDEV_DISK_WORK_STATUS_INVALID                     /* Invalid value */
    }

}
