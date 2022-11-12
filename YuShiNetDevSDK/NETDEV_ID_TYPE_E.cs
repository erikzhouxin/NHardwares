namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVCertificateType
    * @brief 证件类型
    * @attention 无 None
    */
    public enum NETDEV_ID_TYPE_E
    {
        NETDEV_CERTIFICATE_TYPE_ID = 0,        /*0:身份证 */
        NETDEV_CERTIFICATE_TYPE_IC = 1,        /* 1:IC卡 */
        NETDEV_CERTIFICATE_TYPE_PASSPORT = 2,        /* 2:护照 */
        NETDEV_CERTIFICATE_TYPE_DRIVING_LICENSE = 3,        /* 3:行驶证 */
        NETDEV_CERTIFICATE_TYPE_OTHER = 99,       /* 99:其他 */
        NETDEV_CERTIFICATE_TYPE_INVALID = 0xFF      /* 无效值 */
    }

}
