namespace System.Data.YuShiNetDevSDK
{
    /**
    * @struct tagNETDEVFacePassRecordType
    * @brief 人脸通行记录类型
    * @attention 无 None
    */
    public enum NETDEV_FACE_PASS_RECORD_TYPE_E
    {
        NETDEV_TYPE_FACE_PASS_COM_SUCCESS = 1,                /* 比对成功告警 */
        NETDEV_TYPE_FACE_PASS_COM_FAIL = 2,                /* 比对失败告警 */
        NETDEV_TYPE_FACE_PASS_INVALID = 0xff              /* 无效值 */
    }

}
