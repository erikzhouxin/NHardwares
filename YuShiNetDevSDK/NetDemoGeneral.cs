using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.YuShiNetDevSDK
{
    /// <summary>
    /// 宇视
    /// </summary>
    public class NETDEMO
    {
        public const int REAL_PANEL_MAX_SIZE = 16;//16
        public const int PLAYBACK_PANEL_MAX_SIZE = 4;
        /// <summary>
        /// IPv4地址长度
        /// </summary>
        public const int NETDEV_IPV4_LEN_MAX = 16;
        /// <summary>
        /// 用户名长度
        /// </summary>
        public const int NETDEV_USERNAME_LEN_260 = 260;
        public const int NETDEV_SERIAL_NUMBER_LEN_64 = 64;
        public const int NETDEV_MODEL_LEN_64 = 64;

        public const int NETDEMO_SMALL_IMAGE_SIZE = 1024 * 1024;
        public const int NETDEMO_FIND_FACE_LIB_MEM_COUNT = 6;
        public const int NETDEMO_FIND_VEHICLE_LIB_MEM_COUNT = 16;
        public const int NETDEMO_FIND_SMART_ALARM_RECORD_COUNT = 16;

        /*   Common length */
        /// <summary>
        /// 长度4
        /// </summary>
        public const int NETDEV_LEN_4 = 4;
        /// <summary>
        /// 长度8
        /// </summary>
        public const int NETDEV_LEN_8 = 8;
        /// <summary>
        /// 长度16
        /// </summary>
        public const int NETDEV_LEN_16 = 16;
        /// <summary>
        /// 长度32
        /// </summary>
        public const int NETDEV_LEN_32 = 32;
        /// <summary>
        /// 长度64
        /// </summary>
        public const int NETDEV_LEN_64 = 64;
        /// <summary>
        /// 长度128
        /// </summary>
        public const int NETDEV_LEN_128 = 128;
        /// <summary>
        /// 长度132
        /// </summary>
        public const int NETDEV_LEN_132 = 132;
        /// <summary>
        /// 长度260
        /// </summary>
        public const int NETDEV_LEN_260 = 260;
        /// <summary>
        /// 预置位总数
        /// </summary>
        public const int NETDEV_MAX_PRESET_NUM = 255;

        /*TreeView图标索引*/
        public const int NETDEV_TREEVIEW_IMAGE_ROOT = 0;
        public const int NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON = 1;
        public const int NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF = 2;
        public const int NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON = 3;
        public const int NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF = 4;
        public const int NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON = 5;
        public const int NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF = 6;
        public const int NETDEV_TREEVIEW_IMAGE_ORG = 7;
        /// <summary>
        /// 如果下载一个视频超过5次时间进度都没有变化，说明下载出问题，用于下载回放时
        /// </summary>
        public const int NETDEMO_DOWNLOAD_TIME_COUNT = 5;
        /// <summary>
        /// 控制定时器多线程同步,默认为没有线程执行
        /// </summary>
        public static bool NETDEMO_DOWNLOAD_TIMER_MUX_FLAG = false;
        /// <summary>
        /// 停止下载
        /// </summary>
        public static bool NETDEMO_DOWNLOAD_TIMER_STOP_ALL = false;

        //public static bool NETDEMO_SELECTED_CHANGED_FlAG = true;/*是否允许presetIDCobBox_SelectedIndexChanged事件触发*/
        /// <summary>
        /// 发现树节点类型
        /// </summary>
        public enum NETDEMO_FIND_TREE_NODE_TYPE_E
        {
            /// <summary>
            /// 频道标识channel ID
            /// </summary>
            NETDEMO_FIND_TREE_NODE_CHN_ID = 0,
            /// <summary>
            /// 子设备标识sub device ID
            /// </summary>
            NETDEMO_FIND_TREE_NODE_SUB_DEVICE_ID = 1,
            /// <summary>
            /// 设备标识
            /// </summary>
            NETDEMO_FIND_TREE_NODE_DEVICE_INDEX = 2,
            /// <summary>
            /// 组织标识
            /// </summary>
            NETDEMO_FIND_TREE_NODE_ORG_ID = 3
        }
        /// <summary>
        /// 登录类型
        /// </summary>
        public enum NETDEV_LOGIN_TYPE_E
        {
            /// <summary>
            /// 新登录new Login
            /// </summary>
            NETDEV_NEW_LOGIN = 0,
            /// <summary>
            /// 重新登录again Login
            /// </summary>
            NETDEV_AGAIN_LOGIN = 1
        }
        /// <summary>
        /// 监视类型
        /// </summary>
        public enum NETDEMO_MONITOR_TYPE_E
        {
            /// <summary>
            /// 单个屏幕
            /// </summary>
            NETDEMO_MONITOR_SINGLE_SCREEN = 0,
            /// <summary>
            /// 所有屏幕
            /// </summary>
            NETDEMO_MONITOR_ALL_SCREEN = 1
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        public enum NETDEMO_DEVICE_TYPE_E
        {
            /// <summary>
            /// IPC/NVR
            /// </summary>
            NETDEMO_DEVICE_IPC_OR_NVR = 0,
            /// <summary>
            /// 云台
            /// </summary>
            NETDEMO_DEVICE_VMS = 1,
            /// <summary>
            /// 无效的
            /// </summary>
            NETDEMO_DEVICE_INVALID = 0xff
        }
        /// <summary>
        /// 更新时间信息
        /// </summary>
        public class NETDEMO_UPDATE_TIME_INFO
        {
            /// <summary>
            /// 用户登录句柄
            /// </summary>
            public IntPtr lpHandle;
            /// <summary>
            /// 开始时间
            /// </summary>
            public Int64 tBeginTime;
            /// <summary>
            /// 结束时间
            /// </summary>
            public Int64 tEndTime;
            /// <summary>
            /// 当前时间
            /// </summary>
            public Int64 tCurTime;
            /// <summary>
            /// 计数
            /// </summary>
            public Int32 dwCount;
            /// <summary>
            /// 文件名称
            /// </summary>
            public String strFileName;
            /// <summary>
            /// 保存文件路径
            /// </summary>
            public String strFilePath;
            /// <summary>
            /// 下载状态
            /// </summary>
            public bool downLoad_status;
        }
        /// <summary>
        /// 用于视频流配置质量Quality
        /// </summary>
        public static NETDEV_VIDEO_QUALITY_E[] GastVideoQualityMap =
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
        /// <summary>
        /// 异常类型
        /// </summary>
        public enum NETDEV_EXCEPTION_TYPE_E
        {
            /// <summary>
            /// 回放业务异常上报  Playback exceptions report 300~399
            /// 回放结束  Playback ended
            /// </summary>
            NETDEV_EXCEPTION_REPORT_VOD_END = 300,
            /// <summary>
            /// 回放异常  Playback exception occured
            /// </summary>
            NETDEV_EXCEPTION_REPORT_VOD_ABEND = 301,
            /// <summary>
            /// 备份结束  Backup ended
            /// </summary>
            NETDEV_EXCEPTION_REPORT_BACKUP_END = 302,
            /// <summary>
            /// 磁盘被拔出  Disk removed
            /// </summary>
            NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT = 303,
            /// <summary>
            /// 磁盘已满  Disk full
            /// </summary>
            NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL = 304,
            /// <summary>
            /// 其他原因导致备份失败   Backup failure caused by other reasons
            /// </summary>
            NETDEV_EXCEPTION_REPORT_BACKUP_ABEND = 305,
            /// <summary>
            /// 用户交互时异常（用户保活超时）  Exception occurred during user interaction (keep-alive timeout)
            /// </summary>
            NETDEV_EXCEPTION_EXCHANGE = 0x8000,
            /// <summary>
            /// 无效值  Invalid value
            /// </summary>
            NETDEV_EXCEPTION_REPORT_INVALID = 0xFFFF
        }
        /// <summary>
        /// 人脸识别报警类型
        /// </summary>
        public enum NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E
        {
            /// <summary>
            /// 匹配的报警记录Match Alarm Record
            /// </summary>
            NETDEMO_FIND_FACE_ALARM_RECORD_MATCH = 0,
            /// <summary>
            /// 传送记录Pass-Thru Record
            /// </summary>
            NETDEMO_FIND_FACE_ALARM_RECORD_PASS_THRU = 1,
        }
        /// <summary>
        /// 车辆报警记录类型
        /// </summary>
        public enum NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E
        {
            /// <summary>
            /// 匹配的报警记录Match Alarm Record
            /// </summary>
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_MATCH = 0,
            /// <summary>
            /// 传送记录
            /// </summary>
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_PASS_THRU = 1,
        }
        /// <summary>
        /// 报警信息
        /// </summary>
        public struct NETDEMO_ALARM_INFO
        {
            /// <summary>
            /// 报警类型
            /// </summary>
            public Int32 alarmType;
            /// <summary>
            /// 报警提示
            /// </summary>
            public string reportAlarm;
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="alarmTypeArg"></param>
            /// <param name="reportAlarmArg"></param>
            public NETDEMO_ALARM_INFO(int alarmTypeArg, string reportAlarmArg)
            {
                alarmType = alarmTypeArg;
                reportAlarm = reportAlarmArg;
            }
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        public static NETDEMO_ALARM_INFO[] GastNETDemoAlarmInfo =
        {
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALRAM_CONFLAG_DETECT,"连接状态检测报警(conflag detect alarm)"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MOVE_DETECT,"运动检测报警(Motion detection alarm)"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MOVE_DETECT_RECOVER,"运动检测报警恢复(Motion detection alarm recover)"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEO_LOST,"视频丢失报警(Video loss alarm)"),
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
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_CHL_ONLINE,"Channel online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_REPORT_DEV_CHL_OFFLINE,"Channel offline"),
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
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWIDTH_CHANGE,"Bandwidth change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_OFF,"Network disconnection faults"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_RESUME_ON,"Network disconnection alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MATCH_LIST,"Face recognition matchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MATCH_LIST_RECOVER,"Face recognition matchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MISMATCH_LIST,"Face recognition mismatchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MISMATCH_LIST_RECOVER,"Face recognition mismatchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST,"Vehicle recognition matchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST_RECOVER,"Vehicle recognition matchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST,"Vehicle recognition mismatchlist alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST_RECOVER,"Vehicle recognition mismatchlist alarm recovery"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SERVER_FAULT,"Server fault"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SERVER_NORMAL,"Server recovered"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_ERROR,"SysDisk abnormal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_ONLINE,"SysDisk online"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_OFFLINE,"SysDisk offline"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_STORAGE_IS_FULL,"System storage is full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_RAID_DEGRADED,"SysRAID disabled"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_DISK_RAID_DISABLED,"SysRAID degraded"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_STOR_GO_FULL,"Equipment storage go full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_STOR_GO_FULL,"System storage go full"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ARRAY_NORMAL,"Device array normal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_ARRAY_NORMAL,"Array system normal"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_STOR_ERR,"System storage error"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_BANDWITH_CHANGE,"Device export bandwidth changes"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_VIDEOENCODER_CHANGE,"Device videoencoder configuration changes"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SYS_ILLEGAL_ACCESS,"System illegal access"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_SPIN_UP_TIME,"Rotation time of spindle"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_START_STOP_COUNT,"Start and stop counting"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_REALLOCATED_SECTOR_COUNT,"Remap sector count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_SEEK_ERROR_RATE,"Trace error rate"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_POWER_ON_HOURS,"Current time accumulated"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_SPIN_RETRY_COUNT,"The spindle rotating retries"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_CALIBRATION_RETRY_COUNT,"Head alignment retry count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_POWER_CYCLE_COUNT,"Current cycle count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_POWEROFF_RETRACT_COUNT,"Power back to count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_LOAD_CYCLE_COUNT,"Head load count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_TEMPERATURE_CELSIUS,"Temperature celsius"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_REALLOCATED_EVENT_COUNT,"Mapping the counting"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_CURRENT_PENDING_SECTOR,"The current mapping sector count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_OFFLINE_UNCORRECTABLE,"Offline can't correction sector count"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_UDMA_CRC_ERROR_COUNT,"Parity error rate"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_MULTI_ZONE_ERROR_RATE,"Many regional error rate"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_RESOLUTION_CHANGE,"The resolution of the change"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_MANUAL,"Manual alarm"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_ALARMHOST_COMMON,"Emergency alarm events"),
            new NETDEMO_ALARM_INFO((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_DOORHOST_COMMON,"Access the event")
        };
        /// <summary>
        /// 车牌类型
        /// </summary>
        public struct NETDEMO_PLATE_TYPE
        {
            /// <summary>
            /// 类型
            /// </summary>
            public Int32 dwPlateType;
            /// <summary>
            /// 类型名称
            /// </summary>
            public string strPlateType;
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="dwPlateTypeArg"></param>
            /// <param name="strPlateTypeArg"></param>
            public NETDEMO_PLATE_TYPE(int dwPlateTypeArg, string strPlateTypeArg)
            {
                dwPlateType = dwPlateTypeArg;
                strPlateType = strPlateTypeArg;
            }
        }
        /// <summary>
        /// 车牌类型
        /// </summary>
        public static NETDEMO_PLATE_TYPE[] GastNETDemoPlateType =
        {
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_BIG_CAR_E,"Large Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_MINI_CAR_E,"Small Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_EMBASSY_CAR_E,"Embassy Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_CONSULATE_CAR_E,"Consulate Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_OVERSEAS_CAR_E,"Overseas Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_FOREIGN_CAR_E,"Foreign Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_COMMON_MOTORBIKE_E,"Common Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_HANDINESS_MOTORBIKE_E,"Light Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_EMBASSY_MOTORBIKE_E,"Embassy Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_CONSULATE_MOTORBIKE_E,"Consulate Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_OVERSEAS_MOTORBIKE_E,"Overseas Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_FOREIGN_MOTORBIKE_E,"Foreign Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_LOW_SPEED_CAR_E,"Low Speed Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TRACTOR_E,"Tractor Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TRAILER_E,"Trailer Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_COACH_CAR_E,"Coach Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_COACH_MOTORBIKE_E,"Coach Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_CAR_E,"Temporary Entry Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TEMPORARY_ENTRY_MOTORBIKE_E,"Temporary Entry Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_TEMPORARY_DRIVING_E,"Temporary Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_POLICE_CAR_E,"Police Vehicle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_POLICE_MOTORBIKE_E,"Police Motorcycle Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_HONGKONG_ENTRY_EXIT_E,"Border Crossing Vehicle (Hong Kong) Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_MACAO_ENTRY_EXIT_E,"Border Crossing Vehicle (Macau) Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_ARMED_POLICE_E,"Armed Police Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_ARMY_E,"Military Plate"),
            new NETDEMO_PLATE_TYPE((int)NETDEV_PLATE_TYPE_E.NETDEV_PLATE_TYPE_OTHER_E,"Other")
        };
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public struct NETDEMO_PLATE_COLOR
        {
            /// <summary>
            /// 颜色类型
            /// </summary>
            public Int32 dwPlateColor;
            /// <summary>
            /// 颜色名
            /// </summary>
            public string strPlateColor;

            public NETDEMO_PLATE_COLOR(int dwPlateColorArg, string strPlateColorArg)
            {
                dwPlateColor = dwPlateColorArg;
                strPlateColor = strPlateColorArg;
            }
        }
        /// <summary>
        /// 车牌颜色
        /// </summary>
        public static NETDEMO_PLATE_COLOR[] GastNETDemoPlateColor =
        {
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_BLACK_E,"Black"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_WHITE_E,"White"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_GRAY_E,"Gray"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_RED_E,"Red"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_BLUE_E,"Blue"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_YELLOW_E,"Yellow"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_ORANGE_E,"Orange"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_BROWN_E,"Brown"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_GREEN_E,"Green"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_PURPLE_E,"Purple"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_CYAN_E,"Cyan"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_PINK_E,"Pink"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_TRANSPARENT_E,"Transparent"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_SILVERYWHITE_E,"Silvery White"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_DARK_E,"Dark"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_LIGHT_E,"Light"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_COLOURLESS,"No Color"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_YELLOWGREEN,"Yellow&Green"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_GRADUALGREEN,"Gradated Green"),
            new NETDEMO_PLATE_COLOR((int)NETDEV_PLATE_COLOR_E.NETDEV_PLATE_COLOR_OTHER_E,"Other")
        };
        /// <summary>
        /// 云台主设备类型
        /// </summary>
        public static NETDEV_DEVICE_MAIN_TYPE_E[] GaENETDemoVMSMainDevType =
        {
            NETDEV_DEVICE_MAIN_TYPE_E.NETDEV_DTYPE_MAIN_ENCODE,
            NETDEV_DEVICE_MAIN_TYPE_E.NETDEV_DTYPE_MAIN_BAYONET
        };
    }
    /// <summary>
    /// 循环监视信息
    /// </summary>
    public class CycleMonitorInfo
    {
        /// <summary>
        /// 单个监视对象信息
        /// </summary>
        public struct CYCLE_MONITOR_CHANNEL_INFO_S
        {
            /// <summary>
            /// 设备索引
            /// </summary>
            public int deviceIndex;
            /// <summary>
            /// 登录句柄
            /// </summary>
            public IntPtr devhandle;
            /// <summary>
            /// 频道标识(1 ~ &)
            /// </summary>
            public int channelID;
        }
        /// <summary>
        /// 监视类型
        /// </summary>
        public NETDEMO.NETDEMO_MONITOR_TYPE_E monitorType = NETDEMO.NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_SINGLE_SCREEN;
        /// <summary>
        /// 容器序号(0 ~ 15)
        /// </summary>
        public int panelNo = 0;
        /// <summary>
        /// 监视计数
        /// </summary>
        public int monitorCount = 0;
        /// <summary>
        /// 间隔时间(秒)
        /// </summary>
        public int intervalTime = 20;
        /// <summary>
        /// 频道信息列表
        /// </summary>
        public List<CYCLE_MONITOR_CHANNEL_INFO_S> channelInfoList = new List<CYCLE_MONITOR_CHANNEL_INFO_S>();
    }
    /// <summary>
    /// 回放信息
    /// </summary>
    public class PlayBackInfo
    {
        /// <summary>
        /// 登录句柄
        /// </summary>
        public IntPtr m_devHandle = IntPtr.Zero;
        /// <summary>
        /// 回放数据列表
        /// </summary>
        public List<NETDEV_FINDDATA_S> m_findPlayBackDataList = new List<NETDEV_FINDDATA_S>();
        /// <summary>
        /// 选中的频道
        /// </summary>
        public int m_curSelectedChannelID = -1;
        /// <summary>
        /// 选中的设备
        /// </summary>
        public int m_curSelectedDeviceIndex = -1;
        /// <summary>
        /// 下一个容器序号
        /// </summary>
        public int m_nextPlayBackPanelIndex = 0;
        /// <summary>
        /// 定时器
        /// 初始化为500毫秒
        /// </summary>
        public System.Timers.Timer m_timer = new System.Timers.Timer(500);
    }
    /// <summary>
    /// 基础信息
    /// </summary>
    public struct NETDEMO_BASIC_INFO_S
    {
        /// <summary>
        /// 退出标识
        /// </summary>
        public bool existFlag;
        /// <summary>
        /// 系统时间
        /// </summary>
        public NETDEV_TIME_CFG_S stSystemTime;
        /// <summary>
        /// 设备名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public String szDeviceName;
        /// <summary>
        /// 磁盘信息
        /// </summary>
        public NETDEV_DISK_INFO_LIST_S stDiskInfoList;
    }
    /// <summary>
    /// 网络信息
    /// </summary>
    public struct NETDEMO_NETWORK_INFO_S
    {
        /// <summary>
        /// 存在标识
        /// </summary>
        public bool existFlag;
        /// <summary>
        /// 网络配置信息
        /// </summary>
        public NETDEV_NETWORKCFG_S stNetWorkIP;
        /// <summary>
        /// 网络端口号状态信息
        /// </summary>
        public NETDEV_UPNP_NAT_STATE_S stNetWorkPort;
        /// <summary>
        /// NTP参数信息
        /// </summary>
        public NETDEV_SYSTEM_NTP_INFO_S stNetWorkNTP;
    }
    /// <summary>
    /// 输入信息
    /// </summary>
    public struct NETDEMO_INPUT_INFO_S
    {
        /// <summary>
        /// 存在标识
        /// </summary>
        public bool existFlag;
        /// <summary>
        /// 告警开关量输入信息
        /// </summary>
        public NETDEV_ALARM_INPUT_LIST_S stInPutInfo;
        /// <summary>
        /// 告警开关量输出信息
        /// </summary>
        public NETDEV_ALARM_OUTPUT_LIST_S stOutPutInfo;
    }
    /// <summary>
    /// 通道视频流信息
    /// </summary>
    public struct NETDEMO_VIDEO_STREAM_INFO_S
    {
        /// <summary>
        /// 存在标识
        /// </summary>
        public bool existFlag;
        /// <summary>
        /// 视频流信息列表
        /// </summary>
        public NETDEV_VIDEO_STREAM_INFO_S[] videoStreamInfoList;
    }
    /// <summary>
    /// 图像信息
    /// </summary>
    public struct NETDEMO_IMAGE_INFO_S
    {
        /// <summary>
        /// 存在标识
        /// </summary>
        public bool existFlag;
        /// <summary>
        /// 设备图像设置
        /// </summary>
        public NETDEV_IMAGE_SETTING_S imageInfo;
    }
    /// <summary>
    /// 
    /// </summary>
    public struct NETDEMO_VIDEO_OSD_S
    {
        public bool existFlag;
        public NETDEV_VIDEO_OSD_CFG_S OSDInfo;
    }

    public struct NETDEMO_PRIVACY_MASK_INFO_S
    {
        public bool existFlag;
        public NETDEV_PRIVACY_MASK_CFG_S privacyMaskInfo;
    }

    public struct NETDEMO_MOTION_ALARM_INFO_S
    {
        public bool existFlag;
        public NETDEV_MOTION_ALARM_INFO_S MotionAlarmInfo;
    }

    public struct NETDEMO_TAMPER_ALARM_INFO_S
    {
        public bool existFlag;
        public NETDEV_TAMPER_ALARM_INFO_S tamperAlarmInfo;
    }

    public class ChannelInfo
    {
        public NETDEV_VIDEO_CHL_DETAIL_INFO_S m_devVideoChlInfo = new NETDEV_VIDEO_CHL_DETAIL_INFO_S();
        public NETDEV_CRUISE_LIST_S m_CruiseInfoList;
        public NETDEMO_BASIC_INFO_S m_basicInfo;
        public NETDEMO_NETWORK_INFO_S m_networkInfo;
        public NETDEMO_VIDEO_STREAM_INFO_S m_videoStreamInfo;
        public NETDEMO_IMAGE_INFO_S m_imageInfo;
        public NETDEMO_VIDEO_OSD_S m_OSDInfo;
        public NETDEMO_INPUT_INFO_S m_IOInfo;
        public NETDEMO_PRIVACY_MASK_INFO_S m_privacyMaskInfo;
        public NETDEMO_MOTION_ALARM_INFO_S m_MotionAlarmInfo;
        public NETDEMO_TAMPER_ALARM_INFO_S m_tamperAlarmInfo;

        public ChannelInfo()
        {
            /**/
            m_CruiseInfoList = new NETDEV_CRUISE_LIST_S();
            m_CruiseInfoList.astCruiseInfo = new NETDEV_CRUISE_INFO_S[NETDEVSDK.NETDEV_MAX_CRUISEROUTE_NUM];
            for (int i = 0; i < m_CruiseInfoList.astCruiseInfo.Length; i++)
            {
                m_CruiseInfoList.astCruiseInfo[i].astCruisePoint = new NETDEV_CRUISE_POINT_S[NETDEVSDK.NETDEV_MAX_CRUISEPOINT_NUM];
            }

            m_basicInfo = new NETDEMO_BASIC_INFO_S();
            m_basicInfo.existFlag = false;

            m_networkInfo = new NETDEMO_NETWORK_INFO_S();
            m_networkInfo.existFlag = false;
            m_networkInfo.stNetWorkPort.astUpnpPort = new NETDEV_UPNP_PORT_STATE_S[NETDEVSDK.NETDEV_LEN_16];

            m_videoStreamInfo = new NETDEMO_VIDEO_STREAM_INFO_S();
            m_videoStreamInfo.videoStreamInfoList = new NETDEV_VIDEO_STREAM_INFO_S[3];
            m_videoStreamInfo.existFlag = false;

            m_imageInfo = new NETDEMO_IMAGE_INFO_S();
            m_imageInfo.existFlag = false;

            m_OSDInfo = new NETDEMO_VIDEO_OSD_S();
            m_OSDInfo.existFlag = false;
            m_OSDInfo.OSDInfo.astTextOverlay = new NETDEV_OSD_TEXT_OVERLAY_S[NETDEVSDK.NETDEV_OSD_TEXTOVERLAY_NUM];

            m_IOInfo = new NETDEMO_INPUT_INFO_S();
            m_IOInfo.existFlag = false;
            m_IOInfo.stInPutInfo.astAlarmInputInfo = new NETDEV_ALARM_INPUT_INFO_S[NETDEVSDK.NETDEV_MAX_ALARM_IN_NUM];

            m_privacyMaskInfo = new NETDEMO_PRIVACY_MASK_INFO_S();
            m_privacyMaskInfo.existFlag = false;
            m_privacyMaskInfo.privacyMaskInfo.astArea = new NETDEV_PRIVACY_MASK_AREA_INFO_S[NETDEVSDK.NETDEV_MAX_PRIVACY_MASK_AREA_NUM];

            m_MotionAlarmInfo = new NETDEMO_MOTION_ALARM_INFO_S();
            m_MotionAlarmInfo.existFlag = false;
            m_MotionAlarmInfo.MotionAlarmInfo.awScreenInfo = new Int16Array[NETDEVSDK.NETDEV_SCREEN_INFO_ROW];
            for (int i = 0; i < NETDEVSDK.NETDEV_SCREEN_INFO_ROW; i++)
            {
                m_MotionAlarmInfo.MotionAlarmInfo.awScreenInfo[i].data = new short[NETDEVSDK.NETDEV_SCREEN_INFO_COLUMN];
            }

            m_tamperAlarmInfo = new NETDEMO_TAMPER_ALARM_INFO_S();
            m_tamperAlarmInfo.existFlag = false;
        }
    }

    public class RealPlayInfo
    {
        public Int32 m_channel = -1;
        public Int32 m_panelIndex = -1;
    }

    public class TreeNodeInfo
    {
        public int dwOrgID = -1;
        public int dwDeviceIndex = -1;
        public int dwSubDeviceID = -1;
        public int dwChannelID = -1;
    }

    public class NETDEMO_VMS_DEV_CHANNEL_INFO_S
    {
        public NETDEV_DEV_CHN_ENCODE_INFO_S stChnInfo;
        public NETDEV_CRUISE_LIST_S stCruiseList; /* 通道的预置位巡航路径信息 */
        public NETDEMO_IMAGE_INFO_S m_imageInfo;

        public Int32 m_dwSubFaceStructAlarmID = -1;
        public Int32 m_dwSubVehicleStructAlarmID = -1;
    }

    public class NETDEMO_VMS_DEV_BASIC_INFO_S
    {
        public NETDEV_DEV_BASIC_INFO_S stDevBasicInfo;
        public List<NETDEMO_VMS_DEV_CHANNEL_INFO_S> stChnInfoList = new List<NETDEMO_VMS_DEV_CHANNEL_INFO_S>();
    }

    public class NETDEMO_VMS_ORG_INFO_S
    {
        public NETDEV_ORG_INFO_S stOrgInfo;
        public List<NETDEMO_VMS_DEV_BASIC_INFO_S> stVmsDevBasicInfoList = new List<NETDEMO_VMS_DEV_BASIC_INFO_S>();
    }

    public class NETDEMO_VMS_DEVICE_INFO_S
    {
        public NETDEV_TIME_CFG_S stSystemTime;
        public List<NETDEMO_VMS_ORG_INFO_S> stOrgInfoList = new List<NETDEMO_VMS_ORG_INFO_S>();
    }

    public class DeviceInfo
    {
        public NETDEMO.NETDEMO_DEVICE_TYPE_E m_eDeviceType = NETDEMO.NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR;

        //本地设备信息
        public String m_ip = null;
        public Int32 m_port = 0;
        public String m_userName = null;
        public String m_password = null;

        /* VMS */
        public NETDEMO_VMS_DEVICE_INFO_S stVmsDevInfo;

        /*共用信息*/
        public IntPtr m_lpDevHandle = IntPtr.Zero;
        public Int32 m_channelNumber = 0;
        public NETDEV_DEVICE_INFO_S m_stDevInfo;//设备信息，用于登录出参

        /* IPC/NVR */
        public Int32 m_dwSubFaceStructAlarmID = -1;
        public Int32 m_dwSubVehicleStructAlarmID = -1;
        public Int32 m_dwSubFaceRecogAlarmID = -1;
        public Int32 m_dwSubVehicleRecogAlarmID = -1;

        public List<ChannelInfo> m_channelInfoList = new List<ChannelInfo>();

        //public List<NETDEV_VIDEO_CHL_DETAIL_INFO_S> m_devVideoChlInfoList = new List<NETDEV_VIDEO_CHL_DETAIL_INFO_S>();
        //public List<>  = new List<NETDEV_CRUISE_LIST_S>();

        static readonly object m_RealPlayInfolocker = new object();
        public List<RealPlayInfo> m_RealPlayInfoList = new List<RealPlayInfo>();

        public void addRealPlayInfo(RealPlayInfo objRealPlayInfo)
        {
            lock (m_RealPlayInfolocker)
            {
                for (int i = 0; i < m_RealPlayInfoList.Count; i++)
                {
                    if (m_RealPlayInfoList[i].m_channel == objRealPlayInfo.m_channel &&
                        m_RealPlayInfoList[i].m_panelIndex == objRealPlayInfo.m_panelIndex)
                    {
                        return;
                    }
                }
                m_RealPlayInfoList.Add(objRealPlayInfo);
            }
        }

        public void removeRealPlayInfo(RealPlayInfo objRealPlayInfo)
        {
            lock (m_RealPlayInfolocker)
            {
                for (int i = 0; i < m_RealPlayInfoList.Count; i++)
                {
                    if (m_RealPlayInfoList[i].m_channel == objRealPlayInfo.m_channel &&
                        m_RealPlayInfoList[i].m_panelIndex == objRealPlayInfo.m_panelIndex)
                    {
                        m_RealPlayInfoList.RemoveAt(i);
                    }
                }
            }
        }

        public void initDeviceInfo()
        {
            /*共用信息*/
            m_lpDevHandle = IntPtr.Zero;
            m_channelNumber = 0;
            stVmsDevInfo = null;
            m_channelInfoList.Clear();

            m_dwSubFaceStructAlarmID = -1;
            m_dwSubVehicleStructAlarmID = -1;

            m_dwSubFaceRecogAlarmID = -1;
            m_dwSubVehicleRecogAlarmID = -1;
        }
    }
}
