namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_CAPTURE_TYPE_E
    * @brief 抓拍上报类型
    * @attention 无 None
    */
    public enum NETDEV_ITS_CAPTURE_TYPE_E
    {
        NETDEV_ITS_CAPTURE_AUTO_TYPE = 0,        /**< 自动抓拍，包括外设抓拍、绊线触发 */
        NETDEV_ITS_CAPTURE_MANUAL_TYPE = 1,        /**< 手动抓拍 */
        NETDEV_ITS_CAPTURE_INVALID = 0xFFFF                        /* 无效值  Invalid value */
    }

}
