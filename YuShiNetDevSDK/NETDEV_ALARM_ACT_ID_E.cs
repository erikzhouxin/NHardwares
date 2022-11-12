namespace System.Data.YuShiNetDevSDK
{
    /**
     * @enum tagNETDEVAlarmActID
     * @brief 使能联动参数
     * @attention
     */
    public enum NETDEV_ALARM_ACT_ID_E
    {
        ALARM_ACTION_TYPE_NVR_PREVIEW = 0,                    /* 联动NVR预览，ActParam见NETDEV_CHANNEL_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_BUZZER = 1,                    /* 联动蜂鸣器，IPC暂不支持,NVR ActParam见NETDEV_ENABLED_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_E_MAIL = 2,                    /* 联动E-Mail，IPC暂不支持，NVR ActParam见NETDEV_ENABLED_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_RECORD = 3,                    /* 联动存储，IPC暂不支持，NVR ActParam见NETDEV_CHANNEL_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_PRESET = 4,                    /* 联动云台预置位，ActParam见NETDEV_PRESET_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_OUTPUT_SWITCH = 5,                    /* 联动开关量输出，ActParam见NETDEV_OUTPUT_SWITCH_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_SNAP = 6,                    /* 联动抓拍，IPC无需填写ActParam ，NVR ActParam见NETDEV_CHANNEL_ACT_PARAM_INFO_S*/
        ALARM_ACTION_TYPE_BOX = 7,                    /* 告警弹框，IPC暂不支持，NVR ActParam见NETDEV_ENABLED_ACT_PARAM_INFO_S */
        ALARM_ACTION_TYPE_CENTER_RECORD = 8,                    /* 联动中心存储，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_START_LOCAL_RECORD = 9,                    /* 联动启动本地存储，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_STOP_LOCAL_RECORD = 10,                   /* 联动停止本地存储，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SNAP_UP_FTP = 11,                   /* 联动抓拍上传FTP，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SNAP_UP_EMAIL = 12,                   /* 联动抓拍上传EMail，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SNAP_UP_FTP_AND_EMAIL = 13,                   /* 联动抓拍上传FTP和EMail，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_SMART_SNAP_UP = 14,                   /* 智能联动抓拍上传，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_FACE_PIC_SNAP_UP = 15,                   /* 联动人脸小图抓拍上传，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_ALARM_REPORT = 16,                   /* 联动告警上报，IPC无需填写ActParam，NVR不支持 */
        ALARM_ACTION_TYPE_PTZ_ZOOM = 17,                   /* 联动云台变倍， */
        ALARM_ACTION_TYPE_INVALID = 0xff                  /* 无效参数 */
    }

}
