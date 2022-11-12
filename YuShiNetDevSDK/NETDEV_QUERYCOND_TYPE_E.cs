namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVQueryCondType
     * @brief 查询条件类型
     * @attention 无 None
     */
    public enum NETDEV_QUERYCOND_TYPE_E
    {
        NETDEV_QUERYCOND_USERNAME = 0,                /* 查询条件：用户名称 */
        NETDEV_QUERYCOND_ORGNAME = 1,                /* 查询条件：组织名称 */
        NETDEV_QUERYCOND_DEVNAME = 2,                /* 查询条件：设备名称 */
        NETDEV_QUERYCOND_CHNNAME = 3,                /* 查询条件：通道名称 */
        NETDEV_QUERYCOND_TIME = 4,                /* 查询条件：时间 */
        NETDEV_QUERYCOND_BUSINESSTYPE = 5,                /* 查询条件：业务类型 */
        NETDEV_QUERYCOND_OPERATETYPE = 6,                /* 查询条件：操作类型 */
        NETDEV_QUERYCOND_OPEROBJECT = 7,                /* 查询条件：操作对象 */
        NETDEV_QUERYCOND_ALARMTYPE = 8,                /* 查询条件：告警类型 参见枚举NETDEV_ALARM_TYPE_E*/
        NETDEV_QUERYCOND_ALARMSRCNAME = 9,                /* 查询条件：告警源名称 */
        NETDEV_QUERYCOND_ALARMLEVEL = 10,               /* 查询条件：告警级别 */
        NETDEV_QUERYCOND_ALARMCHECKED = 11,               /* 查询条件：告警是否确认 */
        NETDEV_QUERYCOND_ALARMCHECKUSER = 12,               /* 查询条件：告警确认用户 */
        NETDEV_QUERYCOND_ALARMCHECKTIME = 13,               /* 查询条件：告警确认时间 */
        NETDEV_QUERYCOND_ALARM_DEVID = 14,               /* 查询条件：告警设备ID */
        NETDEV_QUERYCOND_ALARM_CHNID = 15,               /* 查询条件：告警通道ID */
        NETDEV_QUERYCOND_ALARM_SUBTYPE = 16,               /* 查询条件：告警子类型 */
        NETDEV_QUERYCOND_ALARM_SERVER = 17,               /* 查询条件：归属服务器 */
        NETDEV_QUERYCOND_DOOR_NUM = 18,               /* 查询条件：门编号 */
        NETDEV_QUERYCOND_CARD_NUM = 19,               /* 查询条件：卡号 */
        NETDEV_QUERYCOND_ALARM_GENDER = 20,               /* 查询条件：性别 */
        NETDEV_QUERYCOND_ALARM_BIRTHDAY = 21,               /* 查询条件：出生年月 */
        NETDEV_QUERYCOND_MONITOY_REASON = 22,               /* 查询条件：布控原因 */
        NETDEV_QUERYCOND_PLATE_NUM = 23,               /* 查询条件：车牌号码 */
        NETDEV_QUERYCOND_VEHICLE_TYPE = 24,               /* 查询条件：车辆类型 */
        NETDEV_QUERYCOND_PLATE_COLOR = 25,               /* 查询条件：车牌颜色 */
        NETDEV_QUERYCOND_VEHICLE_COLOR = 26,               /* 查询条件：车身颜色 */
        NETDEV_QUERYCOND_PERSON_NUMBER = 27,               /* 查询条件：员工编号*/
        NETDEV_QUERYCOND_PERSON_TYPE = 28,               /* 查询条件：人员类型*/
        NETDEV_QUERYCOND_DIRECT = 29,               /* 查询条件：方向*/
        NETDEV_QUERYCOND_ORGID = 30,               /* 组织ID */
        NETDEV_QUERYCOND_ORGPID = 31,               /* 组织PID */
        NETDEV_QUERYCOND_DEVICEID = 32,               /* 设备ID */
        NETDEV_QUERYCOND_DEVICE_TYPE = 33,               /* 设备类型 */
        NETDEV_QUERYCOND_DEVICE_SUBTYPE = 34,               /* 设备子类型 */
        NETDEV_QUERYCOND_CHANNELID = 35,               /* 通道ID */
        NETDEV_QUERYCOND_CHANNEL_TYPE = 36,               /* 通道类型 */
        NETDEV_QUERYCOND_ONLINE_STATE = 37,               /* 在线状态 */
        NETDEV_DATABASE_ID = 38,               /* 查询条件：库ID */
        NETDEV_QUERY_TYPE_PLATECLASS = 39,               /* 查询条件：车牌类型 */
        NETDEV_QUERYCOND_RANGE = 40,               /* 查询条件：告警查询范围 0是设备，1是服务器*/
        NETDEV_QUERYCOND_BEGIN_TIME = 41,             /* 查询条件：访客预约开始时间*/
        NETDEV_QUERYCOND_END_TIME = 42,             /* 查询条件：访客预约结束时间*/
        NETDEV_QUERYCOND_INTERVIEWEE_NAME = 43,             /* 查询条件：受访人姓名*/
        NETDEV_QUERYCOND_INTERVIEWEE_STATUS = 44,             /* 查询条件：受访人状态*/
        NETDEV_QUERYCOND_PARK_NAME = 45,               /* 查询条件：停车场名称 */
        NETDEV_QUERYCOND_CONFIDENCE_LEVEL = 46,               /* 查询条件：置信度 */
        NETDEV_QUERYCOND_PARK_TIME = 47,               /* 查询条件：停车时长 */
        NETDEV_QUERYCOND_CONTRACT_RULE = 48,               /* 查询条件：包期规则 */
        NETDEV_QUERYCOND_PAYMENT_METHOD = 49,               /* 查询条件：付款方式 */
        NETDEV_QUERYCOND_PASSING_DIRECTION = 50,               /* 查询条件：过车方向 */
        NETDEV_QUERYCOND_VEHICLE_ATTR = 51,               /* 查询条件：车辆属性 */
        NETDEV_QUERYCOND_STATISTICS_UNITS = 52,               /* 查询条件：统计单位 */
        NETDEV_QUERYCOND_EXITENTRANCE_NAME = 53,               /* 查询条件：出入口名称 */
        NETDEV_QUERYCOND_PICTURE_DATA = 54,               /* 查询条件：图片数据 */
        NETDEV_QUERYCOND_PERSON_NAME = 55,               /* 查询条件：人员姓名 */
        NETDEV_QUERYCOND_SIMILARITY = 56,               /* 查询条件：相似度 */
        NETDEV_QUERYCOND_SEARCH_TYPE = 57,               /* 查询条件：检索类型，参见枚举值NETDEV_SEARCH_TYPE_E */
        NETDEV_QUERYCOND_ID_NUMBER = 58,               /* 查询条件：证件号 */
        NETDEV_QUERYCOND_AGERANGE = 59,               /* 查询条件：年龄段 */
        NETDEV_QUERYCOND_GLASSES_STYLE = 61,               /* 查询条件：眼镜款式 */
        NETDEV_QUERYCOND_SLEEVES_LENGTH = 62,               /* 查询条件：上衣长短款式 */
        NETDEV_QUERYCOND_COAT_COLOR = 63,               /* 查询条件：上衣颜色 */
        NETDEV_QUERYCOND_TROUSERS_STYLE = 64,               /* 查询条件：下衣长短款式 */
        NETDEV_QUERYCOND_TROUSERS_COLOR = 65,               /* 查询条件：下衣颜色 */
        NETDEV_QUERYCOND_SNAP_TOWARD = 66,               /* 查询条件：抓拍朝向 */
        NETDEV_QUERYCOND_SHOES_TUBE_LENGTH = 67,               /* 查询条件：鞋子长短款式 */
        NETDEV_QUERYCOND_HAIR_LENGTH = 68,               /* 查询条件：发型长短 */
        NETDEV_QUERYCOND_BAG_FLAG = 69,               /* 查询条件：是否携包 */
        NETDEV_QUERYCOND_SPEED_TYPE = 70,               /* 查询条件：速度类型 */
        NETDEV_QUERYCOND_NON_VEH_TYPE = 71,               /* 查询条件：非机动车类型 */
        NETDEV_QUERYCOND_VEH_BRAND = 72,               /* 查询条件：车辆品牌 */
        NETDEV_QUERYCOND_VEH_DATA_TYPE = 73,               /* 查询条件：车辆数据类型（0：普通抓拍数据，1：结构化抓拍数据） */
        NETDEV_QUERYCOND_PROTOCOL_TYPE = 74,       /* 查询条件：设备接入协议 */
        NETDEV_QUERYCOND_RELEVANT_ROOM = 75,       /* 查询条件：关联房间 */
        NETDEV_QUERYCOND_LOCK_SIGNAL = 76,       /* 查询条件：智能锁信号 */
        NETDEV_QUERYCOND_BIND_RELATION_DOORLOCK = 77,       /* 查询条件：门锁绑定关系 */
        NETDEV_QUERYCOND_BIND_RELATION_PERSON_CARD = 78,       /* 查询条件：人卡绑定关系 */
        NETDEV_QUERYCOND_PERSONID = 79,       /* 查询条件：人员ID */
        NETDEV_QUERYCOND_PARKINGLOTID = 80,       /* 查询条件：停车场ID */
        NETDEV_QUERYCOND_ENTREXITID = 81,       /* 查询条件：出入口ID */
        NETDEV_QUERYCOND_RECORDID = 82,       /* 查询条件：记录ID */
        NETDEV_QUERYCOND_VEH_GROUPINGID = 83,       /* 查询条件：车辆分组ID */

        NETDEV_QUERYCOND_INVALID = 0xFF              /* 无效 */
    }

}
