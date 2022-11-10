namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_ALARM_TYPE_E
    {
        NETDEV_ALARM_MOVE_DETECT = 1,        /*Motion detection alarm */
        NETDEV_ALARM_MOVE_DETECT_RECOVER = 2,        /*Motion detection alarm recover */
        NETDEV_ALARM_VIDEO_LOST = 3,        /* Video loss alarm */
        NETDEV_ALARM_VIDEO_LOST_RECOVER = 4,        /* Video loss alarm recover */
        NETDEV_ALARM_VIDEO_TAMPER_DETECT = 5,        /* Tampering detection alarm */
        NETDEV_ALARM_VIDEO_TAMPER_RECOVER = 6,        /* Tampering detection alarm recover */
        NETDEV_ALARM_INPUT_SWITCH = 7,        /* boolean input alarm */
        NETDEV_ALARM_INPUT_SWITCH_RECOVER = 8,        /* Boolean input alarm recover */
        NETDEV_ALARM_TEMPERATURE_HIGH = 9,        /* High temperature alarm */
        NETDEV_ALARM_TEMPERATURE_LOW = 10,       /* Low temperature alarm */
        NETDEV_ALARM_TEMPERATURE_RECOVER = 11,       /* Temperature alarm recover */
        NETDEV_ALARM_AUDIO_DETECT = 12,       /* Audio detection alarm */
        NETDEV_ALARM_AUDIO_DETECT_RECOVER = 13,       /* Audio detection alarm recover */
        NETDEV_ALARM_SERVER_FAULT = 18,
        NETDEV_ALARM_SERVER_NORMAL = 19,


        NETDEV_ALARM_REPORT_DEV_ONLINE = 201,
        NETDEV_ALARM_REPORT_DEV_OFFLINE = 202,
        NETDEV_ALARM_REPORT_DEV_REBOOT = 203,       /* Device restart */
        NETDEV_ALARM_REPORT_DEV_SERVICE_REBOOT = 204,       /*Service restart */
        NETDEV_ALARM_REPORT_DEV_CHL_ONLINE = 205,
        NETDEV_ALARM_REPORT_DEV_CHL_OFFLINE = 206,
        NETDEV_ALARM_REPORT_DEV_DELETE_CHL = 207,

        NETDEV_ALARM_NET_FAILED = 401,      /* Network error */
        NETDEV_ALARM_NET_TIMEOUT = 402,      /* Network timeout */
        NETDEV_ALARM_SHAKE_FAILED = 403,      /* Interaction error */
        NETDEV_ALARM_STREAMNUM_FULL = 404,      /* Stream full */
        NETDEV_ALARM_STREAM_THIRDSTOP = 405,      /* Third party stream stopped */
        NETDEV_ALARM_FILE_END = 406,      /* File ended */
        NETDEV_ALARM_RTMP_CONNECT_FAIL = 407,
        NETDEV_ALARM_RTMP_INIT_FAIL = 408,

        NETDEV_ALARM_DISK_ERROR = 601,      /* Disk error */
        NETDEV_ALARM_SYS_DISK_ERROR = 602,      /* Disk error */
        NETDEV_ALARM_DISK_ONLINE = 603,      /* Disk online */
        NETDEV_ALARM_SYS_DISK_ONLINE = 604,      /* Disk online */
        NETDEV_ALARM_DISK_OFFLINE = 605,
        NETDEV_ALARM_SYS_DISK_OFFLINE = 606,
        NETDEV_ALARM_DISK_ABNORMAL = 607,      /*Disk abnormal */
        NETDEV_ALARM_DISK_ABNORMAL_RECOVER = 608,      /*Disk abnormal recover */
        NETDEV_ALARM_DISK_STORAGE_WILL_FULL = 609,      /*Disk StorageGoingfull */
        NETDEV_ALARM_DISK_STORAGE_WILL_FULL_RECOVER = 610,      /* Disk StorageGoingfull recover */
        NETDEV_ALARM_DISK_STORAGE_IS_FULL = 611,      /*StorageIsfull */
        NETDEV_ALARM_SYS_DISK_STORAGE_IS_FULL = 612,      /* StorageIsfull */
        NETDEV_ALARM_DISK_STORAGE_IS_FULL_RECOVER = 613,      /* StorageIsfull recover */
        NETDEV_ALARM_DISK_RAID_DISABLED_RECOVER = 614,      /* RAIDDisabled recover */
        NETDEV_ALARM_DISK_RAID_DEGRADED = 615,      /* RAIDDegraded */
        NETDEV_ALARM_SYS_DISK_RAID_DEGRADED = 616,      /* RAIDDegraded */
        NETDEV_ALARM_DISK_RAID_DISABLED = 617,      /* RAIDDisabled */
        NETDEV_ALARM_SYS_DISK_RAID_DISABLED = 618,      /*  RAIDDisabled */
        NETDEV_ALARM_DISK_RAID_DEGRADED_RECOVER = 619,      /* RAIDDegraded recover */
        NETDEV_ALARM_STOR_GO_FULL = 620,
        NETDEV_ALARM_SYS_STOR_GO_FULL = 621,
        NETDEV_ALARM_ARRAY_NORMAL = 622,
        NETDEV_ALARM_SYS_ARRAY_NORMAL = 623,
        NETDEV_ALARM_DISK_RAID_RECOVERED = 624,      /*RAIDDegraded */
        NETDEV_ALARM_STOR_ERR = 625,      /*Storage error */
        NETDEV_ALARM_SYS_STOR_ERR = 626,      /*Storage error */
        NETDEV_ALARM_STOR_ERR_RECOVER = 627,      /*Storage error recover */
        NETDEV_ALARM_STOR_DISOBEY_PLAN = 628,      /* Not stored as planned */
        NETDEV_ALARM_STOR_DISOBEY_PLAN_RECOVER = 629,      /* Not stored as planned recover */

        NETDEV_ALARM_BANDWITH_CHANGE = 801,
        NETDEV_ALARM_VIDEOENCODER_CHANGE = 802,
        NETDEV_ALARM_IP_CONFLICT = 803,      /* IP conflict exception alarm*/
        NETDEV_ALARM_IP_CONFLICT_CLEARED = 804,      /*conflict exception alarm recovery */
        NETDEV_ALARM_NET_OFF = 805,
        NETDEV_ALARM_NET_RESUME_ON = 806,

        NETDEV_ALARM_ILLEGAL_ACCESS = 1001,          /*Illegal access */
        NETDEV_ALARM_SYS_ILLEGAL_ACCESS = 1002,          /*Illegal access */
        NETDEV_ALARM_LINE_CROSS = 1003,          /*Line cross */
        NETDEV_ALARM_OBJECTS_INSIDE = 1004,          /*Objects inside */
        NETDEV_ALARM_FACE_RECOGNIZE = 1005,          /* Face recognize */
        NETDEV_ALARM_IMAGE_BLURRY = 1006,          /*Image blurry */
        NETDEV_ALARM_SCENE_CHANGE = 1007,          /*Scene change */
        NETDEV_ALARM_SMART_TRACK = 1008,          /* Smart track */
        NETDEV_ALARM_LOITERING_DETECTOR = 1009,          /* Loitering Detector */
        NETDEV_ALARM_BANDWIDTH_CHANGE = 1010,          /* Bandwidth change */
        NETDEV_ALARM_ALLTIME_FLAG_END = 1011,          /*  End marker of alarm without arming schedule */
        NETDEV_ALARM_MEDIA_CONFIG_CHANGE = 1012,          /*  media configurationchanged */
        NETDEV_ALARM_REMAIN_ARTICLE = 1013,          /* Remain article*/
        NETDEV_ALARM_PEOPLE_GATHER = 1014,          /*  People gather alarm*/
        NETDEV_ALARM_ENTER_AREA = 1015,          /* Enter area*/
        NETDEV_ALARM_LEAVE_AREA = 1016,          /* Leave area*/
        NETDEV_ALARM_ARTICLE_MOVE = 1017,          /* Article move*/
        NETDEV_ALARM_SMART_FACE_MATCH_LIST = 1018,
        NETDEV_ALARM_SMART_FACE_MATCH_LIST_RECOVER = 1019,
        NETDEV_ALARM_SMART_FACE_MISMATCH_LIST = 1020,
        NETDEV_ALARM_SMART_FACE_MISMATCH_LIST_RECOVER = 1021,
        NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST = 1022,
        NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST_RECOVER = 1023,
        NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST = 1024,
        NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST_RECOVER = 1025,
        NETDEV_ALARM_IMAGE_BLURRY_RECOVER = 1026,         /* Image blurry recover */
        NETDEV_ALARM_SMART_TRACK_RECOVER = 1027,         /* Smart track recover */
        NETDEV_ALARM_SMART_READ_ERROR_RATE = 1028,         /* Error reding the underlying data */
        NETDEV_ALARM_SMART_SPIN_UP_TIME = 1029,         /* Rotation time of spindle */
        NETDEV_ALARM_SMART_START_STOP_COUNT = 1030,         /* Rev. Stop counting*/
        NETDEV_ALARM_SMART_REALLOCATED_SECTOR_COUNT = 1031,         /*  Remap sector count*/
        NETDEV_ALARM_SMART_SEEK_ERROR_RATE = 1032,         /* Trace error rate*/
        NETDEV_ALARM_SMART_POWER_ON_HOURS = 1033,
        NETDEV_ALARM_SMART_SPIN_RETRY_COUNT = 1034,
        NETDEV_ALARM_SMART_CALIBRATION_RETRY_COUNT = 1035,
        NETDEV_ALARM_SMART_POWER_CYCLE_COUNT = 1036,
        NETDEV_ALARM_SMART_POWEROFF_RETRACT_COUNT = 1037,
        NETDEV_ALARM_SMART_LOAD_CYCLE_COUNT = 1038,
        NETDEV_ALARM_SMART_TEMPERATURE_CELSIUS = 1039,
        NETDEV_ALARM_SMART_REALLOCATED_EVENT_COUNT = 1040,
        NETDEV_ALARM_SMART_CURRENT_PENDING_SECTOR = 1041,
        NETDEV_ALARM_SMART_OFFLINE_UNCORRECTABLE = 1042,
        NETDEV_ALARM_SMART_UDMA_CRC_ERROR_COUNT = 1043,
        NETDEV_ALARM_SMART_MULTI_ZONE_ERROR_RATE = 1044,
        NETDEV_ALARM_RESOLUTION_CHANGE = 1045,
        NETDEV_ALARM_MANUAL = 1401,
        NETDEV_ALARM_ALARMHOST_COMMON = 1402,
        NETDEV_ALARM_DOORHOST_COMMON = 1403,

        NETDEV_ALARM_INVALID = 0xFFFF        /*Invalid value */
    }

}
