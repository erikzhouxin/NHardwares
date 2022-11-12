namespace System.Data.YuShiNetDevSDK
{
    /**
    * @enum tagNETDEVSmartAlarmType
    * @brief 智能告警类型
    * @attention 无
    */
    public enum NETDEV_SMART_ALARM_TYPE_E
    {
        NETDEV_SMART_ALARM_TYPE_FACE_SNAP = 0,             /* 人脸识别抓图 */
        NETDEV_SMART_ALARM_TYPE_VEHICLE_SNAP = 1,             /* 车牌识别抓图 */
        NETDEV_SMART_ALARM_TYPE_VIDEO_STRUCT_SNAP = 3,             /* 视频结构化抓图 */
        NETDEV_SMART_ALARM_TYPE_INVALID = 0xFF           /* 无效值 */
    }

}
