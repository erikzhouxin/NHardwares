namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVCapSrc
    * @brief 采集来源
    * @attention 无 None
    */
    public enum NETDEV_CAP_SRC_E
    {
        NETDEV_CAP_SRC_FACE = 1,          /* 人脸识别终端采集的人脸信息 */
        NETDEV_CAP_SRC_ENTRANCE_GUARDCARD = 2,          /* 读卡器采集的门禁卡信息 */
        NETDEV_CAP_SRC_ID = 3,          /* 读卡器采集的身份证信息 */
        NETDEV_CAP_SRC_GATE = 4,          /* 闸机采集的闸机信息 */
        NETDEV_CAP_SRC_INVALID = 0xff        /* 无效值 Invalid value */
    }

}
