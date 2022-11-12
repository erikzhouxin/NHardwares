namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_ALARM_TYPE_E
    {
        NETDEV_ALARM_MOVE_DETECT = 1,        /* 运动检测告警  Motion detection alarm */
        NETDEV_ALARM_MOVE_DETECT_RECOVER = 2,        /* 运动检测告警恢复  Motion detection alarm recover */
        NETDEV_ALARM_VIDEO_LOST = 3,        /* 视频丢失告警  Video loss alarm */
        NETDEV_ALARM_VIDEO_LOST_RECOVER = 4,        /* 视频丢失告警恢复  Video loss alarm recover */
        NETDEV_ALARM_VIDEO_TAMPER_DETECT = 5,        /* 遮挡侦测告警  Tampering detection alarm */
        NETDEV_ALARM_VIDEO_TAMPER_RECOVER = 6,        /* 遮挡侦测告警恢复  Tampering detection alarm recover */
        NETDEV_ALARM_INPUT_SWITCH = 7,        /* 输入开关量告警  boolean input alarm */
        NETDEV_ALARM_INPUT_SWITCH_RECOVER = 8,        /* 输入开关量告警恢复  Boolean input alarm recover */
        NETDEV_ALARM_TEMPERATURE_HIGH = 9,        /* 高温告警  High temperature alarm */
        NETDEV_ALARM_TEMPERATURE_LOW = 10,       /* 低温告警  Low temperature alarm */
        NETDEV_ALARM_TEMPERATURE_RECOVER = 11,       /* 温度告警恢复  Temperature alarm recover */
        NETDEV_ALARM_AUDIO_DETECT = 12,       /* 音频异常检测告警  Audio detection alarm */
        NETDEV_ALARM_AUDIO_DETECT_RECOVER = 13,       /* 音频异常检测告警恢复  Audio detection alarm recover */
        NETDEV_ALARM_SERVER_FAULT = 18,       /* 服务器故障 */
        NETDEV_ALARM_SERVER_NORMAL = 19,       /* 服务器故障恢复 */


        NETDEV_ALARM_REPORT_DEV_ONLINE = 201,       /* 设备上线告警 */
        NETDEV_ALARM_REPORT_DEV_OFFLINE = 202,       /* 设备下线告警 */
        NETDEV_ALARM_REPORT_DEV_REBOOT = 203,       /* 设备重启  Device restart */
        NETDEV_ALARM_REPORT_DEV_SERVICE_REBOOT = 204,       /* 服务重启  Service restart */
        NETDEV_ALARM_REPORT_DEV_CHL_ONLINE = 205,       /* 视频通道: 上线 */
        NETDEV_ALARM_REPORT_DEV_CHL_OFFLINE = 206,       /* 视频通道: 下线 */
        NETDEV_ALARM_REPORT_DEV_DELETE_CHL = 207,       /* 视频通道: 删除 */

        NETDEV_ALARM_DEVICE_HIGHTEMP = 246,       /* 异常类：设备高温 */
        NETDEV_ALARM_DEVICE_LOWTEMP = 247,       /* 异常类：设备低温 */
        NETDEV_ALARM_FAN_FAULT = 248,       /* 异常类：风扇故障 */
        NETDEV_ALARM_LEDBOX_HIGHTEMP = 249,       /* 异常类：电箱高温 */
        NETDEV_ALARM_LEDBOX_SMOKE = 250,       /* 异常类：电箱烟雾告警 */
        NETDEV_ALARM_DEVICE_HIGHTEMP_RECOVER = 251,       /* 异常类:设备温度恢复 */
        NETDEV_ALARM_DEVICE_LOWTEMP_RECOVER = 252,       /* 异常类:设备温度恢复 */
        NETDEV_ALARM_FAN_FAULT_RECOVER = 253,       /* 异常类:风扇故障恢复 */
        NETDEV_ALARM_LEDBOX_HIGHTEMP_RECOVER = 254,       /* 异常类:电箱高温恢复 */
        NETDEV_ALARM_LEDBOX_SMOKE_RECOVER = 255,       /* 异常类:电箱烟雾告警恢复 */

        NETDEV_ALARM_NET_FAILED = 401,      /* 会话网络错误 Network error */
        NETDEV_ALARM_NET_TIMEOUT = 402,      /* 会话网络超时 Network timeout */
        NETDEV_ALARM_SHAKE_FAILED = 403,      /* 会话交互错误 Interaction error */
        NETDEV_ALARM_STREAMNUM_FULL = 404,      /* 流数已经满 Stream full */
        NETDEV_ALARM_STREAM_THIRDSTOP = 405,      /* 第三方停止流 Third party stream stopped */
        NETDEV_ALARM_FILE_END = 406,      /* 文件结束 File ended */
        NETDEV_ALARM_RTMP_CONNECT_FAIL = 407,      /* RTMP连接失败 */
        NETDEV_ALARM_RTMP_INIT_FAIL = 408,      /* RTMP初始化失败*/

        NETDEV_ALARM_STREAM_DOWNLOAD_OVER = 409,      /* 一体机国标流下载完成 */
        NETDEV_ALARM_PLAYBACK_FINISH = 410,      /* 回放结束 */
        NETDEV_ALARM_VIDEO_RECORD_PART = 411,      /* 录像分段 */
        NETDEV_ALARM_FISHEYE_STREAM_EXIST = 412,      /* 鱼眼流存在,仅用于上报 */
        NETDEV_ALARM_FISHEYE_STREAM_NOT_EXIST = 413,      /* 鱼眼流不存在,仅用于上报 */
        NETDEV_ALARM_PTZ_RESOUCE_FAIL = 414,      /* 四目全景ptz资源错误 */
        NETDEV_ALARM_PTZ_STREAM_EXIST = 415,      /* 四目全景ptz流存在，仅用于上报 */
        NETDEV_ALARM_STREAM_NOT_EXIST = 416,      /* 四目全景ptz流不存在，仅用于上报 */
        NETDEV_ALARM_INNER_TIMEOUT = 417,      /* 内部处理超时 */
        NETDEV_ALARM_STREAM_NOT_READY = 418,      /* 流未就绪 */
        NETDEV_ALARM_KEEP_ALIVE_FAILED = 419,      /* 保活失败 */
        NETDEV_ALARM_OVER_ABILITY = 420,      /* 回放能力不足 */
        NETDEV_ALARM_UNAUTHORIZED = 421,      /* 未通过认证 */
        NETDEV_ALARM_FORIBIDDEN = 422,      /* 禁止 */
        NETDEV_ALARM_METHOD_NOT_ALLOWED = 423,      /* 不允许该方法 */
        NETDEV_ALARM_PRECONDITION_FAILED = 424,      /* 预处理失败 */
        NETDEV_ALARM_SESSION_NOT_FOUND = 425,      /* 找不到会话 */
        NETDEV_ALARM_NOT_ENOUGH_BANDWIDTH2 = 426,      /* 带宽不足(RTSP) */
        NETDEV_ALARM_REALPLAY_ESTABLISHED = 427,      /* 实况业务已经建立 */
        NETDEV_ALARM_REALPLAY_RES_BUSY = 428,      /* 实况业务显示资源忙 */
        NETDEV_ALARM_MULTICAST_DISABLED = 429,      /* 组播使能关闭 */
        NETDEV_ALARM_MULTICAST_PORT_OCCUPIED = 430,      /* 组播端口已被占用 */
        NETDEV_ALARM_MULTICAST_PORT_EXHAUSTED = 431,      /* 组播端口已耗尽 */
        NETDEV_ALARM_MULTICAST_USER_NOT_EXIST = 432,      /* 组播用户不存在 */
        NETDEV_ALARM_CHANNEL_NOT_ONLINE = 433,      /* 通道不在线 */
        NETDEV_ALARM_TALKBACK_ENCODED_INVALID = 434,      /* 语音对讲资源编码无效 */
        NETDEV_ALARM_VOICE_RES_USED_BY_TALKBACK = 435,      /* 语音资源已被对讲使用 */
        NETDEV_ALARM_TALKBACK_EXISTS = 436,      /* 语音对讲已存在 */
        NETDEV_ALARM_VOICE_WORK_NOT_EXIST = 437,      /* 语音业务不存在 */
        NETDEV_ALARM_TALKBACK_TIMEOUT = 438,      /* 建立语音对讲业务超时 */
        NETDEV_ALARM_TALKBACK_ERROR = 439,      /* 语音对讲失败 */

        NETDEV_ALARM_DISK_ERROR = 601,      /* 设备磁盘错误  Disk error */
        NETDEV_ALARM_SYS_DISK_ERROR = 602,      /* 系统磁盘错误  Disk error */
        NETDEV_ALARM_DISK_ONLINE = 603,      /* 设备磁盘上线 Disk online */
        NETDEV_ALARM_SYS_DISK_ONLINE = 604,      /* 系统磁盘上线 Disk online */
        NETDEV_ALARM_DISK_OFFLINE = 605,      /* 设备磁盘离线 */
        NETDEV_ALARM_SYS_DISK_OFFLINE = 606,      /* 系统磁盘离线 */
        NETDEV_ALARM_DISK_ABNORMAL = 607,      /* 磁盘异常 Disk abnormal */
        NETDEV_ALARM_DISK_ABNORMAL_RECOVER = 608,      /* 磁盘异常恢复 Disk abnormal recover */
        NETDEV_ALARM_DISK_STORAGE_WILL_FULL = 609,      /* 磁盘存储空间即将满 Disk StorageGoingfull */
        NETDEV_ALARM_DISK_STORAGE_WILL_FULL_RECOVER = 610,      /* 磁盘存储空间即将满恢复 Disk StorageGoingfull recover */
        NETDEV_ALARM_DISK_STORAGE_IS_FULL = 611,      /* 设备存储空间满 StorageIsfull */
        NETDEV_ALARM_SYS_DISK_STORAGE_IS_FULL = 612,      /* 系统存储空间满 StorageIsfull */
        NETDEV_ALARM_DISK_STORAGE_IS_FULL_RECOVER = 613,      /* 存储空间满恢复 StorageIsfull recover */
        NETDEV_ALARM_DISK_RAID_DISABLED_RECOVER = 614,      /* 阵列损坏恢复 RAIDDisabled recover */
        NETDEV_ALARM_DISK_RAID_DEGRADED = 615,      /* 设备阵列衰退 RAIDDegraded */
        NETDEV_ALARM_SYS_DISK_RAID_DEGRADED = 616,      /* 系统阵列衰退 RAIDDegraded */
        NETDEV_ALARM_DISK_RAID_DISABLED = 617,      /* 设备阵列损坏 RAIDDisabled */
        NETDEV_ALARM_SYS_DISK_RAID_DISABLED = 618,      /* 系统阵列损坏 RAIDDisabled */
        NETDEV_ALARM_DISK_RAID_DEGRADED_RECOVER = 619,      /* 阵列衰退恢复 RAIDDegraded recover */
        NETDEV_ALARM_STOR_GO_FULL = 620,      /* 设备存储即将满告警 */
        NETDEV_ALARM_SYS_STOR_GO_FULL = 621,      /* 系统存储即将满告警 */
        NETDEV_ALARM_ARRAY_NORMAL = 622,      /* 设备阵列正常 */
        NETDEV_ALARM_SYS_ARRAY_NORMAL = 623,      /* 系统阵列正常 */
        NETDEV_ALARM_DISK_RAID_RECOVERED = 624,      /* 阵列恢复正常 RAIDDegraded */
        NETDEV_ALARM_STOR_ERR = 625,      /* 设备存储错误  Storage error */
        NETDEV_ALARM_SYS_STOR_ERR = 626,      /* 系统存储错误  Storage error */
        NETDEV_ALARM_STOR_ERR_RECOVER = 627,      /* 存储错误恢复  Storage error recover */
        NETDEV_ALARM_STOR_DISOBEY_PLAN = 628,      /* 未按计划存储  Not stored as planned */
        NETDEV_ALARM_STOR_DISOBEY_PLAN_RECOVER = 629,      /* 未按计划存储恢复  Not stored as planned recover */

        NETDEV_ALARM_BANDWITH_CHANGE = 801,      /* 设备出口带宽变更 */
        NETDEV_ALARM_VIDEOENCODER_CHANGE = 802,      /* 设备码流配置变更告警 */
        NETDEV_ALARM_IP_CONFLICT = 803,      /* IP冲突异常告警 IP conflict exception alarm*/
        NETDEV_ALARM_IP_CONFLICT_CLEARED = 804,      /* IP冲突异常告警恢复IP conflict exception alarm recovery */
        NETDEV_ALARM_NET_OFF = 805,      /* 网络断开异常告警 */
        NETDEV_ALARM_NET_RESUME_ON = 806,      /* 网络断开恢复告警 */

        NETDEV_ALRAM_CONFLAG_DETECT = 920,      /* 火点告警 Conflagration detection alarm */


        NETDEV_ALARM_ILLEGAL_ACCESS = 1001,          /* 设备非法访问  Illegal access */
        NETDEV_ALARM_SYS_ILLEGAL_ACCESS = 1002,          /* 系统非法访问  Illegal access */
        NETDEV_ALARM_LINE_CROSS = 1003,          /* 越界告警  Line cross */
        NETDEV_ALARM_OBJECTS_INSIDE = 1004,          /* 区域入侵  Objects inside */
        NETDEV_ALARM_FACE_RECOGNIZE = 1005,          /* 人脸识别  Face recognize */
        NETDEV_ALARM_IMAGE_BLURRY = 1006,          /* 图像虚焦  Image blurry */
        NETDEV_ALARM_SCENE_CHANGE = 1007,          /* 场景变更  Scene change */
        NETDEV_ALARM_SMART_TRACK = 1008,          /* 智能跟踪  Smart track */
        NETDEV_ALARM_LOITERING_DETECTOR = 1009,          /* 徘徊检测  Loitering Detector */
        NETDEV_ALARM_BANDWIDTH_CHANGE = 1010,          /* 带宽变更  Bandwidth change */
        NETDEV_ALARM_ALLTIME_FLAG_END = 1011,          /* 无布防告警结束标记  End marker of alarm without arming schedule */
        NETDEV_ALARM_MEDIA_CONFIG_CHANGE = 1012,          /* 编码参数变更 media configurationchanged */
        NETDEV_ALARM_REMAIN_ARTICLE = 1013,          /*物品遗留告警  Remain article*/
        NETDEV_ALARM_PEOPLE_GATHER = 1014,          /* 人员聚集告警 People gather alarm*/
        NETDEV_ALARM_ENTER_AREA = 1015,          /* 进入区域 Enter area*/
        NETDEV_ALARM_LEAVE_AREA = 1016,          /* 离开区域 Leave area*/
        NETDEV_ALARM_ARTICLE_MOVE = 1017,          /* 物品搬移 Article move*/
        NETDEV_ALARM_SMART_FACE_MATCH_LIST = 1018,       /* 人脸识别黑名单报警 */
        NETDEV_ALARM_SMART_FACE_MATCH_LIST_RECOVER = 1019,       /* 人脸识别黑名单报警恢复 */
        NETDEV_ALARM_SMART_FACE_MISMATCH_LIST = 1020,       /* 人脸识别不匹配报警 */
        NETDEV_ALARM_SMART_FACE_MISMATCH_LIST_RECOVER = 1021,       /* 人脸识别不匹配报警恢复 */
        NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST = 1022,       /* 车辆识别匹配报警 */
        NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST_RECOVER = 1023,       /* 车辆识别匹配报警恢复 */
        NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST = 1024,       /* 车辆识别不匹配报警 */
        NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST_RECOVER = 1025,       /* 车辆识别不匹配报警回复 */
        NETDEV_ALARM_IMAGE_BLURRY_RECOVER = 1026,         /* 图像虚焦告警恢复  Image blurry recover */
        NETDEV_ALARM_SMART_TRACK_RECOVER = 1027,         /* 智能跟踪告警恢复  Smart track recover */
        NETDEV_ALARM_SMART_READ_ERROR_RATE = 1028,         /* 底层数据读取错误率Error reding the underlying data */
        NETDEV_ALARM_SMART_SPIN_UP_TIME = 1029,         /* 主轴起旋时间  Rotation time of spindle */
        NETDEV_ALARM_SMART_START_STOP_COUNT = 1030,         /* 启停计数 Rev. Stop counting*/
        NETDEV_ALARM_SMART_REALLOCATED_SECTOR_COUNT = 1031,         /* 重映射扇区计数  Remap sector count*/
        NETDEV_ALARM_SMART_SEEK_ERROR_RATE = 1032,         /* 寻道错误率 Trace error rate*/
        NETDEV_ALARM_SMART_POWER_ON_HOURS = 1033,         /* 通电时间累计，出厂后通电的总时间，一般磁盘寿命三万小时 */
        NETDEV_ALARM_SMART_SPIN_RETRY_COUNT = 1034,         /* 主轴起旋重试次数 */
        NETDEV_ALARM_SMART_CALIBRATION_RETRY_COUNT = 1035,         /* 磁头校准重试计数 */
        NETDEV_ALARM_SMART_POWER_CYCLE_COUNT = 1036,         /* 通电周期计数 */
        NETDEV_ALARM_SMART_POWEROFF_RETRACT_COUNT = 1037,         /* 断电返回计数 */
        NETDEV_ALARM_SMART_LOAD_CYCLE_COUNT = 1038,         /* 磁头加载计数 */
        NETDEV_ALARM_SMART_TEMPERATURE_CELSIUS = 1039,         /* 温度 */
        NETDEV_ALARM_SMART_REALLOCATED_EVENT_COUNT = 1040,         /* 重映射事件计数 */
        NETDEV_ALARM_SMART_CURRENT_PENDING_SECTOR = 1041,         /* 当前待映射扇区计数 */
        NETDEV_ALARM_SMART_OFFLINE_UNCORRECTABLE = 1042,         /* 脱机无法校正的扇区计数 */
        NETDEV_ALARM_SMART_UDMA_CRC_ERROR_COUNT = 1043,         /* 奇偶校验错误率  */
        NETDEV_ALARM_SMART_MULTI_ZONE_ERROR_RATE = 1044,         /* 多区域错误率 */
        NETDEV_ALARM_RESOLUTION_CHANGE = 1045,         /* 分辨率变更 */
        NETDEV_ALARM_MANUAL = 1401,         /* 手动告警 */
        NETDEV_ALARM_ALARMHOST_COMMON = 1402,         /* 报警点事件 */
        NETDEV_ALARM_DOORHOST_COMMON = 1403,         /* 门禁事件 */
        NETDEV_ALARM_FACE_NOT_MATCH = 1411,         /* 人脸对比失败 */
        NETDEV_ALARM_FACE_MATCH_SUCCEED = 1412,         /* 人脸对比成功 */

        NETDEV_ALARM_VEHICLE_BLACK_LIST = 1420,         /* 车辆识别黑名单报警 */
        NETDEV_ALARM_HUMAN_SHAPE_DETECTION = 1421,         /* 人形检测 */
        NETDEV_ALARM_HUMAN_SHAPE_DETECTION_RECOVER = 1422,         /* 人形检测告警恢复 */

        NETDEV_ALARM_INVALID = 0xFFFF        /* 无效值  Invalid value */
    };

}
