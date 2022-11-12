namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_MODEL_STATUS_E
    {
        NETDEV_MODEL_STATUS_TYPE_UNMODELED = 0,        /*0:未建模 */
        NETDEV_MODEL_STATUS_TYPE_SUCCEED = 1,        /* 1:已建模 */
        NETDEV_MODEL_STATUS_TYPE_FAILED = 2,        /* 2:建模失败 */
        NETDEV_MODEL_STATUS_TYPE_INVALID = 0xFF      /* 无效值 */
    };

}
