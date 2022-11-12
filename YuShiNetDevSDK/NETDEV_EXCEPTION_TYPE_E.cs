namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_EXCEPTION_TYPE_E
    {
        /* 回放业务异常上报  Playback exceptions report 300~399 */
        NETDEV_EXCEPTION_REPORT_VOD_END = 300,          /* 回放结束  Playback ended*/
        NETDEV_EXCEPTION_REPORT_VOD_ABEND = 301,          /* 回放异常  Playback exception occured */
        NETDEV_EXCEPTION_REPORT_BACKUP_END = 302,          /* 备份结束  Backup ended */
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT = 303,          /* 磁盘被拔出  Disk removed */
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL = 304,          /* 磁盘已满  Disk full */
        NETDEV_EXCEPTION_REPORT_BACKUP_ABEND = 305,          /* 其他原因导致备份失败   Backup failure caused by other reasons */

        NETDEV_EXCEPTION_EXCHANGE = 0x8000,       /* 用户交互时异常（用户保活超时）  Exception occurred during user interaction (keep-alive timeout) */
        NETDEV_EXCEPTION_REPORT_ALARM_INTERRUPT = 0x8001,       /* Alarm report abnormal end ,keep live failure or long connection disconnection*/

        NETDEV_EXCEPTION_REPORT_INVALID = 0xFFFF        /* 无效值  Invalid value */
    }
}
