namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_RECORD_LOCATION_E
    {
        NETDEV_RECORD_LOCATION_ALL = 0,                /* 存储位置：所有 */
        NETDEV_RECORD_LOCATION_VMS = 1,                /* 存储位置：VMS */
        NETDEV_RECORD_LOCATION_NVR = 2,                /* 存储位置：NVR */
        NETDEV_RECORD_LOCATION_BACKUP = 3,                /* 存储位置：备份 */

        NETDEV_RECORD_LOCATION_INVALID = 0xFF              /* 无效值 */
    }

}
