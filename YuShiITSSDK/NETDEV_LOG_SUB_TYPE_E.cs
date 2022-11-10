namespace System.Data.YuShiITSSDK
{
    public enum NETDEV_LOG_SUB_TYPE_E
    {
        NETDEV_LOG_ALL_SUB_TYPES = 0x0101,          /* All information logs */

        /* Information logs */
        NETDEV_LOG_MSG_HDD_INFO = 300,              /* HDD information */
        NETDEV_LOG_MSG_SMART_INFO = 301,              /* S.M.A.R.T  S.M.A.R.T information */
        NETDEV_LOG_MSG_REC_OVERDUE = 302,              /* Expired recording deletion */
        NETDEV_LOG_MSG_PIC_REC_OVERDUE = 303,              /* Expired image deletion */

        /*notification logs */
        NETDEV_LOG_NOTICE_IPC_ONLINE = 310,              /* Device online */
        NETDEV_LOG_NOTICE_IPC_OFFLINE = 311,              /* Device offline */
        NETDEV_LOG_NOTICE_ARRAY_RECOVER = 312,              /* arrayRecover */
        NETDEV_LOG_NOTICE_INIT_ARRARY = 313,              /* initializeArray */
        NETDEV_LOG_NOTICE_REBUILD_ARRARY = 314,              /*  rebuildArray */
        NETDEV_LOG_NOTICE_POE_PORT_STATUS = 315,              /*  poePortStatus */
        NETDEV_LOG_NOTICE_NETWORK_PORT_STATUS = 316,              /*  networkPortStatus */
        NETDEV_LOG_NOTICE_DISK_ONLINE = 317,              /* Disk online */


        /* ID  Sub type log ID of alarm logs */
        NETDEV_LOG_ALARM_MOTION_DETECT = 350,              /* Motion detection alarm */
        NETDEV_LOG_ALARM_MOTION_DETECT_RESUME = 351,              /* Motion detection alarm recover */
        NETDEV_LOG_ALARM_VIDEO_LOST = 352,              /* Video loss alarm */
        NETDEV_LOG_ALARM_VIDEO_LOST_RESUME = 353,              /* Video loss alarm recover */
        NETDEV_LOG_ALARM_VIDEO_TAMPER_DETECT = 354,              /* Tampering detection alarm */
        NETDEV_LOG_ALARM_VIDEO_TAMPER_RESUME = 355,              /* Tampering detection alarm recover */
        NETDEV_LOG_ALARM_INPUT_SW = 356,              /* Boolean input alarm */
        NETDEV_LOG_ALARM_INPUT_SW_RESUME = 357,              /* Boolean input alarm recover */
        NETDEV_LOG_ALARM_IPC_ONLINE = 358,              /* Device online */
        NETDEV_LOG_ALARM_IPC_OFFLINE = 359,              /* Device offline */

        /* ID  Sub type log ID of exception logs */
        NETDEV_LOG_EXCEP_DISK_ONLINE = 400,              /* Disk online */
        NETDEV_LOG_EXCEP_DISK_OFFLINE = 401,              /* Disk offline */
        NETDEV_LOG_EXCEP_DISK_ERR = 402,              /* Disk exception */
        NETDEV_LOG_EXCEP_STOR_ERR = 403,              /* Storage error */
        NETDEV_LOG_EXCEP_STOR_ERR_RECOVER = 404,              /* Storage error recover */
        NETDEV_LOG_EXCEP_STOR_DISOBEY_PLAN = 405,              /* Not stored as planned */
        NETDEV_LOG_EXCEP_STOR_DISOBEY_PLAN_RECOVER = 406,              /* Not stored as planned recover */
        NETDEV_LOG_EXCEP_ILLEGAL_ACCESS = 407,              /* Illegal access */
        NETDEV_LOG_EXCEP_IP_CONFLICT = 408,              /* IP  IP address conflict */
        NETDEV_LOG_EXCEP_NET_BROKEN = 409,              /* Network disconnection */
        NETDEV_LOG_EXCEP_PIC_REC_ERR = 410,              /* ,  Failed to get captured image */
        NETDEV_LOG_EXCEP_VIDEO_EXCEPTION = 411,              /* ()  Video input exception (for analog channel only) */
        NETDEV_LOG_EXCEP_VIDEO_MISMATCH = 412,              /* Video standards do not match */
        NETDEV_LOG_EXCEP_RESO_MISMATCH = 413,              /* Encoding resolution and front-end resolution do not match */
        NETDEV_LOG_EXCEP_TEMP_EXCE = 414,              /* Temperature exception */
        NETDEV_LOG_EXCEP_RUNOUT_RECORD_SPACE = 415,              /* runOutOfRecordSpace */
        NETDEV_LOG_EXCEP_RUNOUT_IMAGE_SPACE = 416,              /* runOutOfImageSpace */
        NETDEV_LOG_EXCEP_OUT_RECORD_SPACE = 417,              /* recordSpaceUsedUp */
        NETDEV_LOG_EXCEP_OUT_IMAGE_SPACE = 418,              /* imageSpaceUsedUp */
        NETDEV_LOG_EXCEP_ANRIDISASSEMBLY = 419,              /* antiDisassembly Alarm */
        NETDEV_LOG_EXCEP_ANRIDISASSEMBLY_RECOVER = 420,              /* antiDisassembly AlarmClear*/
        NETDEV_LOG_EXCEP_ARRAY_DAMAGE = 421,              /* arrayDamage */
        NETDEV_LOG_EXCEP_ARRAY_DEGRADE = 422,              /* arrayDegrade */
        NETDEV_LOG_EXCEP_RECORD_SNAPSHOT_ABNOR = 423,              /* recordSnapshotAbnormal */
        NETDEV_LOG_EXCEP_NET_BROKEN_RECOVER = 424,              /* networkDisconnectClear */
        NETDEV_LOG_EXCEP_IP_CONFLICT_RECOVER = 425,              /* ipConflictClear */

        /* ID  Sub type log ID of operation logs */
        /* Services */
        NETDEV_LOG_OPSET_LOGIN = 450,              /* User login */
        NETDEV_LOG_OPSET_LOGOUT = 451,              /* Log out */
        NETDEV_LOG_OPSET_USER_ADD = 452,              /* Add user */
        NETDEV_LOG_OPSET_USER_DEL = 453,              /* Delete user */
        NETDEV_LOG_OPSET_USER_MODIFY = 454,              /* Modify user */
        NETDEV_LOG_OPSET_START_REC = 455,              /* Start recording */
        NETDEV_LOG_OPSET_STOP_REC = 456,              /* Stop recording */
        NETDEV_LOG_OPSETR_PLAY_DOWNLOAD = 457,              /* /  Playback and download */
        NETDEV_LOG_OPSET_DOWNLOAD = 458,              /* Download */
        NETDEV_LOG_OPSET_PTZCTRL = 459,              /* PTZ control */
        NETDEV_LOG_OPSET_PREVIEW = 460,              /* Live preview */
        NETDEV_LOG_OPSET_REC_TRACK_START = 461,              /* Start recording route */
        NETDEV_LOG_OPSET_REC_TRACK_STOP = 462,              /* Stop recording route */
        NETDEV_LOG_OPSET_START_TALKBACK = 463,              /* Start two-way audio */
        NETDEV_LOG_OPSET_STOP_TALKBACK = 464,              /* Stop two-way audio */
        NETDEV_LOG_OPSET_IPC_ADD = 465,              /* IPC  Add IP camera */
        NETDEV_LOG_OPSET_IPC_DEL = 466,              /* IPC  Delete IP camera */
        NETDEV_LOG_OPSET_IPC_SET = 467,              /* IPC  Modify IP camera */
        NETDEV_LOG_OPSET_IPC_QUICK_ADD = 468,              /* quickAddIpc*/
        NETDEV_LOG_OPSET_IPC_ADD_BY_NETWORK = 469,              /* addIpcByNetwork */
        NETDEV_LOG_OPSET_IPC_MOD_IP = 470,              /* modifyIpcAddr */

        /* Configurations */
        NETDEV_LOG_OPSET_DEV_BAS_CFG = 500,              /* Basic device information */
        NETDEV_LOG_OPSET_TIME_CFG = 501,              /* Device time */
        NETDEV_LOG_OPSET_SERIAL_CFG = 502,              /* Device serial port */
        NETDEV_LOG_OPSET_CHL_BAS_CFG = 503,              /* Basic channel configuration */
        NETDEV_LOG_OPSET_CHL_NAME_CFG = 504,              /* Channel name configuration */
        NETDEV_LOG_OPSET_CHL_ENC_VIDEO = 505,              /* Video encoding configuration */
        NETDEV_LOG_OPSET_CHL_DIS_VIDEO = 506,              /* Video display configuration */
        NETDEV_LOG_OPSET_PTZ_CFG = 507,              /* PTZ configuration */
        NETDEV_LOG_OPSET_CRUISE_CFG = 508,              /* Patrol route configuration */
        NETDEV_LOG_OPSET_PRESET_CFG = 509,              /* Preset configuration */
        NETDEV_LOG_OPSET_VIDPLAN_CFG = 510,              /* Recording schedule configuration */
        NETDEV_LOG_OPSET_MOTION_CFG = 511,              /* Motion detection configuration */
        NETDEV_LOG_OPSET_VIDLOSS_CFG = 512,              /* Video loss configuration */
        NETDEV_LOG_OPSET_COVER_CFG = 513,              /* Tampering detection configuration */
        NETDEV_LOG_OPSET_MASK_CFG = 514,              /* Privacy mask configuration */
        NETDEV_LOG_OPSET_SCREEN_OSD_CFG = 515,              /* OSD  OSD overlay configuration */
        NETDEV_LOG_OPSET_ALARMIN_CFG = 516,              /* Alarm input configuration */
        NETDEV_LOG_OPSET_ALARMOUT_CFG = 517,              /* Alarm output configuration */
        NETDEV_LOG_OPSET_ALARMOUT_OPEN_MAN = 518,              /* ,  Manually enable alarm output, GUI */
        NETDEV_LOG_OPSET_ALARMOUT_CLOSE_MAN = 519,              /* ,  Manually disable alarm input, GUI */
        NETDEV_LOG_OPSET_ABNORMAL_CFG = 520,              /* Exception configuration */
        NETDEV_LOG_OPSET_HDD_CFG = 521,              /* HDD configuration */
        NETDEV_LOG_OPSET_NET_IP_CFG = 522,             /* TCP/IP  TCP/IP configuration */
        NETDEV_LOG_OPSET_NET_PPPOE_CFG = 523,              /* PPPOE  PPPOE configuration */
        NETDEV_LOG_OPSET_NET_PORT_CFG = 524,              /* Port configuration */
        NETDEV_LOG_OPSET_NET_DDNS_CFG = 525,              /* DDNS  DDNS configuration */
        NETDEV_LOG_OPSET_AUDIO_DETECT = 527,              /* searchExtendDisk */
        NETDEV_LOG_OPSET_SEARCH_EX_DISK = 528,              /* searchExtendDisk */
        NETDEV_LOG_OPSET_ADD_EX_DISK = 529,              /* addExtendDisk */
        NETDEV_LOG_OPSET_DEL_EX_DISK = 530,              /*  deleteExtendDisk */
        NETDEV_LOG_OPSET_SET_EX_DISK = 531,              /* setExtendDisk */
        NETDEV_LOG_OPSET_LIVE_BY_MULTICAST = 532,              /*  liveViewByMulticast */
        NETDEV_LOG_OPSET_BISC_DEV_INFO = 533,              /*  setBasicDeviceInfo */
        NETDEV_LOG_OPSET_PREVIEW_CFG = 534,              /* SetPreviewOnNvr */
        NETDEV_LOG_OPSET_SET_EMAIL = 535,              /* setEmail */
        NETDEV_LOG_OPSET_TEST_EMAIL = 536,              /* testEmail */
        NETDEV_LOG_OPSET_SET_IPCONTROL = 537,              /*  setIPControl */
        NETDEV_LOG_OPSET_PORT_MAP = 538,              /* setPortMap */
        NETDEV_LOG_OPSET_ADD_TAG = 539,              /*  addTag */
        NETDEV_LOG_OPSET_DEL_TAG = 540,              /* 删除录像标签  deleteTag */
        NETDEV_LOG_OPSET_MOD_TAG = 541,              /* 修改录像标签  modifyTag */
        NETDEV_LOG_OPSET_LOCK_RECORD = 542,              /* 录像锁定  lockRecord */
        NETDEV_LOG_OPSET_UNLOCK_RECORD = 543,              /* 录像解锁定  unlockRecord */
        NETDEV_LOG_OPSET_DDNS_UPDATE_SUCCESS = 545,              /* DDNS更新成功  DDNSUpdateSuccess */
        NETDEV_LOG_OPSET_DDNS_INCORRECT_ID = 546,              /* DDNS更新失败，错误的用户名密码  DDNSUpdateFailedIncorrectUsernamePassword */
        NETDEV_LOG_OPSET_DDNS_DOMAIN_NAME_NOT_EXIST = 547,              /* DDNS更新失败，域名不存在  DDNSUpdateFailedDomainNameNotExist */
        NETDEV_LOG_OPSET_DDNS_UPDATE_FAIL = 548,              /* DDNS更新失败  DDNSUpdateFailed */
        NETDEV_LOG_OPSET_HTTP_CFG = 549,              /* HTTPS配置  setHttps */
        NETDEV_LOG_OPSET_IP_OFFLINE_ALARM_CFG = 550,              /* IPC离线报警配置  testDDNSDomain */
        NETDEV_LOG_OPSET_TELNET_CFG = 551,              /* Telnet配置  setTelnet */
        NETDEV_LOG_OPSET_TEST_DDNS_DOMAIN = 552,              /* DDNS域名检测  testDDNSDomain */
        NETDEV_LOG_OPSET_DDNS_DOMAIN_CONFLICT = 553,              /* DDNS域名冲突  DDNSDomainInvalid */
        NETDEV_LOG_OPSET_DDNS_DOMAIN_INVALID = 554,              /* DDNS域名不合法  setDDNS */
        NETDEV_LOG_OPSET_DEL_PRESET = 555,              /* 删除预置位  deletePreset */
        NETDEV_LOG_OPSET_PTZ_3D_POSITION = 556,              /* 云台3D定位  ptz3DPosition */
        NETDEV_LOG_OPSET_SNAPSHOT_SCHEDULE_CFG = 557,              /* 抓图计划配置  setSnapshotSchedule */
        NETDEV_LOG_OPSET_IMAGE_UPLOAD_SCHEDULE_CFG = 558,              /* 图片上传计划配置  setImageUploadSchedule */
        NETDEV_LOG_OPSET_FTP_CFG = 559,              /* FTP服务器配置  setFtpServer */
        NETDEV_LOG_OPSET_TEST_FTP_SERVER = 560,              /* FTP服务器连接测试  testFtpServer */
        NETDEV_LOG_OPSET_START_MANUAL_SNAPSHOT = 561,              /* 手动抓图开启  startManualSnapshot */
        NETDEV_LOG_OPSET_CLOSE_MANUAL_SNAPSHOT = 562,              /* 手动抓图关闭  endManualSnapshot */
        NETDEV_LOG_OPSET_SNAPSHOT_CFG = 563,              /* 抓图参数配置  setSnapshot */
        NETDEV_LOG_OPSET_ADD_HOLIDAY = 564,             /* 添加假日  addHoliday */
        NETDEV_LOG_OPSET_DEL_HOLIDAY = 565,              /* 删除假日  deleteHoliday */
        NETDEV_LOG_OPSET_MOD_HOLIDAY = 566,              /* 修改假日  modifyHoliday */
        NETDEV_LOG_OPSET_ONOFF_HOLIDAY = 567,              /* 开启/关闭假日  enableDisableHoliday */
        NETDEV_LOG_OPSET_ALLOCATE_SPACE = 568,              /* 容量配置  allocateSpace */
        NETDEV_LOG_OPSET_HDD_FULL_POLICY_CFG = 569,              /* 满策略配置  setHddFullPolicy */
        NETDEV_LOG_OPSET_AUDIO_STREAM_CFG = 570,              /* 音频流配置  setAudioStream */
        NETDEV_LOG_OPSET_ARRAY_PROPERTY_CFG = 571,              /* 阵列属性配置  setArrayProperty */
        NETDEV_LOG_OPSET_HOT_SPACE_DISK_CFG = 572,              /* 热备盘配置  setHotSpaceDisk */
        NETDEV_LOG_OPSET_CREAT_ARRAY = 573,              /* 手动创建阵列  createArray */
        NETDEV_LOG_OPSET_ONE_CLICK_CREAT_ARRAY = 574,              /* 一键创建阵列  oneClickCreateArray */
        NETDEV_LOG_OPSET_REBUILD_ARRAY = 575,              /* 重建阵列  rebuildArray */
        NETDEV_LOG_OPSET_DEL_ARRAY = 576,              /* 删除阵列  deleteArray */
        NETDEV_LOG_OPSET_ENABLE_RAID = 577,              /* 开启RAID模式  enableRaid */
        NETDEV_LOG_OPSET_DISABLE_RAID = 578,              /* 关闭RAID模式  disableRaid */
        NETDEV_LOG_OPSET_TEST_SMART = 579,              /* S.M.A.R.T检测  testSmart */
        NETDEV_LOG_OPSET_SMART_CFG = 580,              /* S.M.A.R.T配置  setSmart */
        NETDEV_LOG_OPSET_BAD_SECTOR_DETECT = 581,              /* 坏道检测  badSectorDetect */
        NETDEV_LOG_OPSET_AUDIO_ALARM_DURATION = 582,              /* 配置声音报警时长  setAudioAlarmDuration */
        NETDEV_LOG_OPSET_CLR_AUDIO_ALARM = 583,             /* 清除声音报警  clearAudioAlarm */
        NETDEV_LOG_OPSET_IPC_TIME_SYNC_CFG = 584,              /* 配置同步摄像机时间  setIpcTimeSync */
        NETDEV_LOG_OPSET_ENABLE_DISK_GROUP = 585,              /* 开启盘组  enableDiskGroup */
        NETDEV_LOG_OPSET_DISABLE_DISK_GRRUOP = 586,              /* 关闭盘组  disableDiskGroup */
        NETDEV_LOG_OPSET_ONVIF_AUTH_CFG = 587,              /* ONVIF认证配置  setOnvifAuth */
        NETDEV_LOG_OPSET_8021X_CFG = 588,              /* 配置802.1X  set8021x */
        NETDEV_LOG_OPSET_ARP_PROTECTION_CFG = 589,              /* 配置ARP防攻击  setArpProtection */
        NETDEV_LOG_OPSET_SMART_BASIC_INFO_CFG = 590,             /* 智能报警基本信息配置  setSmartBasicInfo */
        NETDEV_LOG_OPSET_CROSS_LINE_DETECT_CFG = 591,              /* 越界检测配置  setCrossLineDetection */
        NETDEV_LOG_OPSET_INSTRUSION_DETECT_CFG = 592,              /* 区域入侵配置  setIntrusionDetection */
        NETDEV_LOG_OPSET_PEOPLE_COUNT_CFG = 593,              /* 客流量配置  setPeopleCount */
        NETDEV_LOG_OPSET_FACE_DETECT_CFG = 594,              /* 人脸检测配置  setFaceDetection */
        NETDEV_LOG_OPSET_FISHEYE_CFG = 595,              /* 鱼眼配置  setFisheye */
        NETDEV_LOG_OPSET_CUSTOM_PROTOCOL_CFG = 596,              /* 自定义协议配置  setCustomProtocol */
        NETDEV_LOG_OPSET_BEHAVIOR_SEARCH = 597,              /* 行为检索  behaviorSearch */
        NETDEV_LOG_OPSET_FACE_SEARCH = 598,              /* 人脸检索  faceSearch */
        NETDEV_LOG_OPSET_PEOPLE_COUNT = 599,              /* 客流量统计  peopleCount */

        /* Maintenance */
        NETDEV_LOG_OPSET_START_DVR = 600,              /* Start up*/
        NETDEV_LOG_OPSET_STOP_DVR = 601,              /* Shut down */
        NETDEV_LOG_OPSET_REBOOT_DVR = 602,              /* Restart device */
        NETDEV_LOG_OPSET_UPGRADE = 603,              /* Version upgrade */
        NETDEV_LOG_OPSET_LOGFILE_EXPORT = 604,              /* Export log files */
        NETDEV_LOG_OPSET_CFGFILE_EXPORT = 605,              /* Export configuration files */
        NETDEV_LOG_OPSET_CFGFILE_IMPORT = 606,              /* Import configuration files */
        NETDEV_LOG_OPSET_CONF_SIMPLE_INIT = 607,              /* Export configuration files */
        NETDEV_LOG_OPSET_CONF_ALL_INIT = 608,               /* Restore to factory settings */
        NETDEV_LOG_OPSET_VCA_BACKUP = 700,              /* 智能备份  vcaBackup */
        NETDEV_LOG_OPSET_3G4G_CFG = 701,              /* 3G/4G配置  set3g4g */
        NETDEV_LOG_OPSET_MOUNT_EXTENDED_DISK = 702,              /* 加载扩展硬盘 Mount extended disk*/
        NETDEV_LOG_OPSET_UNMOUNT_EXTENDED_DISK = 703,              /* 卸载扩展硬盘 Unmount extended disk*/
        NETDEV_LOG_OPSET_FORCE_USER_OFFLINE = 704,              /* 强制用户下线 Force user off line*/

        NETDEV_LOG_OPSET_AUTO_FUNCTION = 709,              /* 自动维护  autoFunction */
        NETDEV_LOG_OPSET_IPC_UPRAGDE = 710,              /* 摄像机升级  ipcUpgrade */
        NETDEV_LOG_OPSET_RESTORE_IPC_DEFAULTS = 711,              /* 摄像机恢复默认配置  restoreIpcDefaults */
        NETDEV_LOG_OPSET_ADD_TRANSACTION = 712,              /* 添加交易配置  addTransaction */
        NETDEV_LOG_OPSET_MOD_TRANSACTION = 713,              /* 修改交易配置  modifyTransaction */
        NETDEV_LOG_OPSET_DEL_TRANSACTION = 714,              /* 删除交易配置  deleteTransaction */
        NETDEV_LOG_OPSET_POS_OSD = 715,              /* POS显示配置设置  setPosOsd */
        NETDEV_LOG_OPSET_ADD_HOT_SPACE_DEV = 716,              /* 添加备机  addHotSpaceDevice */
        NETDEV_LOG_OPSET_DEL_HOT_SPACE_DEV = 717,              /* 删除备机  deleteHotSpaceDevice */
        NETDEV_LOG_OPSET_MOD_HOT_SPACE_DEV = 718,              /* 修改备机  modifyHotSpaceDevice */
        NETDEV_LOG_OPSET_DEL_WORK_DEV = 719,              /* 删除工作机  deleteWorkDevice */
        NETDEV_LOG_OPSET_WORKMODE_TO_NORMAL_CFG = 720,              /* 设置工作机模式  SetWorkModeToNormal */
        NETDEV_LOG_OPSET_WORKMODE_TO_HOTSPACE_CFG = 721,              /* 设置备机模式  SetWorkModeToHotSpace */
        NETDEV_LOG_OPSET_AUTO_GUARD_CFG = 723,              /* 守望配置  setAutoGuard */
        NETDEV_LOG_OPSET_MULTICAST_CFG = 724,              /* 组播配置  SetMulticast */
        NETDEV_LOG_OPSET_DEFOCUS_DETECT_CFG = 725,              /* 虚焦检测配置 Set defocus detection*/
        NETDEV_LOG_OPSET_SCENECHANGE_CFG = 726,              /* 场景变更配置 Set scene change detection*/
        NETDEV_LOG_OPSET_AUTO_TRCAK_CFG = 727,              /* 智能跟踪配置 Set auto tracking*/
        NETDEV_LOG_OPSET_SORT_CAMERA_CFG = 728,              /* 通道排序 Sort camera*/
        NETDEV_LOG_OPSET_WATER_MARK_CFG = 729              /* 视频水印配置 Set watermark*/

    }

}
