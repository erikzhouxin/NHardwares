namespace System.Data.YuShiITSSDK
{
    /**
   * @brief  Exception callback message types Enumeration definition 
   * @attention None
   */
    public enum NETDEV_ITS_STATUS_REPORT_E
    {

        /*Abnormal status types*/
        NETDEV_ITS_DEV_OFFLINE_E = 0,              /*Device connection abnormal*/
        NETDEV_ITS_DEV_RONLINE_E = 1,              /*Device reconnection succeeded*/
        NETDEV_ITS_MEDIA_OFFLINE_E = 201,          /*Media stream disconnected*/
        NETDEV_ITS_MEDIA_RONLINE_E = 301,          /*Media stream re-connected successfully*/
        NETDEV_ITS_STATUS_USERINFO_CHANGE_E = 3,            /*User info changed*/
        NETDEV_ITS_STATUS_WORKMODE_CHANGE_E = 5,            /*User’s working mode changed*/

        /*Info status types*/
        NETDEV_ITS_STATUS_TRAFFICLIGHT_E = 155,          /**< Signal light’s real-time online status See: NETDEV_ITS_TRAFFIClIGHT_TYPE_E */
        //NETDEV_ITS_STATUS_DETECTED_ACTIVITY_E           = 2,          /**< Amount of activity inside motion detection area See: NETDEV_ITS_MOTION_ACTIVITY_INFO_S */
        NETDEV_ITS_STATUS_MANAGE_SERVER_ONLINE_E = 50,           /**< Management server's connection status See: NETDEV_ITS_SERVER_TYPE_E */
        NETDEV_ITS_STATUS_PHOTO_SERVER_ONLINE_E = 51,           /**< Photo server’s connection status See: NETDEV_ITS_SERVER_TYPE_E*/
        NETDEV_ITS_STATUS_NETWORK_CHANGE_E = 54,           /**< Network interface configuration result See: NETDEV_ITS_IPCONFLICT_TYPE_E 等 */
        NETDEV_ITS_STATUS_PORTMAP_CHANGE_E = 59,           /**< Flag indicting changing UPnP port mapping status See: NETDEV_ITS_PORTMAP_TYPE_E */
        NETDEV_ITS_STATUS_DDNS_DOMAIN_CHECK_RESULT_E = 61,          /**< DDNS domain name detection completed See: NETDEV_ITS_DDNS_TYPE_E */
        NETDEV_ITS_STATUS_STOR_MEMORY_CARD_FORMAT_E = 90,         /**< Formatting status of local storage device See: NETDEV_ITS_SD_TYPE_E */
        NETDEV_ITS_STATUS_STOR_NAS_MOUNT_E = 91,           /**< NAS mount status code is: ERR_COMMON_SUCCEED */
        NETDEV_ITS_STATUS_PTZ_E = 100,          /**< PTZ status, corresponding parameter type: NETDEV_ITS_PTZ_STATUS_S */
        NETDEV_ITS_STATUS_SCENE_CURRENT_E = 120,          /**< Current scene ID: ULONG */
        NETDEV_ITS_STATUS_SERIALINPUTDATA_E = 133,          /**< OSD data input through serial port*/
        NETDEV_ITS_STATUS_COIL_E = 151,          /**< Coil status, array of NETDEV_ITS_COIL_STATE_S , up to 8 allowed*/
        NETDEV_ITS_STATUS_RADAR_E = 150,          /**< Radar status: ULONG */
        NETDEV_ITS_STATUS_POLARIZER_E = 152,          /**< Polarizer status: NETDEV_ITS_POLARIZER_TYPE_E */
        NETDEV_ITS_STATUS_LED_STROBE_E = 153,          /**< LED light status: NETDEV_ITS_LEDSTROBE_TYPE_E */
        NETDEV_ITS_STATUS_ND_FILTER_E = 154,          /**< ND filter status: NETDEV_ITS_POLARIZER_TYPE_E */
        NETDEV_ITS_STATUS_SD_E = 156,          /**< SD card status: NETDEV_ITS_SDSTATUS_TYPE_E */
        NETDEV_ITS_STATUS_CAPTURE_E = 157,          /**< Capture report type:NETDEV_ITS_CAPTURE_TYPE_E */
        NETDEV_ITS_STATUS_TRAFFICLIGHT_COLOUR_E = 158,          /**< Traffic light status. Corresponding parameter: ULONG: from low to high, byte0=right turn light, byte1= straight ahead light, byte2=left turn light */
        NETDEV_ITS_STATUS_IVA_ILLEGAL_DETECT_REPORT_E = 159,          /**<NETDEV_ITS_IVA_ILLEGAL_DETECT_REPORT_S */
        NETDEV_ITS_STATUS_IVA_PARK_STATUS_REPORT_E = 160,          /**< Struct of parking lot status report: NETDEV_ITS_PARK_STATUS_S */
        NETDEV_ITS_STATUS_IVA_PARK_ALARM_REPORT_E = 161,          /**< Struct of parking lot alarm report: NETDEV_ITS_PARK_ALARM_S */
        NETDEV_ITS_STATUS_IVA_PERSON_COUNT_REPORT_E = 163,          /**< Struct of people counting report: NETDEV_ITS_PERSON_COUNT_INFO_S */
        NETDEV_ITS_STATUS_IVA_PARK_STATUS_REPORT_EX_E = 164,          /**< Struct of extended parking lot status report:NETDEV_ITS_PARK_STATUS_EX_S */
        NETDEV_ITS_STATUS_TRAFFIC_PARAM_REPORT_E = 169,          /**< Struct of traffic parameters report: NETDEV_ITS_TRAFFIC_PARA_RSLT_S */
        NETDEV_ITS_STATUS_VEHICLE_PARAM_REPORT_E = 170,          /**< Struct of vehicle entry/exit status report: NETDEV_ITS_VEHICLE_STATE_S */

        NETDEV_ITS_STATUS_INVALID = 0xFFFF        /*Invalid value */
    }

}
