namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_ALARM_TYPE_V30_E
    {
        NETDEV_ALARM_RYPE_DEV_STATUS = (0x1 << 0),         /* 设备状态类型告警 */
        NETDEV_ALARM_RYPE_COMM_ALARM = (0x1 << 1),         /* 监控业务类告警 */
        NETDEV_ALARM_RYPE_INTEL_ALARM = (0x1 << 2),         /* 泛智能告警 */
        NETDEV_ALARM_RYPE_SMART_ALARM = (0x1 << 3),         /* 智能类告警 */
        NETDEV_ALARM_RYPE_FACE_RECOGNITION = (0x1 << 4),         /* 人脸识别 NETDEV_SetPersonAlarmCallBack */
        NETDEV_ALARM_RYPE_STRUCTURED_DATA = (0x1 << 5),         /* 结构化数 NETDEV_SetStructAlarmCallBack */
        NETDEV_ALARM_RYPE_VEHICLE_RECOGNITION = (0x1 << 6),         /* 车牌识别 NETDEV_SetVehicleAlarmCallBack */
        NETDEV_ALARM_RYPE_TRAFFIC_DATA = (0x1 << 7),         /* 交通数据 (暂未支持) */
        NETDEV_ALARM_RYPE_HYPERSENSITIVE_DATA = (0x1 << 8),         /* 超感数据 (暂未支持) */
        NETDEV_ALARM_RYPE_RESOURCE_CHANGE = (0x1 << 9),         /* 资源变更 NETDEV_SetResChangeEventCallBack */
        NETDEV_ALARM_RYPE_PERSON_VERIFICATION = (0x1 << 10),        /* 人员核验 NETDEV_SetAlarmFGCallBack */
        NETDEV_ALARM_RYPE_PARKING_IDENTIFICATION = (0x1 << 11),        /* 车场抓拍 NETDEV_SetParkEventCallBack */
        NETDEV_ALARM_RYPE_FIREALARM_DATA = (0x1 << 12),        /* 火点告警 NETDEV_SetConflagrationAlarmCallBack */
        NETDEV_ALARM_RYPE_ALARM_PICTURE_DATA = (0x1 << 13),        /* 告警图片数据 NETDEV_SetPicAlarmCallBack */
        NETDEV_ALARM_RYPE_PEOPLE_COUNT = (0x1 << 14),        /* 人数统计 NETDEV_SetPeopleCountAlarmCallBack */
        NETDEV_ALARM_RYPE_HEATMAP_DATA = (0x1 << 16),        /* 热度图数据 (暂未支持) */
        NETDEV_ALARM_RYPE_PLAYBOX_STATUS = (0x1 << 17),        /* 播放盒状态 (暂未支持) */
        NETDEV_ALARM_RYPE_PLAYBOX_MANAGEMENT = (0x1 << 18),        /* 播放盒管理设备在线状态(暂未支持)... */
        NETDEV_ALARM_RYPE_INVALID = 0xFF
    };

}
