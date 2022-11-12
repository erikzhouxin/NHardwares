namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_EVENT_RES_TYPE_E
    {
        NETDEV_EVENT_RES_TYPE_USER = 0,                /* 用户资源，用户上下线对应登录句柄，其余对应用户编号 */
        NETDEV_EVENT_RES_TYPE_DEVICE = 1,                /* 设备资源，对应设备编号 */
        NETDEV_EVENT_RES_TYPE_CHANNEL = 2,                /* 通道资源，对应通道编号 */
        NETDEV_EVENT_RES_TYPE_LOGOUT = 3,                /* 强制用户退出，对应登录句柄 */
        NETDEV_EVENT_RES_TYPE_SEQUENCE = 4,                /* 轮巡资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_EMAP_HOTPOT = 5,                /* 电子地图热点资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_EMAP_HOTAREA = 6,                /* 电子地图热区资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_EMAP_ALARM = 7,                /* 电子地图告警资源，对应资源ID */
        NETDEV_EVENT_RES_TYPE_TIMETEMPLATE = 8,                /* 告警预案模板，对应模板ID */
        NETDEV_EVENT_RES_TYPE_SYSRIGHT = 9,                /* 系统权限资源，对应用户登录句柄 */
        NETDEV_EVENT_RES_TYPE_DEVRIGHT = 10,               /* 设备权限资源，对应通道编号 */
        NETDEV_EVENT_RES_TYPE_ORG = 11,               /* 组织资源，对应组织编号 */
        NETDEV_EVENT_RES_TYPE_ALARM_TASK = 12,               /* 报警任务资源，对应报警任务编号 */
        NETDEV_EVENT_RES_TYPE_SLAVE = 13,               /* 主从资源(与服务端保持一致) */
        NETDEV_EVENT_RES_TYPE_TVWALL = 14,               /* 电视墙资源，对应电视墙ID */
        NETDEV_EVENT_RES_TYPE_TVWALL_SCENE = 15,               /* 电视墙场景资源，对应电视墙ID */
        NETDEV_EVENT_RES_TYPE_WND = 16,               /* 电视墙窗口资源，对应窗口ID */
        NETDEV_EVENT_RES_TYPE_VIRTUAL_LED = 17,               /* 电视墙虚拟LED资源，对应虚拟LED ID */
        NETDEV_EVENT_RES_TYPE_BROADCAST_CHANGE = 18,               /* 广播组信息变更(值与服务端保持一致) */
        NETDEV_EVENT_RES_TYPE_LOGIC_ORG = 19,               /* 虚拟组织资源，对应组织编号，删除虚拟组织下通道时使用 */
        NETDEV_EVENT_RES_TYPE_USER_ROLE = 20,               /* 用户角色资源，对应用户登录句柄*/
        NETDEV_EVENT_RES_TYPE_ROLE_ORG = 21,               /* 角色组织展示树资源，对应用户登录句柄 */
        NETDEV_EVENT_RES_TYPE_EMAP_PIC = 22,               /* 图片资源，对应热区编号 */
        NETDEV_EVENT_RES_TYPE_PATROL = 23,               /* 巡航资源 */
        NETDEV_EVENT_RES_TYPE_RECORD = 24,               /* 录制轨迹资源 */
        NETDEV_EVENT_RES_TYPE_ACS_PERSON = 25,               /* 门禁人员资源，对应门禁人员ID */
        NETDEV_EVENT_RES_TYPE_ACS_PERSON_CARD = 26,               /* 门禁卡资源，对应门禁人员ID */
        NETDEV_EVENT_RES_TYPE_TVWALL_LIST = 27,               /* 电视墙列表，权限到电视墙 */
        NETDEV_EVENT_RES_TYPE_TVWALL_SCENE_SWITCH = 28,             /* 电视墙场景切换 */

        NETDEV_EVENT_RES_TYPE_FACE_LIB = 29,               /* 人脸库资源，对应人脸库ID */
        NETDEV_EVENT_RES_TYPE_FACE_CUSTOM = 30,               /* 人脸库自定义属性，对应属性ID */
        NETDEV_EVENT_RES_TYPE_FACE_MEMBER = 31,               /* 人脸成员资源，对应人脸库ID */
        NETDEV_EVENT_RES_TYPE_FACE_GUARD = 32,               /* 人脸布控资源，对应人脸布控ID */
        NETDEV_EVENT_RES_TYPE_SMART_DETECT = 33,               /* 智能检测资源，对应智能检测类型，人脸识别:0 */
        NETDEV_EVENT_RES_TYPE_MANUAL_STATUS = 34,               /* 手动录像状态 */
        NETDEV_EVENT_RES_TYPE_VEHICLE_GUARD = 38,               /* 车牌布控资源，对应车牌布控ID */
        NETDEV_EVENT_RES_TYPE_CDN_CHANNEL = 39,               /* CDN通道资源变更，不上报对应变更信息，客户端收到事件后主动来查询通道列表 */
        NETDEV_EVENT_RES_TYPE_FACE_MEMBER_SORT = 40,               /* 人脸成员划归资源，对应人脸库ID */
        NETDEV_EVENT_RES_TYPE_VEHICLE_LIB = 41,               /* 车辆库资源，对应车辆库ID */
        NETDEV_EVENT_RES_TYPE_VEHICLE_MEMBER_SORT = 42,             /* 车辆成员划归资源，对应车辆库ID */
        NETDEV_EVENT_RES_TYPE_VEHICLE_MEMBER = 43,             /* 车辆成员资源，对应车辆成员ID */
        NETDEV_EVENT_RES_TYPE_VIEWPLAN_RES = 44,               /* 视图计划，对应计划ID */
        NETDEV_EVENT_RES_TYPE_SCENESPLAN_RES = 45,               /* 场景间计划，对应计划ID */
        NETDEV_EVENT_RES_TYPE_ACS_PERMISSION = 46,               /* 权限资源,  用于授权信息变更*/
        NETDEV_EVENT_RES_TYPE_ACS_GROUP = 47,               /* 门禁权限组资源，用于门禁权限组（组织）的变更 */
        NETDEV_EVENT_RES_TYPE_TVWALL_AUDIO = 48,               /* 音频事件 */

        NETDEV_EVENT_RES_TYPE_INVALID = 0xFF              /* 无效值 */
    }

}
