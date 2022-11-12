using System;
using System.Collections.Generic;
using System.Data.HardwareInterfaces;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.YuShiITSSDK
{
    /// <summary>
    /// 智能交通SDK
    /// </summary>
    public static class ItsNetDevSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const string DllFileName = "NetDEVSDK.dll";
        /// <summary>
        /// 基路径
        /// </summary>
        public static String BaseDllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 基路径全称
        /// </summary>
        public static String BaseDllFullName { get; } = Path.GetFullPath(DllFileName);
        /// <summary>
        /// SDK虚拟路径
        /// </summary>
        public const String DllVirtualPath = @"plugins\yushiitssdk";
        /// <summary>
        /// SDK全路径
        /// </summary>
        public static String DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        /// <summary>
        /// SDK全名称
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(DllFullPath, DllFileName);
        public const int NETDEV_MODEL_LEN_64 = 64;

        public const int REAL_PANEL_MAX_SIZE = 16;//16
        public const int PLAYBACK_PANEL_MAX_SIZE = 4;

        public const int NETDEV_USERNAME_LEN_260 = 260;
        public const int NETDEV_SERIAL_NUMBER_LEN_64 = 64;

        /*TreeView*/
        public const int NETDEV_TREEVIEW_IMAGE_ROOT = 0;
        public const int NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON = 1;
        public const int NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF = 2;
        public const int NETDEV_TREEVIEW_IMAGE_CLOUD_DEVICE_ON = 3;
        public const int NETDEV_TREEVIEW_IMAGE_CLOUD_DEVICE_OFF = 4;
        public const int NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON = 5;
        public const int NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF = 6;
        public const int NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON = 7;
        public const int NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF = 8;
        public const int NETDEV_TREEVIEW_IMAGE_ORG = 9;

        public const int NETDEMO_DOWNLOAD_TIME_COUNT = 5;

        public static bool NETDEMO_DOWNLOAD_TIMER_MUX_FLAG = false;
        public static bool NETDEMO_DOWNLOAD_TIMER_STOP_ALL = false;

        //public static bool NETDEMO_SELECTED_CHANGED_FlAG = true;

        public static NETDEMO_ALARM_INFO[] gastNETDemoAlarmInfo =
        {
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MOVE_DETECT,"Motion detection alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MOVE_DETECT_RECOVER,"Motion detection alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST,"Video loss alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_TAMPER_DETECT,"Tampering detection alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_TAMPER_RECOVER,"Tampering detection alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_INPUT_SWITCH,"Boolean input alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_TEMPERATURE_HIGH,"High temperature alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_TEMPERATURE_LOW,"Low temperature alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_AUDIO_DETECT,"Audio detection alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_INPUT_SWITCH_RECOVER,"Boolean input alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST_RECOVER,"Video loss alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_REBOOT,"Device restart"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_SERVICE_REBOOT,"Service restart"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_ONLINE,"Device online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_OFFLINE,"Device offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_DELETE_CHL,"Delete channel"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_FAILED,"Network timeout"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SHAKE_FAILED,"Interaction error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_TIMEOUT,"Network error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_OFFLINE,"Disk offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ONLINE,"Disk online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MEDIA_CONFIG_CHANGE,"Media configuration changed"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REMAIN_ARTICLE,"Remain article"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_PEOPLE_GATHER,"People gather alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ENTER_AREA,"Enter area"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_LEAVE_AREA,"Leave area"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ARTICLE_MOVE,"Article move"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ABNORMAL,"Disk abnormal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ABNORMAL_RECOVER,"Disk abnormal recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_WILL_FULL,"Disk storage will full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_WILL_FULL_RECOVER,"Disk storage will full recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_IS_FULL,"Disk storage is full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_STORAGE_IS_FULL_RECOVER,"Disk storage is full recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DISABLED,"RAID disabled"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DISABLED_RECOVER,"RAID disabled recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DEGRADED,"RAID degraded"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_DEGRADED_RECOVER,"RAID degraded recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_RAID_RECOVERED,"RAID recovered"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STREAMNUM_FULL,"Stream full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STREAM_THIRDSTOP,"Third party stream stopped"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_FILE_END,"File ended"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_RTMP_CONNECT_FAIL,"RTMP connection fail"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_RTMP_INIT_FAIL,"RTMP initialization fail"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_ERR,"Storage error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_DISOBEY_PLAN,"Not stored as planned"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DISK_ERROR,"Disk error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ILLEGAL_ACCESS,"Illegal access"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ALLTIME_FLAG_END,"End marker of alarm without arming schedule"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST_RECOVER,"Video loss alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_TEMPERATURE_RECOVER,"Temperature alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_AUDIO_DETECT_RECOVER,"Audio detection alarm recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_ERR_RECOVER,"Storage error recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_DISOBEY_PLAN_RECOVER,"Not stored as planned recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IMAGE_BLURRY_RECOVER,"Image blurry recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_TRACK_RECOVER,"Smart track recover"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_VOD_END,"Playback ended"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_VOD_ABEND,"Playback exception occured"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_END,"Backup ended"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT,"Disk removed"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL,"Disk full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_REPORT_BACKUP_ABEND,"Backup failure caused by other reasons"),
            new NETDEMO_ALARM_INFO((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_EXCHANGE,"Exception occurred during user interaction new NETDEMO_ALARM_INFO((int)keep-alive timeout)"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWIDTH_CHANGE,"Bandwidth change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_LINE_CROSS,"Line cross"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_OBJECTS_INSIDE,"Objects inside"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_FACE_RECOGNIZE,"Face recognize"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IMAGE_BLURRY,"Image blurry"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SCENE_CHANGE,"Scene change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_TRACK,"Smart track"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_LOITERING_DETECTOR,"Loitering detector"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IP_CONFLICT,"IP conflict exception alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_IP_CONFLICT_CLEARED,"IP conflict exception alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_READ_ERROR_RATE,"Error reding the underlying data"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWIDTH_CHANGE,"Bandwidth change")
        };

        /*用于视频流配置质量Quality*/
        public static NETDEV_VIDEO_QUALITY_E[] gastVideoQualityMap =
        {
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L0,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L1,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L2,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L3,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L4,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L5,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L6,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L7,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L8,
            NETDEV_VIDEO_QUALITY_E.NETDEV_VQ_L9
        };

        public const int NETDEV_TMS_FACE_ID_LEN = 16;
        public const int NETDEV_TMS_FACE_POSITION_LEN = 32;
        public const int NETDEV_TMS_FACE_RECORD_ID_LEN = 32;
        public const int NETDEV_TMS_CAMER_ID_LEN = 32;
        public const int NETDEV_TMS_PASSTIME_LEN = 32;
        public const int NETDEV_TMS_FACE_TOLLGATE_ID_LEN = 32;

        /**********************************  Commonly used numerical macros *************** */

        public const int NETDEV_FACE_MEMBER_CUSTOM_LEN = 255;
        public const int NETDEV_LOG_QUERY_COND_NUM = 48;
        public const int NETDEV_FACE_MEMBER_REGION_LEN = 256;
        public const int NETDEV_FACE_IDNUMBER_LEN = 128;
        public const int NETDEV_FACE_MEMBER_NAME_LEN = 256;
        public const int NETDEV_FACE_MEMBER_BIRTHDAY_LEN = 31;
        public const int NETDEV_FACE_MEMBER_CUSTOM_NUM = 5;
        public const int NETDEV_MAX_LINK_ACTION_NUM = 9;
        public const int NETDEV_FACE_MONITOR_RULE_NAME_LEN = 508;
        public const int NETDEV_FACE_MONITOR_RULE_REASON_LEN = 508;
        public const int NETDEV_FACE_FEATURE_SIZE = 512;
        public const int NETDEV_TIME_TEMPLATE_NUM = 32;
        public const int NETDEV_TIME_RANGE_NUM = 8;
        public const int NETDEV_TIME_DURATION_NUM = 8;

        /* Length of stream ID*/
        public const int NETDEV_STREAM_ID_LEN = 32;

        /* Length of filename */
        public const uint NETDEV_FILE_NAME_LEN = (256u);

        /* Maximum length of username */
        public const int NETDEV_USER_NAME_LEN = 32;

        /* Maximum length of password */
        public const int NETDEV_PASSWD_LEN = 64;

        /* Length of password and encrypted passcode for user login */
        public const int NETDEV_PASSWD_ENCRYPT_LEN = 64;

        /* Length of resource code string */
        public const int NETDEV_RES_CODE_LEN = 48;

        /* Maximum length of domain name */
        public const int NETDEV_DOMAIN_LEN = 64;

        /* Maximum length of device name */
        public const int NETDEV_DEVICE_NAME_LEN = 32;

        /* Maximum length of path */
        public const int NETDEV_PATH_LEN_WITHOUT_NAME = 64;

        /* Maximum length of path, including filename */
        public const int NETDEV_PATH_LEN = 128;

        /* Maximum length of email address */
        public const int NETDEV_EMAIL_NAME_ADDR = 32;

        /* Length of MAC address */
        public const int NETDEV_MAC_ADDR_LEN = 6;

        /* Length of endpoint called by gSOAP */
        public const int NETDEV_ENDPOINT_LEN = 96;

        /* Maximum length of session ID */
        public const int NETDEV_SESSION_ID_LEN = 16;

        /* Maximum length of URL */
        public const int NDE_MAX_URL_LEN = 512;

        /* Maximum number of alarm inputs */
        public const int NETDEV_MAX_ALARM_IN_NUM = 64;

        /* Maximum number of alarm outputs */
        public const int NETDEV_MAX_ALARM_OUT_NUM = 64;

        /* Maximum number of people count */
        public const int NETDEV_PEOPLE_CNT_MAX_NUM = 60;

        /* Common length */
        public const int NETDEV_LEN_2 = 2;
        public const int NETDEV_LEN_4 = 4;
        public const int NETDEV_LEN_6 = 6;
        public const int NETDEV_LEN_8 = 8;
        public const int NETDEV_LEN_16 = 16;
        public const int NETDEV_LEN_32 = 32;
        public const int NETDEV_LEN_40 = 40;
        public const int NETDEV_LEN_64 = 64;
        public const int NETDEV_LEN_128 = 128;
        public const int NETDEV_LEN_132 = 132;
        public const int NETDEV_LEN_256 = 256;
        public const int NETDEV_LEN_260 = 260;
        public const int NETDEV_LEN_480 = 480;
        public const int NETDEV_LEN_512 = 512;
        public const int NETDEV_LEN_1024 = 1024;

        /* Length of IP address string */
        public const uint NETDEV_IPADDR_STR_MAX_LEN = (64u);

        /* Length of IPV4 address string */
        public const int NETDEV_IPV4_LEN_MAX = 16;

        /* Length of IPV6 address string */
        public const int NETDEV_IPV6_LEN_MAX = 128;

        /* Length of common name string */
        public const int NETDEV_NAME_MAX_LEN = 256;

        public const int NETDEV_DESCRIBE_MAX_LEN = (512 + 4);

        /* Length of common code */
        public const int NETDEV_CODE_STR_MAX_LEN = 256;

        /* Maximum length of date string "2008-10-02 09:25:33.001 GMT" */
        public const uint NETDEV_MAX_DATE_STRING_LEN = (64u);

        /* Length of time string "hh:mm:ss" */
        public const uint NETDEV_SIMPLE_TIME_LEN = (12u);

        /* Length of date string "YYYY-MM-DD"*/
        public const uint NETDEV_SIMPLE_DATE_LEN = (12u);

        /* Number of scheduled time sections in a day */
        public const int NETDEV_PLAN_SECTION_NUM = 8;

        /* Total number of plans allowed in a week, including Monday to Sunday, and holidays */
        public const int NETDEV_PLAN_NUM_AWEEK = 8;

        /* Maximum number of motion detection areas allowed */
        public const int NETDEV_MAX_MOTION_DETECT_AREA_NUM = 4;

        /* Maximum number of privacy mask areas allowed */
        public const int NETDEV_MAX_PRIVACY_MASK_AREA_NUM = 8;

        /* Maximum number of tamper-proof areas allowed */
        public const int NETDEV_MAX_TAMPER_PROOF_AREA_NUM = 1;

        /* Maximum number of text overlays allowed for a channel */
        public const int NETDEV_MAX_TEXTOVERLAY_NUM = 6;

        /* Maximum number of video streams */
        public const int NETDEV_MAX_VIDEO_STREAM_NUM = 8;

        /* Month of the year */
        public const int NETDEV_MONTH_OF_YEAR = 12;

        /* Day of the month */
        public const int NETDEV_DAYS_OF_MONTH = 32;

        /* Length of device ID */
        public const int NETDEV_DEV_ID_LEN = 64;

        /* Length of device serial number */
        public const int NETDEV_SERIAL_NUMBER_LEN = 32;

        /* Maximum number of queries allowed at a time */
        public const int NETDEV_MAX_QUERY_NUM = 200;

        /* Total number of queries allowed */
        public const int NETDEV_MAX_QUERY_TOTAL_NUM = 2000;

        /* Maximum number of IP cameras */
        public const int NETDEV_MAX_IPC_NUM = 128;

        /* Maximum number of presets */
        public const int NETDEV_MAX_PRESET_NUM = 255;

        /* Maximum number of presets for preset patrol */
        public const int NETDEV_MAX_CRUISEPOINT_NUM = 32;

        /* Maximum number of routes for preset patrol */
        public const int NETDEV_MAX_CRUISEROUTE_NUM = 16;

        /* PTZ rotating speed */
        public const int NETDEV_MIN_PTZ_SPEED_LEVEL = 1;
        public const int NETDEV_MAX_PTZ_SPEED_LEVEL = 9;

        /* Maximum / Minimum values for image parameters (brightness, contrast, hue, saturation) */
        public const int NETDEV_MAX_VIDEO_EFFECT_VALUE = 255;
        public const int NETDEV_MIN_VIDEO_EFFECT_VALUE = 0;

        /* Minimum values for image parameters (Gama) */
        public const int NETDEV_MAX_VIDEO_EFFECT_GAMMA_VALUE = 10;

        /* Maximum connection timeout */
        public const int NETDEV_MAX_CONNECT_TIME_VALUE = 75000;

        /* Minimum connection timeout */
        public const int NETDEV_MIN_CONNECT_TIME_VALUE = 300;

        /* Maximum number of users */
        public const int NETDEV_MAX_USER_NUM = (256 + 32);

        /* Maximum number of channels allowed for live preview */
        public const int NETDEV_MAX_REALPLAY_NUM = 128;

        /* Maximum number of channels allowed for playback or download */
        public const int NETDEV_MAX_PALYBACK_NUM = 128;

        /* Maximum number of alarm channels */
        public const int NETDEV_MAX_ALARMCHAN_NUM = 128;

        /* Maximum number of channels allowed for formatting hard disk */
        public const int NETDEV_MAX_FORMAT_NUM = 128;

        /* Maximum number of channels allowed for file search */
        public const int NETDEV_MAX_FILE_SEARCH_NUM = 2000;

        /* Maximum number of channels allowed for log search */
        public const int NETDEV_MAX_LOG_SEARCH_NUM = 2000;

        /* Maximum number of channels allowed for creating transparent channels */
        public const int NETDEV_MAX_SERIAL_NUM = 2000;

        /* Maximum number of channels allowed for upgrade */
        public const int NETDEV_MAX_UPGRADE_NUM = 256;

        /* Maximum number of channels allowed for audio forwarding */
        public const int NETDEV_MAX_VOICE_COM_NUM = 256;

        /* Maximum number of channels allowed for audio broadcast */
        public const int NETDEV_MAX_VOICE_BROADCAST_NUM = 256;

        /* Maximum timeout, unit: ms */
        public const int NETDEV_MAX_CONNECT_TIME = 75000;

        /* Minimum timeout, unit: ms */
        public const int NETDEV_MIN_CONNECT_TIME = 300;

        /* Default timeout, unit: ms */
        public const int NETDEV_DEFAULT_CONNECT_TIME = 3000;

        /* Number of connection attempts */
        public const int NETDEV_CONNECT_TRY_TIMES = 1;

        /* User keep-alive interval */
        public const int NETDEV_KEEPLIVE_TRY_TIMES = 3;

        /* Number of OSD text overlays */
        public const int NETDEV_OSD_TEXTOVERLAY_NUM = 6;

        /* Length of OSD texts */
        public const int NETDEV_OSD_TEXT_MAX_LEN = (64 + 4);

        /* Maximum number of OSD type */
        public const int NETDEV_OSD_TYPE_MAX_NUM = 26;

        /* Maximum number of OSD time format type  */
        public const int NETDEV_OSD_TIME_FORMAT_MAX_NUM = 7;

        /* Maximum number of OSD date format type */
        public const int NETDEV_OSD_DATE_FORMAT_MAX_NUM = 15;

        /* Maximum number of alarms a user can get */
        public const int NETDEV_PULL_ALARM_MAX_NUM = 8;

        /* Maximum number of patrol routes allowed  */
        public const int NETDEV_TRACK_CRUISE_MAXNUM = 1;

        /* Minimum volume */
        public const int NETDEV_AUDIO_SOUND_MIN_VALUE = 0;

        /* Maximum volume */
        public const int NETDEV_AUDIO_SOUND_MAX_VALUE = 255;

        /* microphone Minimum volume */
        public const int NETDEV_MIC_SOUND_MIN_VALUE = 0;

        /* microphone Maximum volume */
        public const int NETDEV_MIC_SOUND_MAX_VALUE = 255;

        /* Screen Info Row */
        public const int NETDEV_SCREEN_INFO_ROW = 18;

        /* Screen Info Column */
        public const int NETDEV_SCREEN_INFO_COLUMN = 22;

        /* Length of IP */
        public const int NETDEV_IP_LEN = 64;


        /* Maximum length of URL */
        public const int NETDEV_BUFFER_MAX_LEN = 1024;

        /* Maximum number of channel */
        public const int NETDEV_CHANNEL_MAX = 512;

        /* Maximum number of days in a month */
        public const int NETDEV_MONTH_DAY_MAX = 31;

        /* Maximum number of resolution */
        public const int NETDEV_RESOLUTION_NUM_MAX = 32;

        /* Maximum number of encode type */
        public const int NETDEV_VIDEO_ENCODE_TYPE_MAX = 16;

        /* Length of wifi sniffer MAC  */
        public const int NETDEV_WIFISNIFFER_MAC_MAX_NUM = 64;

        /* Maximum number of wifi sniffer MAC array */
        public const int NETDEV_WIFISNIFFER_MAC_ARRY_MAX_NUM = 128;

        /* Maximum number of Disk */
        public const int NETDEV_DISK_MAX_NUM = 256;

        /* Maximum number of image quality level */
        public const int NETDEV_IMAGE_QUALITY_MAX_NUM = 9;

        /* Maximum number of bit rate mode */
        public const int NETDEV_BIT_RATE_TYPE_MAX_NUM = 2;

        /* Maximum number of video compression  */
        public const int NETDEV_ENCODE_FORMAT_MAX_NUM = 3;

        /*Maximum number of smart image encoding mode  */
        public const int NETDEV_SMART_ENCODE_MODEL_MAX_NUM = 3;

        /* Maximum number of GOP type */
        public const int NETDEV_GOP_TYPE_MAX_NUM = 4;

        public const int TRUE = 1;

        public const int FALSE = 0;
        public const int NETDEV_E_NONSUPPORT = 38;

        public static int m_bRouteRecording;
        public static int m_bTracking;

        /* error code start */

        public const int NETDEV_E_NO_RESULT = 41;          /* No result */
        public const int NETDEV_E_VIDEO_RESOLUTION_CHANGE = 1269;        /* Resolution changed */

        /* error code end */

        /******ITS*****/
        public const int NETDEV_TRAFFIC_PIC_MAX_NUM = 8;
        public const int NETDEV_UNIVIEW_MAX_TIME_LEN = 18;
        public const int NETDEV_DEV_ID_MAX_LEN = 32;
        public const int NETDEV_TOLLGATE_NAME_MAX_LEN = 64;
        public const int NETDEV_PLACE_NAME_MAX_LEN = 256;
        public const int NETDEV_DIRECTION_NAME_MAX_LEN = 64;
        public const int NETDEV_CAR_PLATE_MAX_LEN = 32;
        public const int NETDEV_CAR_VEHICLE_BRAND_LEN = 4;
        public const int NETDEV_PECCANCYTYPE_CODE_MAX_NUM = 16;

        static Lazy<IItsNetDevSdkProxy> _netDevSdk = new Lazy<IItsNetDevSdkProxy>(() => new ItsNetDevSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static ItsNetDevSdk()
        {
            Directory.CreateDirectory(DllFullPath);
            if (Environment.Is64BitProcess)
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X64_NetDEVSDK))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NetDEVSDK, Path.Combine(DllFullPath, "NetDEVSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_avutil_audio_aac, Path.Combine(DllFullPath, "avutil_audio_aac.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_dsp_audio_aac, Path.Combine(DllFullPath, "dsp_audio_aac.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_dsp_audio_aac_enc, Path.Combine(DllFullPath, "dsp_audio_aac_enc.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_dsp_audio_g711, Path.Combine(DllFullPath, "dsp_audio_g711.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_dsp_h264_gpu_dec, Path.Combine(DllFullPath, "dsp_h264_gpu_dec.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_dsp_video_h264_1, Path.Combine(DllFullPath, "dsp_video_h264_1.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_dsp_video_mjpeg, Path.Combine(DllFullPath, "dsp_video_mjpeg.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_FaceDetection, Path.Combine(DllFullPath, "FaceDetection.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_fisheye_rectify, Path.Combine(DllFullPath, "fisheye_rectify.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_iconv, Path.Combine(DllFullPath, "iconv.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_ISF_ImageProc, Path.Combine(DllFullPath, "ISF_ImageProc.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libcloud, Path.Combine(DllFullPath, "libcloud.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libcloudclient, Path.Combine(DllFullPath, "libcloudclient.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libcloudhttpcurl, Path.Combine(DllFullPath, "libcloudhttpcurl.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libcurl, Path.Combine(DllFullPath, "libcurl.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libstun, Path.Combine(DllFullPath, "libstun.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_libwinpthread_1, Path.Combine(DllFullPath, "libwinpthread-1.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mfc90, Path.Combine(DllFullPath, "mfc90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mfc90u, Path.Combine(DllFullPath, "mfc90u.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mfcm90, Path.Combine(DllFullPath, "mfcm90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mfcm90u, Path.Combine(DllFullPath, "mfcm90u.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcm90, Path.Combine(DllFullPath, "msvcm90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcp90, Path.Combine(DllFullPath, "msvcp90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcp120, Path.Combine(DllFullPath, "msvcp120.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcr90, Path.Combine(DllFullPath, "msvcr90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_msvcr120, Path.Combine(DllFullPath, "msvcr120.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_mxml1, Path.Combine(DllFullPath, "mxml1.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NDAO, Path.Combine(DllFullPath, "NDAO.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NDPlayer, Path.Combine(DllFullPath, "NDPlayer.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NDRM_Module, Path.Combine(DllFullPath, "NDRM_Module.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NDRSA, Path.Combine(DllFullPath, "NDRSA.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NDRtmp, Path.Combine(DllFullPath, "NDRtmp.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NetCloudSDK, Path.Combine(DllFullPath, "NetCloudSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_NetDEVDiscovery, Path.Combine(DllFullPath, "NetDEVDiscovery.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_nvidia_gpu_dec, Path.Combine(DllFullPath, "nvidia_gpu_dec.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_pthreadVC2, Path.Combine(DllFullPath, "pthreadVC2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X64_RSA, Path.Combine(DllFullPath, "RSA.dll"));
                }
            }
            else
            {
                if (!SdkFileComponent.CompareResourceFile(DllFullName, Properties.Resources.X86_NetDEVSDK))
                {
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NetDEVSDK, Path.Combine(DllFullPath, "NetDEVSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_dsp_audio_aac, Path.Combine(DllFullPath, "dsp_audio_aac.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_dsp_audio_aac_enc, Path.Combine(DllFullPath, "dsp_audio_aac_enc.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_dsp_audio_g711, Path.Combine(DllFullPath, "dsp_audio_g711.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_dsp_h264_gpu_dec, Path.Combine(DllFullPath, "dsp_h264_gpu_dec.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_dsp_video_h264_1, Path.Combine(DllFullPath, "dsp_video_h264_1.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_dsp_video_mjpeg, Path.Combine(DllFullPath, "dsp_video_mjpeg.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_FaceDetection, Path.Combine(DllFullPath, "FaceDetection.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_fisheye_rectify, Path.Combine(DllFullPath, "fisheye_rectify.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_HW_H265dec_Win32D, Path.Combine(DllFullPath, "HW_H265dec_Win32D.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_iconv, Path.Combine(DllFullPath, "iconv.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_ISF_ImageProc, Path.Combine(DllFullPath, "ISF_ImageProc.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libcloud, Path.Combine(DllFullPath, "libcloud.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libcloudclient, Path.Combine(DllFullPath, "libcloudclient.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libcloudhttpcurl, Path.Combine(DllFullPath, "libcloudhttpcurl.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libcurl, Path.Combine(DllFullPath, "libcurl.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_libstun, Path.Combine(DllFullPath, "libstun.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mfc90, Path.Combine(DllFullPath, "mfc90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mfc90u, Path.Combine(DllFullPath, "mfc90u.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mfcm90, Path.Combine(DllFullPath, "mfcm90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mfcm90u, Path.Combine(DllFullPath, "mfcm90u.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcm90, Path.Combine(DllFullPath, "msvcm90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcp90, Path.Combine(DllFullPath, "msvcp90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcp120, Path.Combine(DllFullPath, "msvcp120.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcr90, Path.Combine(DllFullPath, "msvcr90.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_msvcr120, Path.Combine(DllFullPath, "msvcr120.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_mxml1, Path.Combine(DllFullPath, "mxml1.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NDAO, Path.Combine(DllFullPath, "NDAO.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NDPlayer, Path.Combine(DllFullPath, "NDPlayer.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NDRM_Module, Path.Combine(DllFullPath, "NDRM_Module.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NDRSA, Path.Combine(DllFullPath, "NDRSA.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NDRtmp, Path.Combine(DllFullPath, "NDRtmp.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NetCloudSDK, Path.Combine(DllFullPath, "NetCloudSDK.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_NetDEVDiscovery, Path.Combine(DllFullPath, "NetDEVDiscovery.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_nvidia_gpu_dec, Path.Combine(DllFullPath, "nvidia_gpu_dec.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_pthreadGC2, Path.Combine(DllFullPath, "pthreadGC2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_pthreadVC2, Path.Combine(DllFullPath, "pthreadVC2.dll"));
                    SdkFileComponent.WriteResourceFile(Properties.Resources.X86_RSA, Path.Combine(DllFullPath, "RSA.dll"));
                }
            }
        }
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IItsNetDevSdkProxy Instance { get => _netDevSdk.Value; }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IItsNetDevSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _netDevSdk.Value; }
            if (!File.Exists(BaseDllFullName))
            { SdkFileComponent.TryCopyDirectory(DllFullPath, BaseDllFullPath); }
            return ItsNetDevSdkDller.Instance;
        }
    }
}
