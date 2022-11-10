namespace System.Data.YuShiITSSDK
{
    /**
    * NETDEV_ITS_STATUS_TYPE_E
    * @brief SDK与设备连接状态回调的消息类型 枚举定义 Exception callback message types Enumeration definition 
    * @attention 无 None
    */
    public enum NETDEV_ITS_STATUS_TYPE_E
    {
        /**设备状态上报类型 */
        /*异常状态类型*/
        NETDEV_ITS_DEV_OFFLINE = 0,            /*设备连接异常*/
        NETDEV_ITS_DEV_RONLINE = 1,            /*设备重连成功*/
        NETDEV_ITS_MEDIA_OFFLINE = 201,          /*媒体流连接异常*/
        NETDEV_ITS_MEDIA_RONLINE = 301,          /*媒体流重连成功*/
        NETDEV_ITS_STATUS_USERINFO_CHANGE = 3,            /*用户信息修改 */
        NETDEV_ITS_STATUS_WORKMODE_CHANGE = 5,            /*用户工作模式修改*/

        /*信息状态类型*/
        NETDEV_ITS_STATUS_TRAFFICLIGHT = 155,          /**< 信号灯实时在线状态  对应参数参见: NETDEV_ITS_TRAFFIClIGHT_STATUS_E */
        //NETDEV_ITS_STATUS_DETECTED_ACTIVITY_E           = 2,          /**< 运动检测区域运动量，对应参数参见: NETDEV_ITS_MOTION_ACTIVITY_INFO_S */
        NETDEV_ITS_STATUS_MANAGE_SERVER_ONLINE = 50,           /**< 管理服务器的连接状态，对应参数参见: NETDEV_ITS_SERVER_TYPE */
        NETDEV_ITS_STATUS_PHOTO_SERVER_ONLINE = 51,           /**< 照片服务器的连接状态，对应参数参见: NETDEV_ITS_SERVER_TYPE*/
        NETDEV_ITS_STATUS_NETWORK_CHANGE = 54,           /**< 网口配置结果，对应参数参见: NETDEV_ITS_IPCONFLICT_TYPE_E 等 */
        NETDEV_ITS_STATUS_PORTMAP_CHANGE = 59,           /**< UPNP端口映射状态改变标志位, 对应参数参见: NETDEV_ITS_PORTMAP_TYPE */
        NETDEV_ITS_STATUS_DDNS_DOMAIN_CHECK_RESULT = 61,          /**< DDNS域名检测完成，对应参数参见: NETDEV_ITS_DDNS_TYPE */
        NETDEV_ITS_STATUS_STOR_MEMORY_CARD_FORMAT = 90,          /**< 本地存储设备格式化状态， 对应参数参见: NETDEV_ITS_SD_TYPE */
        NETDEV_ITS_STATUS_STOR_NAS_MOUNT = 91,           /**< NAS挂载状态 状态码为: ERR_COMMON_SUCCEED等 */
        NETDEV_ITS_STATUS_PTZ = 100,          /**< 云台状态，对应参数类型: NETDEV_ITS_PTZ_STATUS_S */
        NETDEV_ITS_STATUS_SCENE_CURRENT = 120,          /**< 场景自动切换的当前场景ID, 对应参数类型: ULONG */
        NETDEV_ITS_STATUS_SERIALINPUTDATA = 133,          /**< 串口输入OSD数据，对应参数为字符串szCOMOSD */
        NETDEV_ITS_STATUS_COIL = 151,          /**< 线圈状态  对应参数参见: NETDEV_ITS_COIL_STATE_S*/
        NETDEV_ITS_STATUS_RADAR = 150,          /**< 雷达状态  对应参数参见: NETDEV_ITS_RADAR_STATUS_TYPE */
        NETDEV_ITS_STATUS_POLARIZER = 152,          /**< 偏振镜状态  对应参见参见: NETDEV_ITS_POLARIZER_TYPE */
        NETDEV_ITS_STATUS_LED_STROBE = 153,          /**< LED灯状态  对应参见参见: NETDEV_ITS_LEDSTROBE_TYPE */
        NETDEV_ITS_STATUS_ND_FILTER = 154,          /**< ND滤镜状态  对应参数参见: NETDEV_ITS_POLARIZER_TYPE */
        NETDEV_ITS_STATUS_SD = 156,          /**< SD卡状态  对应参数参见: NETDEV_ITS_SD_TYPE */
        NETDEV_ITS_STATUS_CAPTURE = 157,          /**< 抓拍上报 对应参数参见:NETDEV_ITS_CAPTURE_TYPE */
        NETDEV_ITS_STATUS_TRAFFICLIGHT_COLOUR = 158,          /**< 红绿灯状态,对应参数参见:NETDEV_ITS_TRAFFICLIGHT_DIRECT_MODE */
        NETDEV_ITS_STATUS_IVA_ILLEGAL_DETECT_REPORT = 159,          /**< 抓拍检测上报 对应参数参见:NETDEV_ITS_IVA_ILLEGAL_DETECT_REPORT_S */
        NETDEV_ITS_STATUS_IVA_PARK_STATUS_REPORT = 160,          /**< 车位状态上报 对应参数参见:NETDEV_ITS_PARK_STATUS_S */
        NETDEV_ITS_STATUS_IVA_PARK_ALARM_REPORT = 161,          /**< 车位告警上报 对应参数参见:NETDEV_ITS_PARK_ALARM_S */
        NETDEV_ITS_STATUS_IVA_PERSON_COUNT_REPORT = 163,          /**< 人数统计上报 对应参数参见:NETDEV_ITS_PERSON_COUNT_INFO_S */
        NETDEV_ITS_STATUS_IVA_PARK_STATUS_REPORT_EX = 164,          /**< 车位状态上报扩展 对应参数参见:NETDEV_ITS_PARK_STATUS_EX_S */
        NETDEV_ITS_STATUS_TRAFFIC_PARAM_REPORT = 169,          /**< 交通参数上报 对应参数参见:NETDEV_ITS_TRAFFIC_PARA_RSLT_S */
        NETDEV_ITS_STATUS_VEHICLE_PARAM_REPORT = 170,          /**< 车辆进出状态上报 对应参数参见:NETDEV_ITS_VEHICLE_STATE_S */

        NETDEV_ITS_STATUS_INVALID = 0xFFFF                 /* 无效值  Invalid value */
    }

}
