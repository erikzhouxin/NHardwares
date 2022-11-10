namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_EXCEPTION_TYPE_E
    {
        /* 回放业务异常上报  Playback exceptions report 300~399 */
        NETDEV_EXCEPTION_REPORT_VOD_END = 300,          /* Playback ended*/
        NETDEV_EXCEPTION_REPORT_VOD_ABEND = 301,          /* Playback exception occured */
        NETDEV_EXCEPTION_REPORT_BACKUP_END = 302,          /* Backup ended */
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT = 303,          /* Disk removed */
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL = 304,          /* Disk full */
        NETDEV_EXCEPTION_REPORT_BACKUP_ABEND = 305,          /* Backup failure caused by other reasons */

        NETDEV_EXCEPTION_EXCHANGE = 0x8000,       /* Exception occurred during user interaction (keep-alive timeout) */

        NETDEV_EXCEPTION_REPORT_INVALID = 0xFFFF        /* Invalid value */
    }

}
