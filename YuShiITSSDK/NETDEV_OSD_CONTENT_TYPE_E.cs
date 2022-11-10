namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_OSD_CONTENT_TYPE_E
    {
        NETDEV_OSD_CONTENT_TYPE_NOTUSE = 0,                    /* 不使用 Not used*/
        NETDEV_OSD_CONTENT_TYPE_CUSTOM = 1,                    /* 自定义 Custom*/
        NETDEV_OSD_CONTENT_TYPE_DATE_AND_TIME = 2,                    /* 时间日期 Time and date*/
        NETDEV_OSD_CONTENT_TYPE_PTZ_CONTROLLER = 3,                    /* 云台控制者 PTZ controller*/
        NETDEV_OSD_CONTENT_TYPE_PTZ_COORDINATES = 4,                    /* 云台坐标 PTZ Coordinates*/
        NETDEV_OSD_CONTENT_TYPE_CRUISE = 5,                    /* 巡航信息 Patrol*/
        NETDEV_OSD_CONTENT_TYPE_ZOOM = 6,                    /* 变倍信息 Zoom*/
        NETDEV_OSD_CONTENT_TYPE_PRESET = 7,                    /* 预置位信息  Preset*/
        NETDEV_OSD_CONTENT_TYPE_ALARM_INFO = 8,                    /* 报警信息 Alarm */
        NETDEV_OSD_CONTENT_TYPE_ENCODE = 9,                    /* 编码信息 Encoding*/
        NETDEV_OSD_CONTENT_TYPE_SERIAL_PORT = 10,                   /* 串口OSD Serial Port OSD*/
        NETDEV_OSD_CONTENT_TYPE_PTZ_ORIENTATION = 11,                   /* 云台方位信息 PZT direction*/
        NETDEV_OSD_CONTENT_TYPE_CHN_NAME = 12,                   /* 通道名称 Channel name*/
        NETDEV_OSD_CONTENT_TYPE_DEBUG = 13,                   /* 调试OSD  Debug OSD*/
        NETDEV_OSD_CONTENT_TYPE_PEOPLE_COUNTING = 14,                   /* 人数统计OSD People counting OSD*/
        NETDEV_OSD_CONTENT_TYPE_NETWORK_PORT = 15,                   /* 网口OSD Network Port OSD*/
        NETDEV_OSD_CONTENT_TYPE_TIME = 16,                   /* 时间 Time*/
        NETDEV_OSD_CONTENT_TYPE_DATE = 17,                   /* 日期 Date*/
        NETDEV_OSD_CONTENT_TYPE_SMART_CONTENT = 18,                   /* 超感类OSD Sensing OSD*/
        NETDEV_OSD_CONTENT_TYPE_BATTERY = 19,                   /* 电池OSD Battery OSD*/
        NETDEV_OSD_CONTENT_TYPE_SCROLL_OSD = 20,                   /* 滚动字幕OSD Scroll text OSD*/
        NETDEV_OSD_CONTENT_TYPE_PICTURE_OVERLAY = 21,                   /* LOGO OSD */
        NETDEV_OSD_CONTENT_TYPE_MOTOR_VEHICLE_NUM = 22,                   /* 天网卡口机动车流量 Vehicle flow of LPR*/
        NETDEV_OSD_CONTENT_TYPE_NON_MOTOR_VEHICLE_NUM = 23,                   /* 天网卡口非机动车流量 Non-vehicle flow of LPR*/
        NETDEV_OSD_CONTENT_TYPE_PEOPLE_NUM = 24,                   /* 天网卡口行人流量 Pedestrian flow of LPR*/
        NETDEV_OSD_CONTENT_TYPE_INFOOSD_NUM = 25                    /* INFOOSD类型数目 Number of INFOOSDtype*/
    }

}
