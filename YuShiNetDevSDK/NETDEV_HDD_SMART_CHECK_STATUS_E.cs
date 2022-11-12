namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_HDD_SMART_CHECK_STATUS_E
    {
        NETDEV_HDD_SMART_CHECK_STATUS_NOT = 0,              /* 未检测 */
        NETDEV_HDD_SMART_CHECK_STATUS_IN_PORGRESS = 1,      /* 正在自检 */
        NETDEV_HDD_SMART_CHECK_STATUS_SUCCESS = 2,          /* 自检成功 */
        NETDEV_HDD_SMART_CHECK_STATUS_RECOGNITION_FAIL = 3, /* 硬盘识别失败 */
        NETDEV_HDD_SMART_CHECK_STATUS_FAIL = 4,             /* SMART自检失败 */
        NETDEV_HDD_SMART_CHECK_STATUS_NOT_SUPPORT = 5,      /* 硬盘不支持检测 */

        NETDEV_HDD_SMART_CHECK_STATUS_INVALID = 0xFF        /* Invalid value */
    }

}
