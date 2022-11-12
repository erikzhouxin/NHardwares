namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_CONFIG_COMMAND_E
    {
        NETDEV_GET_DEVICECFG = 100,              /* #NETDEV_DEVICE_BASICINFO_S  Get device information, see #NETDEV_DEVICE_BASICINFO_S */
        NETDEV_SET_DEVICECFG = 101,              /* Reserved */

        NETDEV_GET_NTPCFG = 110,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_S  Get NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */
        NETDEV_SET_NTPCFG = 111,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_S  Set NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */

        NETDEV_GET_NTPCFG_EX = 112,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_LIST_S  Get NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_LIST_S */
        NETDEV_SET_NTPCFG_EX = 113,              /* NTP,#NETDEV_SYSTEM_NTP_INFO_LIST_S  Set NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_LIST_S */

        NETDEV_GET_STREAMCFG = 120,              /* #NETDEV_VIDEO_STREAM_INFO_S  Get video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */
        NETDEV_SET_STREAMCFG = 121,              /* #NETDEV_VIDEO_STREAM_INFO_S  Set video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */

        NETDEV_GET_STREAMCFG_EX = 122,              /* #NETDEV_VIDEO_STREAM_INFO_LIST_S  Get video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_LIST_S */
        NETDEV_SET_STREAMCFG_EX = 123,              /* #NETDEV_VIDEO_STREAM_INFO_LIST_S  Set video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_LIST_S */

        NETDEV_GET_VIDEOMODECFG = 124,              /* #NETDEV_VIDEO_MODE_INFO_S */
        NETDEV_SET_VIDEOMODECFG = 125,              /* #NETDEV_VIDEO_MODE_INFO_S */

        NETDEV_GET_PTZPRESETS = 130,              /* #NETDEV_PTZ_ALLPRESETS_S  Get PTZ preset, see #NETDEV_PTZ_ALLPRESETS_S */

        NETDEV_GET_OSDCFG = 140,              /* OSD,#NETDEV_VIDEO_OSD_CFG_S  Get OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */
        NETDEV_SET_OSDCFG = 141,              /* OSD,#NETDEV_VIDEO_OSD_CFG_S  Set OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */

        NETDEV_GET_OSD_CONTENT_CFG = 144,              /* #NETDEV_OSD_CONTENT_S  Get OSD configuration information, see #NETDEV_OSD_CONTENT_S */
        NETDEV_SET_OSD_CONTENT_CFG = 145,              /* #NETDEV_OSD_CONTENT_S  Set OSD configuration information, see #NETDEV_OSD_CONTENT_S */
        NETDEV_GET_OSD_CONTENT_STYLE_CFG = 146,              /* #NETDEV_OSD_CONTENT_STYLE_S  Get OSD content style, see #NETDEV_OSD_CONTENT_STYLE_S */
        NETDEV_SET_OSD_CONTENT_STYLE_CFG = 147,              /* #NETDEV_OSD_CONTENT_STYLE_S  Set OSD content style, see #NETDEV_OSD_CONTENT_STYLE_S */

        NETDEV_GET_ALARM_OUTPUTCFG = 150,              /* #NETDEV_ALARM_OUTPUT_LIST_S  Get boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_SET_ALARM_OUTPUTCFG = 151,              /* #NETDEV_ALARM_OUTPUT_LIST_S  Set boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_TRIGGER_ALARM_OUTPUT = 152,              /* #NETDEV_TRIGGER_ALARM_OUTPUT_S        Trigger boolean, see #NETDEV_TRIGGER_ALARM_OUTPUT_S */
        NETDEV_GET_ALARM_INPUTCFG = 153,              /* #NETDEV_ALARM_INPUT_LIST_S   Get the number of boolean inputs, see #NETDEV_ALARM_INPUT_LIST_S */
        NETDEV_GET_MANUAL_ALARM_CFG = 154,              /* #NETDEV_OUTPUT_SWITCH_ALARM_STATUS_LIST_S  Get manual alarm boolean configuration information, see #NETDEV_OUTPUT_SWITCH_ALARM_STATUS_LIST_S*/
        NETDEV_SET_MANUAL_ALARM_CFG = 155,              /* #NETDEV_OUTPUT_SWITCH_MANUAL_ALARM_INFO_S  Set manual alarm boolean configuration information, see #NETDEV_OUTPUT_SWITCH_MANUAL_ALARM_INFO_S */

        NETDEV_GET_IMAGECFG = 160,              /* #NETDEV_IMAGE_SETTING_S  Get image configuration information, see #NETDEV_IMAGE_SETTING_S */
        NETDEV_SET_IMAGECFG = 161,              /* #NETDEV_IMAGE_SETTING_S  Set image configuration information, see #NETDEV_IMAGE_SETTING_S */

        NETDEV_GET_NETWORKCFG = 170,              /* #NETDEV_NETWORKCFG_S  Get network configuration information, see #NETDEV_NETWORKCFG_S */
        NETDEV_SET_NETWORKCFG = 171,              /* #NETDEV_NETWORKCFG_S  Set network configuration information, see #NETDEV_NETWORKCFG_S */

        NETDEV_GET_PRIVACYMASKCFG = 180,              /* #NETDEV_PRIVACY_MASK_CFG_S  Get privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_SET_PRIVACYMASKCFG = 181,              /* #NETDEV_PRIVACY_MASK_CFG_S  Set privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_DELETE_PRIVACYMASKCFG = 182,              /* Delete privacy mask configuration information */

        NETDEV_GET_TAMPERALARM = 190,              /* #NETDEV_TAMPER_ALARM_INFO_S  Get tamper alarm configuration information, see #NETDEV_TAMPER_ALARM_INFO_S */
        NETDEV_SET_TAMPERALARM = 191,              /* #NETDEV_TAMPER_ALARM_INFO_S  Set tamper alarm configuration information, see #NETDEV_TAMPER_ALARM_INFO_S */

        NETDEV_GET_MOTIONALARM = 200,              /* #NETDEV_MOTION_ALARM_INFO_S  Get motion alarm configuration information, see #NETDEV_MOTION_ALARM_INFO_S */
        NETDEV_SET_MOTIONALARM = 201,              /* #NETDEV_MOTION_ALARM_INFO_S  Set motion alarm configuration information, see #NETDEV_MOTION_ALARM_INFO_S */

        NETDEV_GET_CROSSLINEALARM = 202,              /* #NETDEV_CROSS_LINE_ALARM_INFO_S Get Cross Line alarm configuration information, see #NETDEV_CROSS_LINE_ALARM_INFO_S*/
        NETDEV_SET_CROSSLINEALARM = 203,              /* #NETDEV_CROSS_LINE_ALARM_INFO_S Set Cross Line alarm configuration information, see #NETDEV_CROSS_LINE_ALARM_INFO_S*/

        NETDEV_GET_INTRUSIONALARM = 204,              /* #NETDEV_INTRUSION_ALARM_INFO_S Get intrusion alarm configuration information, see #NETDEV_INTRUSION_ALARM_INFO_S*/
        NETDEV_SET_INTRUSIONALARM = 205,              /* #NETDEV_INTRUSION_ALARM_INFO_S Set intrusion alarm configuration information, see #NETDEV_INTRUSION_ALARM_INFO_S*/

        NETDEV_GET_DISKSINFO = 210,              /* #NETDEV_GET_DISKS_INFO_S  Get disks information, see #NETDEV_GET_DISKS_INFO_S */

        NETDEV_GET_FOCUSINFO = 230,              /* #NETDEV_FOCUS_INFO_S Get focus info, see #NETDEV_FOCUS_INFO_S */
        NETDEV_SET_FOCUSINFO = 231,              /* #NETDEV_FOCUS_INFO_S Set focus info, see #NETDEV_FOCUS_INFO_S */

        NETDEV_GET_IRCUTFILTERINFO = 240,              /* #NETDEV_IRCUT_FILTER_INFO_S Get IRcut filter info, see #NETDEV_IRCUT_FILTER_INFO_S */
        NETDEV_SET_IRCUTFILTERINFO = 241,              /* #NETDEV_IRCUT_FILTER_INFO_S Set IRcut filter info, see #NETDEV_IRCUT_FILTER_INFO_S */

        NETDEV_GET_DEFOGGINGINFO = 250,              /* #NETDEV_DEFOGGING_INFO_S Get defogging info, see #NETDEV_DEFOGGING_INFO_S */
        NETDEV_SET_DEFOGGINGINFO = 251,              /* #NETDEV_DEFOGGING_INFO_S Set defogging info, see #NETDEV_DEFOGGING_INFO_S */

        NETDEV_GET_RECORDPLANINFO = 252,              /* #NETDEV_RECORD_PLAN_CFG_INFO_S */
        NETDEV_SET_RECORDPLANINFO = 253,              /* #NETDEV_RECORD_PLAN_CFG_INFO_S */

        NETDEV_GET_DST_CFG = 260,              /* #NETDEV_DST_CFG_S Get defogging info, see #NETDEV_DST_CFG_S */
        NETDEV_SET_DST_CFG = 261,              /* #NETDEV_DST_CFG_S Set defogging info, see #NETDEV_DST_CFG_S */

        NETDEV_GET_AUDIOIN_CFG = 262,              /* #NETDEV_AUDIO_INPUT_CFG_INFO_S get audio input config info see #NETDEV_AUDIO_INPUT_CFG_INFO_S */
        NETDEV_SET_AUDIOIN_CFG = 263,              /* #NETDEV_AUDIO_INPUT_CFG_INFO_S set audio input config info see #NETDEV_AUDIO_INPUT_CFG_INFO_S */

        NETDEV_SET_DNS_CFG = 270,              /* #NETDEV_DNS_INFO_S Set DNS info see #NETDEV_DNS_INFO_S*/
        NETDEV_GET_DNS_CFG = 271,              /* #NETDEV_DNS_INFO_S Get DNS info see #NETDEV_DNS_INFO_S*/

        NETDEV_SET_NETWORK_CARDS = 272,              /* #NETDEV_NETWORK_CARD_INFO_S set device networkcards infos see #NETDEV_NETWORK_CARD_INFO_S*/
        NETDEV_GET_NETWORK_CARDS = 273,              /* #NETDEV_NETWORK_CARD_INFO_S get device networkcards infos see #NETDEV_NETWORK_CARD_INFO_S*/

        NETDEV_GET_RECORD_STATUS = 320,              /* 获取录像状态信息 参见#NETDEV_RECORD_STATUS_LIST_S  Get video status information*/

        NETDEV_GET_RAID_STATUS = 470,              /* 获取阵列状态 参见#NETDEV_RAID_STATUS_S */
        NETDEV_GET_RAID_STORAGE_CONTAINER_INFO_LIST = 471,      /* 先使用NETDEV_GET_RAID_STATUS命令获取阵列状态，阵列状态使能时，获取存储容器信息列表 参见#NETDEV_HDD_INFO_LIST_S */
        NETDEV_GET_STORAGE_CONTAINER_INFO_LIST = 472,           /* 先使用NETDEV_GET_RAID_STATUS命令获取阵列状态，阵列状态不使能时，获取存储容器信息列表 参见#NETDEV_STORAGE_CONTAINER_INFO_LIST_S */
        NETDEV_GET_HDD_SMART_INFO = 473,           /* 获取指定硬盘的Smart检测信息 参见#NETDEV_HDD_SMART_INFO_S */


        NETDEV_CFG_INVALID = 0xFFFF            /* Invalid value */

    }

}
