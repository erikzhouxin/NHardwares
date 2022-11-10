namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_CONFIG_COMMAND_E
    {
        NETDEV_GET_DEVICECFG = 100,            /* #NETDEV_DEVICE_INFO_S  Get device information, see #NETDEV_DEVICE_INFO_S */
        NETDEV_SET_DEVICECFG = 101,

        NETDEV_GET_NTPCFG = 110,            /* NTP#NETDEV_SYSTEM_NTP_INFO_S  Get NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */
        NETDEV_SET_NTPCFG = 111,            /* NTP#NETDEV_SYSTEM_NTP_INFO_S  Set NTP parameter, see #NETDEV_SYSTEM_NTP_INFO_S */

        NETDEV_GET_STREAMCFG = 120,            /* #NETDEV_VIDEO_STREAM_INFO_S  Get video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */
        NETDEV_SET_STREAMCFG = 121,            /* #NETDEV_VIDEO_STREAM_INFO_S  Set video encoding parameter, see #NETDEV_VIDEO_STREAM_INFO_S */

        NETDEV_GET_PTZPRESETS = 130,            /* #NETDEV_PTZ_ALLPRESETS_S  Get PTZ preset, see #NETDEV_PTZ_ALLPRESETS_S */

        NETDEV_GET_OSDCFG = 140,            /* OSD#NETDEV_VIDEO_OSD_CFG_S  Get OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */
        NETDEV_SET_OSDCFG = 141,            /* OSD#NETDEV_VIDEO_OSD_CFG_S  Set OSD configuration information, see #NETDEV_VIDEO_OSD_CFG_S */

        NETDEV_GET_OSD_CONTENT_CFG = 144,              /* 获取OSD配置信息(扩展，建议使用),参见#NETDEV_OSD_CONTENT_S  Get OSD configuration information, see #NETDEV_OSD_CONTENT_S */
        NETDEV_SET_OSD_CONTENT_CFG = 145,              /* 设置OSD配置信息(扩展，建议使用),参见#NETDEV_OSD_CONTENT_S  Set OSD configuration information, see #NETDEV_OSD_CONTENT_S */
        NETDEV_GET_OSD_CONTENT_STYLE_CFG = 146,              /* 获取OSD内容样式,参见#NETDEV_OSD_CONTENT_STYLE_S  Get OSD content style, see #NETDEV_OSD_CONTENT_STYLE_S */
        NETDEV_SET_OSD_CONTENT_STYLE_CFG = 147,              /* 设置OSD内容样式,参见#NETDEV_OSD_CONTENT_STYLE_S  Set OSD content style, see #NETDEV_OSD_CONTENT_STYLE_S */

        NETDEV_GET_ALARM_OUTPUTCFG = 150,            /* #NETDEV_ALARM_OUTPUT_LIST_S  Get boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_SET_ALARM_OUTPUTCFG = 151,            /* #NETDEV_ALARM_OUTPUT_LIST_S       Set boolean configuration information, see #NETDEV_ALARM_OUTPUT_LIST_S */
        NETDEV_TRIGGER_ALARM_OUTPUT = 152,            /* LPNETDEV_TRIGGER_ALARM_OUTPUT_LIST_S  Trigger boolean    LPNETDEV_TRIGGER_ALARM_OUTPUT_LIST_S */
        NETDEV_GET_ALARM_INPUTCFG = 153,            /* #NETDEV_ALARM_INPUT_INFO_S Get the number of boolean inputs   see #NETDEV_ALARM_INPUT_INFO_S*/

        NETDEV_GET_IMAGECFG = 160,            /* #NETDEV_IMAGE_SETTING_S  Get image configuration information, see #NETDEV_IMAGE_SETTING_S */
        NETDEV_SET_IMAGECFG = 161,            /* #NETDEV_IMAGE_SETTING_S  Set image configuration information, see #NETDEV_IMAGE_SETTING_S */

        NETDEV_GET_NETWORKCFG = 170,            /* #NETDEV_IMAGE_SETTING_S  Get network configuration information, see #NETDEV_IMAGE_SETTING_S */
        NETDEV_SET_NETWORKCFG = 171,            /* #NETDEV_IMAGE_SETTING_S  Set network configuration information, see #NETDEV_IMAGE_SETTING_S */

        NETDEV_GET_PRIVACYMASKCFG = 180,            /* #NETDEV_PRIVACY_MASK_CFG_S  Get privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_SET_PRIVACYMASKCFG = 181,            /* #NETDEV_PRIVACY_MASK_CFG_S  Set privacy mask configuration information, see #NETDEV_PRIVACY_MASK_CFG_S */
        NETDEV_DELETE_PRIVACYMASKCFG = 182,            /* Delete privacy mask configuration information */

        NETDEV_GET_TAMPERALARM = 190,            /*  Get tamper alarm configuration information, see#NETDEV_TAMPER_ALARM_INFO_S */
        NETDEV_SET_TAMPERALARM = 191,            /*  Set tamper alarm configuration information, see#NETDEV_TAMPER_ALARM_INFO_S */

        NETDEV_GET_MOTIONALARM = 201,            /* Get motion alarm configuration information, see#NETDEV_MOTION_ALARM_INFO_S */
        NETDEV_SET_MOTIONALARM = 202,             /*  Set motion alarm configuration information, see#NETDEV_MOTION_ALARM_INFO_S */

        NETDEV_GET_DISKSINFO = 211,              /* 获取硬盘信息 参见#NETDEV_GET_DISKS_INFO_S  Get disks information, see#NETDEV_GET_DISKS_INFO_S */

        NETDEV_GET_PARKSTATUSINFO = 1000,              /* 获取车位状态信息 参见#NETDEV_PARKSTATUS_INFO_S */

        NETDEV_GET_CARPORTCFG = 1010,             /* 获取车位信息 参见#NETDEV_CARPORT_CFG_S */
        NETDEV_SET_CARPORTCFG = 1011,             /* 设置车位信息 参见#NETDEV_CARPORT_CFG_S */

        NETDEV_GET_CARPORTCFG_EX = 1012,             /* 获取车位信息(扩展，建议使用), 参见#NETDEV_ITS_PARKING_DETECTION_S */
        NETDEV_SET_CARPORTCFG_EX = 1013,             /* 设置车位信息(扩展，建议使用), 参见#NETDEV_ITS_PARKING_DETECTION_S */

        NETDEV_GET_OSDSTYLECFG = 1020,              /* 获取叠加OSD样式配置 参见 NETDEV_OSDSTYLE_CFG_S */
        NETDEV_SET_OSDSTYLECFG = 1021,              /* 设置叠加OSD样式配置 参见 NETDEV_OSDSTYLE_CFG_S */

        NETDEV_GET_INFOOSDCFG = 1030,              /* 获取叠加OSD配置 参见 NETDEV_INFOOSD_CFG_S */
        NETDEV_SET_INFOOSDCFG = 1031,              /* 设置叠加OSD配置 参见 NETDEV_INFOOSD_CFG_S */

        NETDEV_GET_ACCPLICINFO = 1040,             /* 获取访问策略 参见 NETDEV_ACCPLIC_INFO_S */
        NETDEV_SET_ACCPLICINFO = 1041,             /* 设置访问策略 参见 NETDEV_ACCPLIC_INFO_S */

        NETDEV_GET_EXPOSURE_CFG_S = 1050,             /*设置图像曝光参数宽动态控制 */
        NETDEV_SET_EXPOSURE_CFG_S = 1051,             /*获取图像曝光参数宽动态控制 */

        NETDEV_GET_TELENTCONFIG = 1060,            /*获取图像宽动态*/
        NETDEV_SET_TELENTCONFIG = 1061,             /*设置图像宽动态*/

        NETDEV_GET_IRCUT = 1070,             /*获取白片彩片的切换 */
        NETDEV_SET_IRCUT = 1071,             /*设置白片彩片的切换 */

        NETDEV_GET_IMGENHANCE = 1080,             /*获取图像参数 */
        NETDEV_SET_IMGENHANCE = 1081,             /*设置图像参数 */

        NETDEV_GET_IMGCLARDATA = 1090,             /*获取图像清晰度 */
        NETDEV_SET_IMGCLARDATA = 1091,             /*设置图像清晰度*/

        NETDEV_SET_IMGSWITCHCHANNEL = 2000,             /*图像通道的切换 */

        NETDEV_GET_INFORELEASE = 2010,             /* 获取名单配置，放行策略 参见  */
        NETDEV_SET_INFORELEASE = 2011,             /* 设置名单配置，放行策略 参见  */

        NETDEV_GET_INFOWLIST = 2020,             /* 获取名单配置，出入白名单 参见  */
        NETDEV_SET_INFOWLIST = 2021,             /* 设置名单配置，出入白名单 参见  */

        NETDEV_GET_INFOBLIST = 2030,             /* 获取名单配置，出入黑名单 参见  */
        NETDEV_SET_INFOBLIST = 2031,             /* 设置名单配置，出入黑名单 参见  */

        NETDEV_GET_CARPORT_LED_CTRL = 2040,              /* 获取车位内置指示灯控制 参见 NETDEV_CARPORT_CONTROLLED_S (需关闭http鉴权)*/
        NETDEV_SET_CARPORT_LED_CTRL = 2041,              /* 设置车位内置指示灯控制 参见 NETDEV_CARPORT_CONTROLLED_S (需关闭http鉴权)*/

        NETDEV_GET_INSTALL_GUIDE_CFG = 2050,              /* 获取出入口安装向导配置 参见 NETDEV_INSTALL_GUIDE_CFG_S */
        NETDEV_SET_INSTALL_GUIDE_CFG = 2051,              /* 设置出入口安装向导配置 参见 NETDEV_INSTALL_GUIDE_CFG_S */


        NETDEV_CFG_INVALID = 0xFFFF            /*   Invalid value */
    };

}
