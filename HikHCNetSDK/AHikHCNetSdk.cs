using System;
using System.Collections.Generic;
using System.Data.NHInterfaces;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.HikHCNetSDK
{
    /// <summary>
    /// 海康威视网络SDK
    /// </summary>
    public static class HikHCNetSdk
    {
        /// <summary>
        /// SDK文件名称
        /// </summary>
        public const string DllFileName = "HCNetSDK.dll";
        /// <summary>
        /// SDK虚拟路径
        /// </summary>
        public const String DllVirtualPath = @"plugins\hikhcnetsdk";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String DllFileNameX86 = $@".\{DllVirtualPath}\x86\{DllFileName}";
        /// <summary>
        /// x64的dll目录
        /// </summary>
        public const String DllFileNameX64 = $@".\{DllVirtualPath}\x64\{DllFileName}";
        /// <summary>
        /// 基路径
        /// </summary>
        public static String BaseFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// SDK全路径
        /// </summary>
        public static String DllFullPath { get; } = Path.GetFullPath(DllVirtualPath);
        #region // 参数定义
        #region // 公共参数
        //SDK类型
        public const int SDK_PLAYMPEG4 = 1;//播放库
        public const int SDK_HCNETSDK = 2;//网络库

        public const int NAME_LEN = 32;//用户名长度
        public const int PASSWD_LEN = 16;//密码长度
        public const int GUID_LEN = 16;      //GUID长度
        public const int DEV_TYPE_NAME_LEN = 24;      //设备类型名称长度
        public const int MAX_NAMELEN = 16;//DVR本地登陆名
        public const int MAX_RIGHT = 32;//设备支持的权限（1-12表示本地权限，13-32表示远程权限）
        public const int SERIALNO_LEN = 48;//序列号长度
        public const int MACADDR_LEN = 6;//mac地址长度
        public const int MAX_ETHERNET = 2;//设备可配以太网络
        public const int MAX_NETWORK_CARD = 4; //设备可配最大网卡数目
        public const int PATHNAME_LEN = 128;//路径长度

        public const int MAX_NUMBER_LEN = 32;	//号码最大长度
        public const int MAX_NAME_LEN = 128; //设备名称最大长度


        public const int MAX_TIMESEGMENT = 4;//8000设备最大时间段数
        public const int MAX_ICR_NUM = 8;   //抓拍机红外滤光片预置点数

        public const int MAX_SHELTERNUM = 4;//8000设备最大遮挡区域数
        public const int PHONENUMBER_LEN = 32;//pppoe拨号号码最大长度

        public const int MAX_DISKNUM = 16;//8000设备最大硬盘数
        public const int MAX_DISKNUM_V10 = 8;//1.2版本之前版本

        public const int MAX_WINDOW_V30 = 32;//9000设备本地显示最大播放窗口数
        public const int MAX_WINDOW = 16;//8000设备最大硬盘数
        public const int MAX_VGA_V30 = 4;//9000设备最大可接VGA数
        public const int MAX_VGA = 1;//8000设备最大可接VGA数

        public const int MAX_USERNUM_V30 = 32;//9000设备最大用户数
        public const int MAX_USERNUM = 16;//8000设备最大用户数
        public const int MAX_EXCEPTIONNUM_V30 = 32;//9000设备最大异常处理数
        public const int MAX_EXCEPTIONNUM = 16;//8000设备最大异常处理数
        public const int MAX_LINK = 6;//8000设备单通道最大视频流连接数
        public const int MAX_ITC_EXCEPTIONOUT = 32;//抓拍机最大报警输出

        public const int MAX_DECPOOLNUM = 4;//单路解码器每个解码通道最大可循环解码数
        public const int MAX_DECNUM = 4;//单路解码器的最大解码通道数（实际只有一个，其他三个保留）
        public const int MAX_TRANSPARENTNUM = 2;//单路解码器可配置最大透明通道数
        public const int MAX_CYCLE_CHAN = 16; //单路解码器最大轮循通道数
        public const int MAX_CYCLE_CHAN_V30 = 64;//最大轮询通道数（扩展）
        public const int MAX_DIRNAME_LENGTH = 80;//最大目录长度

        public const int MAX_STRINGNUM_V30 = 8;//9000设备最大OSD字符行数数
        public const int MAX_STRINGNUM = 4;//8000设备最大OSD字符行数数
        public const int MAX_STRINGNUM_EX = 8;//8000定制扩展
        public const int MAX_AUXOUT_V30 = 16;//9000设备最大辅助输出数
        public const int MAX_AUXOUT = 4;//8000设备最大辅助输出数
        public const int MAX_HD_GROUP = 16;//9000设备最大硬盘组数
        public const int MAX_NFS_DISK = 8; //8000设备最大NFS硬盘数

        public const int IW_ESSID_MAX_SIZE = 32;//WIFI的SSID号长度
        public const int IW_ENCODING_TOKEN_MAX = 32;//WIFI密锁最大字节数
        public const int WIFI_WEP_MAX_KEY_COUNT = 4;
        public const int WIFI_WEP_MAX_KEY_LENGTH = 33;
        public const int WIFI_WPA_PSK_MAX_KEY_LENGTH = 63;
        public const int WIFI_WPA_PSK_MIN_KEY_LENGTH = 8;
        public const int WIFI_MAX_AP_COUNT = 20;
        public const int MAX_SERIAL_NUM = 64;//最多支持的透明通道路数
        public const int MAX_DDNS_NUMS = 10;//9000设备最大可配ddns数
        public const int MAX_EMAIL_ADDR_LEN = 48;//最大email地址长度
        public const int MAX_EMAIL_PWD_LEN = 32;//最大email密码长度

        public const int MAXPROGRESS = 100;//回放时的最大百分率
        public const int MAX_SERIALNUM = 2;//8000设备支持的串口数 1-232， 2-485
        public const int CARDNUM_LEN = 20;//卡号长度
        public const int CARDNUM_LEN_OUT = 32; //外部结构体卡号长度
        public const int MAX_VIDEOOUT_V30 = 4;//9000设备的视频输出数
        public const int MAX_VIDEOOUT = 2;//8000设备的视频输出数

        public const int MAX_PRESET_V30 = 256;// 9000设备支持的云台预置点数
        public const int MAX_TRACK_V30 = 256;// 9000设备支持的云台轨迹数
        public const int MAX_CRUISE_V30 = 256;// 9000设备支持的云台巡航数
        public const int MAX_PRESET = 128;// 8000设备支持的云台预置点数 
        public const int MAX_TRACK = 128;// 8000设备支持的云台轨迹数
        public const int MAX_CRUISE = 128;// 8000设备支持的云台巡航数 

        public const int CRUISE_MAX_PRESET_NUMS = 32;// 一条巡航最多的巡航点 

        public const int MAX_SERIAL_PORT = 8;//9000设备支持232串口数
        public const int MAX_PREVIEW_MODE = 8;// 设备支持最大预览模式数目 1画面,4画面,9画面,16画面.... 
        public const int MAX_MATRIXOUT = 16;// 最大模拟矩阵输出个数 
        public const int LOG_INFO_LEN = 11840; // 日志附加信息 
        public const int DESC_LEN = 16;// 云台描述字符串长度 
        public const int PTZ_PROTOCOL_NUM = 200;// 9000最大支持的云台协议数 

        public const int MAX_AUDIO = 1;//8000语音对讲通道数
        public const int MAX_AUDIO_V30 = 2;//9000语音对讲通道数
        public const int MAX_CHANNUM = 16;//8000设备最大通道数
        public const int MAX_ALARMIN = 16;//8000设备最大报警输入数
        public const int MAX_ALARMOUT = 4;//8000设备最大报警输出数
        //9000 IPC接入
        public const int MAX_ANALOG_CHANNUM = 32;//最大32个模拟通道
        public const int MAX_ANALOG_ALARMOUT = 32; //最大32路模拟报警输出 
        public const int MAX_ANALOG_ALARMIN = 32;//最大32路模拟报警输入

        public const int MAX_IP_DEVICE = 32;//允许接入的最大IP设备数
        public const int MAX_IP_DEVICE_V40 = 64;//允许接入的最大IP设备数
        public const int MAX_IP_CHANNEL = 32;//允许加入的最多IP通道数
        public const int MAX_IP_ALARMIN = 128;//允许加入的最多报警输入数
        public const int MAX_IP_ALARMOUT = 64;//允许加入的最多报警输出数
        public const int MAX_IP_ALARMIN_V40 = 4096;    //允许加入的最多报警输入数
        public const int MAX_IP_ALARMOUT_V40 = 4096;    //允许加入的最多报警输出数

        public const int MAX_RECORD_FILE_NUM = 20;      // 每次删除或者刻录的最大文件数

        //SDK_V31 ATM
        public const int MAX_ATM_NUM = 1;
        public const int MAX_ACTION_TYPE = 12;
        public const int ATM_FRAMETYPE_NUM = 4;
        public const int MAX_ATM_PROTOCOL_NUM = 1025;
        public const int ATM_PROTOCOL_SORT = 4;
        public const int ATM_DESC_LEN = 32;
        // SDK_V31 ATM

        /* 最大支持的通道数 最大模拟加上最大IP支持 */
        public const int MAX_CHANNUM_V30 = MAX_ANALOG_CHANNUM + MAX_IP_CHANNEL;//64
        public const int MAX_ALARMOUT_V30 = MAX_ANALOG_ALARMOUT + MAX_IP_ALARMOUT;//96
        public const int MAX_ALARMIN_V30 = MAX_ANALOG_ALARMIN + MAX_IP_ALARMIN;//160

        public const int MAX_CHANNUM_V40 = 512;
        public const int MAX_ALARMOUT_V40 = MAX_IP_ALARMOUT_V40 + MAX_ANALOG_ALARMOUT;//4128
        public const int MAX_ALARMIN_V40 = MAX_IP_ALARMIN_V40 + MAX_ANALOG_ALARMOUT;//4128
        public const int MAX_MULTI_AREA_NUM = 24;

        public const int MAX_HUMAN_PICTURE_NUM = 10;   //最大照片数
        public const int MAX_HUMAN_BIRTHDATE_LEN = 10;

        public const int MAX_LAYERNUMS = 32;

        public const int MAX_ROIDETECT_NUM = 8;    //支持的ROI区域数
        public const int MAX_LANERECT_NUM = 5;    //最大车牌识别区域数
        public const int MAX_FORTIFY_NUM = 10;   //最大布防个数
        public const int MAX_INTERVAL_NUM = 4;    //最大时间间隔个数
        public const int MAX_CHJC_NUM = 3;    //最大车辆省份简称字符个数
        public const int MAX_VL_NUM = 5;    //最大虚拟线圈个数
        public const int MAX_DRIVECHAN_NUM = 16;   //最大车道数
        public const int MAX_COIL_NUM = 3;    //最大线圈个数
        public const int MAX_SIGNALLIGHT_NUM = 6;   //最大信号灯个数
        public const int LEN_32 = 32;
        public const int LEN_31 = 31;
        public const int MAX_CABINET_COUNT = 8;    //最大支持机柜数量
        public const int MAX_ID_LEN = 48;
        public const int MAX_PARKNO_LEN = 16;
        public const int MAX_ALARMREASON_LEN = 32;
        public const int MAX_UPGRADE_INFO_LEN = 48; //获取升级文件匹配信息(模糊升级)
        public const int MAX_CUSTOMDIR_LEN = 32; //自定义目录长度

        public const int MAX_TRANSPARENT_CHAN_NUM = 4;   //每个串口允许建立的最大透明通道数
        public const int MAX_TRANSPARENT_ACCESS_NUM = 4;   //每个监听端口允许接入的最大主机数

        //ITS
        public const int MAX_PARKING_STATUS = 8;    //车位状态 0代表无车，1代表有车，2代表压线(优先级最高), 3特殊车位 
        public const int MAX_PARKING_NUM = 4;    //一个通道最大4个车位 (从左到右车位 数组0～3)

        public const int MAX_ITS_SCENE_NUM = 16;   //最大场景数量
        public const int MAX_SCENE_TIMESEG_NUM = 16;   //最大场景时间段数量
        public const int MAX_IVMS_IP_CHANNEL = 128;  //最大IP通道数
        public const int DEVICE_ID_LEN = 48;   //设备编号长度
        public const int MONITORSITE_ID_LEN = 48;   //监测点编号长度
        public const int MAX_AUXAREA_NUM = 16;   //辅助区域最大数目
        public const int MAX_SLAVE_CHANNEL_NUM = 16;   //最大从通道数量

        public const int MAX_SCH_TASKS_NUM = 10;

        public const int MAX_SERVERID_LEN = 64; //最大服务器ID的长度
        public const int MAX_SERVERDOMAIN_LEN = 128; //服务器域名最大长度
        public const int MAX_AUTHENTICATEID_LEN = 64; //认证ID最大长度
        public const int MAX_AUTHENTICATEPASSWD_LEN = 32; //认证密码最大长度
        public const int MAX_SERVERNAME_LEN = 64; //最大服务器用户名 
        public const int MAX_COMPRESSIONID_LEN = 64; //编码ID的最大长度
        public const int MAX_SIPSERVER_ADDRESS_LEN = 128; //SIP服务器地址支持域名和IP地址
        //压线报警
        public const int MAX_PlATE_NO_LEN = 32;   //车牌号码最大长度 2013-09-27
        public const int UPNP_PORT_NUM = 12;      //upnp端口映射端口数目


        public const int MAX_LOCAL_ADDR_LEN = 96;		//SOCKS最大本地网段个数
        public const int MAX_COUNTRY_NAME_LEN = 4;		//国家简写名称长度

        public const int THERMOMETRY_ALARMRULE_NUM = 40; //热成像报警规则数

        public const int ACS_CARD_NO_LEN = 32; //门禁卡号长度    
        public const int MAX_ID_NUM_LEN = 32;  //最大身份证号长度
        public const int MAX_ID_NAME_LEN = 128;   //最大姓名长度
        public const int MAX_ID_ADDR_LEN = 280;   //最大住址长度
        public const int MAX_ID_ISSUING_AUTHORITY_LEN = 128; //最大签发机关长度

        public const int MAX_CARD_RIGHT_PLAN_NUM = 4;   //卡权限最大计划个数
        public const int MAX_GROUP_NUM_128 = 128; //最大群组数
        public const int MAX_CARD_READER_NUM = 64;  //最大读卡器数
        public const int MAX_SNEAK_PATH_NODE = 8;   //最大后续读卡器数
        public const int MAX_MULTI_DOOR_INTERLOCK_GROUP = 8;   //最大多门互锁组数
        public const int MAX_INTER_LOCK_DOOR_NUM = 8;   //一个多门互锁组中最大互锁门数
        public const int MAX_CASE_SENSOR_NUM = 8;  //最大case sensor触发器数
        public const int MAX_DOOR_NUM_256 = 256; //最大门数
        public const int MAX_READER_ROUTE_NUM = 16;  //最大刷卡循序路径 
        public const int MAX_FINGER_PRINT_NUM = 10;  //最大指纹个数
        public const int MAX_CARD_READER_NUM_512 = 512; //最大读卡器数
        public const int NET_SDK_MULTI_CARD_GROUP_NUM_20 = 20;   //单门最大多重卡组数
        public const int CARD_PASSWORD_LEN = 8;   //卡密码长度
        public const int MAX_DOOR_CODE_LEN = 8; //房间代码长度
        public const int MAX_LOCK_CODE_LEN = 8; //锁代码长度

        public const int MAX_NOTICE_NUMBER_LEN = 32;   //公告编号最大长度
        public const int MAX_NOTICE_THEME_LEN = 64;   //公告主题最大长度
        public const int MAX_NOTICE_DETAIL_LEN = 1024; //公告详情最大长度
        public const int MAX_NOTICE_PIC_NUM = 6;    //公告信息最大图片数量
        public const int MAX_DEV_NUMBER_LEN = 32;   //设备编号最大长度
        public const int LOCK_NAME_LEN = 32;  //锁名称

        public const int GROUP_NAME_LEN = 32;  //群组名称长度
        public const int GROUP_COMBINATION_NUM = 8;   //群组组合数
        public const int MULTI_CARD_GROUP_NUM = 4;   //单门最大多重卡组数

        public const int NET_SDK_EMPLOYEE_NO_LEN = 32;  //工号长度
        public const int NET_SDK_UUID_LEN = 36;  //UUID长度
        public const int NET_SDK_EHOME_KEY_LEN = 32;  //EHome Key长度

        public const int NET_DEV_NAME_LEN = 64;  //设备名称长度
        public const int NET_DEV_TYPE_NAME_LEN = 64; //设备类型名称长度

        public const int VCA_MAX_POLYGON_POINT_NUM = 10;//检测区域最多支持10个点的多边形
        public const int MAX_RULE_NUM = 8;//最多规则条数
        public const int MAX_TARGET_NUM = 30;//最多目标个数
        public const int MAX_CALIB_PT = 6;//最大标定点个数
        public const int MIN_CALIB_PT = 4;//最小标定点个数
        public const int MAX_TIMESEGMENT_2 = 2;//最大时间段数
        public const int MAX_LICENSE_LEN = 16;//车牌号最大长度
        public const int MAX_PLATE_NUM = 3;//车牌个数
        public const int MAX_MASK_REGION_NUM = 4;//最多四个屏蔽区域
        public const int MAX_SEGMENT_NUM = 6;//摄像机标定最大样本线数目
        public const int MIN_SEGMENT_NUM = 3;//摄像机标定最小样本线数目  
        public const int MAX_CATEGORY_LEN = 8;       //车牌附加信息最大字符
        public const int SERIAL_NO_LEN = 16;      //泊车位编号
        public const int ILLEGAL_LEN = 32;      //违法代码长度

        //码流连接方式
        public const int NORMALCONNECT = 1;
        public const int MEDIACONNECT = 2;

        //设备型号(大类)
        public const int HCDVR = 1;
        public const int MEDVR = 2;
        public const int PCDVR = 3;
        public const int HC_9000 = 4;
        public const int HF_I = 5;
        public const int PCNVR = 6;
        public const int HC_76NVR = 8;

        //NVR类型
        public const int DS8000HC_NVR = 0;
        public const int DS9000HC_NVR = 1;
        public const int DS8000ME_NVR = 2;

        /*******************全局错误码 begin**********************/
        public const int NET_DVR_NOERROR = 0;//没有错误
        public const int NET_DVR_PASSWORD_ERROR = 1;//用户名密码错误
        public const int NET_DVR_NOENOUGHPRI = 2;//权限不足
        public const int NET_DVR_NOINIT = 3;//没有初始化
        public const int NET_DVR_CHANNEL_ERROR = 4;//通道号错误
        public const int NET_DVR_OVER_MAXLINK = 5;//连接到DVR的客户端个数超过最大
        public const int NET_DVR_VERSIONNOMATCH = 6;//版本不匹配
        public const int NET_DVR_NETWORK_FAIL_CONNECT = 7;//连接服务器失败
        public const int NET_DVR_NETWORK_SEND_ERROR = 8;//向服务器发送失败
        public const int NET_DVR_NETWORK_RECV_ERROR = 9;//从服务器接收数据失败
        public const int NET_DVR_NETWORK_RECV_TIMEOUT = 10;//从服务器接收数据超时
        public const int NET_DVR_NETWORK_ERRORDATA = 11;//传送的数据有误
        public const int NET_DVR_ORDER_ERROR = 12;//调用次序错误
        public const int NET_DVR_OPERNOPERMIT = 13;//无此权限
        public const int NET_DVR_COMMANDTIMEOUT = 14;//DVR命令执行超时
        public const int NET_DVR_ERRORSERIALPORT = 15;//串口号错误
        public const int NET_DVR_ERRORALARMPORT = 16;//报警端口错误
        public const int NET_DVR_PARAMETER_ERROR = 17;//参数错误
        public const int NET_DVR_CHAN_EXCEPTION = 18;//服务器通道处于错误状态
        public const int NET_DVR_NODISK = 19;//没有硬盘
        public const int NET_DVR_ERRORDISKNUM = 20;//硬盘号错误
        public const int NET_DVR_DISK_FULL = 21;//服务器硬盘满
        public const int NET_DVR_DISK_ERROR = 22;//服务器硬盘出错
        public const int NET_DVR_NOSUPPORT = 23;//服务器不支持
        public const int NET_DVR_BUSY = 24;//服务器忙
        public const int NET_DVR_MODIFY_FAIL = 25;//服务器修改不成功
        public const int NET_DVR_PASSWORD_FORMAT_ERROR = 26;//密码输入格式不正确
        public const int NET_DVR_DISK_FORMATING = 27;//硬盘正在格式化，不能启动操作
        public const int NET_DVR_DVRNORESOURCE = 28;//DVR资源不足
        public const int NET_DVR_DVROPRATEFAILED = 29;//DVR操作失败
        public const int NET_DVR_OPENHOSTSOUND_FAIL = 30;//打开PC声音失败
        public const int NET_DVR_DVRVOICEOPENED = 31;//服务器语音对讲被占用
        public const int NET_DVR_TIMEINPUTERROR = 32;//时间输入不正确
        public const int NET_DVR_NOSPECFILE = 33;//回放时服务器没有指定的文件
        public const int NET_DVR_CREATEFILE_ERROR = 34;//创建文件出错
        public const int NET_DVR_FILEOPENFAIL = 35;//打开文件出错
        public const int NET_DVR_OPERNOTFINISH = 36; //上次的操作还没有完成
        public const int NET_DVR_GETPLAYTIMEFAIL = 37;//获取当前播放的时间出错
        public const int NET_DVR_PLAYFAIL = 38;//播放出错
        public const int NET_DVR_FILEFORMAT_ERROR = 39;//文件格式不正确
        public const int NET_DVR_DIR_ERROR = 40;//路径错误
        public const int NET_DVR_ALLOC_RESOURCE_ERROR = 41;//资源分配错误
        public const int NET_DVR_AUDIO_MODE_ERROR = 42;//声卡模式错误
        public const int NET_DVR_NOENOUGH_BUF = 43;//缓冲区太小
        public const int NET_DVR_CREATESOCKET_ERROR = 44;//创建SOCKET出错
        public const int NET_DVR_SETSOCKET_ERROR = 45;//设置SOCKET出错
        public const int NET_DVR_MAX_NUM = 46;//个数达到最大
        public const int NET_DVR_USERNOTEXIST = 47;//用户不存在
        public const int NET_DVR_WRITEFLASHERROR = 48;//写FLASH出错
        public const int NET_DVR_UPGRADEFAIL = 49;//DVR升级失败
        public const int NET_DVR_CARDHAVEINIT = 50;//解码卡已经初始化过
        public const int NET_DVR_PLAYERFAILED = 51;//调用播放库中某个函数失败
        public const int NET_DVR_MAX_USERNUM = 52;//设备端用户数达到最大
        public const int NET_DVR_GETLOCALIPANDMACFAIL = 53;//获得客户端的IP地址或物理地址失败
        public const int NET_DVR_NOENCODEING = 54;//该通道没有编码
        public const int NET_DVR_IPMISMATCH = 55;//IP地址不匹配
        public const int NET_DVR_MACMISMATCH = 56;//MAC地址不匹配
        public const int NET_DVR_UPGRADELANGMISMATCH = 57;//升级文件语言不匹配
        public const int NET_DVR_MAX_PLAYERPORT = 58;//播放器路数达到最大
        public const int NET_DVR_NOSPACEBACKUP = 59;//备份设备中没有足够空间进行备份
        public const int NET_DVR_NODEVICEBACKUP = 60;//没有找到指定的备份设备
        public const int NET_DVR_PICTURE_BITS_ERROR = 61;//图像素位数不符，限24色
        public const int NET_DVR_PICTURE_DIMENSION_ERROR = 62;//图片高*宽超限， 限128*256
        public const int NET_DVR_PICTURE_SIZ_ERROR = 63;//图片大小超限，限100K
        public const int NET_DVR_LOADPLAYERSDKFAILED = 64;//载入当前目录下Player Sdk出错
        public const int NET_DVR_LOADPLAYERSDKPROC_ERROR = 65;//找不到Player Sdk中某个函数入口
        public const int NET_DVR_LOADDSSDKFAILED = 66;//载入当前目录下DSsdk出错
        public const int NET_DVR_LOADDSSDKPROC_ERROR = 67;//找不到DsSdk中某个函数入口
        public const int NET_DVR_DSSDK_ERROR = 68;//调用硬解码库DsSdk中某个函数失败
        public const int NET_DVR_VOICEMONOPOLIZE = 69;//声卡被独占
        public const int NET_DVR_JOINMULTICASTFAILED = 70;//加入多播组失败
        public const int NET_DVR_CREATEDIR_ERROR = 71;//建立日志文件目录失败
        public const int NET_DVR_BINDSOCKET_ERROR = 72;//绑定套接字失败
        public const int NET_DVR_SOCKETCLOSE_ERROR = 73;//socket连接中断，此错误通常是由于连接中断或目的地不可达
        public const int NET_DVR_USERID_ISUSING = 74;//注销时用户ID正在进行某操作
        public const int NET_DVR_SOCKETLISTEN_ERROR = 75;//监听失败
        public const int NET_DVR_PROGRAM_EXCEPTION = 76;//程序异常
        public const int NET_DVR_WRITEFILE_FAILED = 77;//写文件失败
        public const int NET_DVR_FORMAT_READONLY = 78;//禁止格式化只读硬盘
        public const int NET_DVR_WITHSAMEUSERNAME = 79;//用户配置结构中存在相同的用户名
        public const int NET_DVR_DEVICETYPE_ERROR = 80;//导入参数时设备型号不匹配
        public const int NET_DVR_LANGUAGE_ERROR = 81;//导入参数时语言不匹配
        public const int NET_DVR_PARAVERSION_ERROR = 82;//导入参数时软件版本不匹配
        public const int NET_DVR_IPCHAN_NOTALIVE = 83; //预览时外接IP通道不在线
        public const int NET_DVR_RTSP_SDK_ERROR = 84;//加载高清IPC通讯库StreamTransClient.dll失败
        public const int NET_DVR_CONVERT_SDK_ERROR = 85;//加载转码库失败
        public const int NET_DVR_IPC_COUNT_OVERFLOW = 86;//超出最大的ip接入通道数
        public const int NET_DVR_USER_LOCKED = 153;

        public const int NET_PLAYM4_NOERROR = 500;//no error
        public const int NET_PLAYM4_PARA_OVER = 501;//input parameter is invalid
        public const int NET_PLAYM4_ORDER_ERROR = 502;//The order of the function to be called is error
        public const int NET_PLAYM4_TIMER_ERROR = 503;//Create multimedia clock failed
        public const int NET_PLAYM4_DEC_VIDEO_ERROR = 504;//Decode video data failed
        public const int NET_PLAYM4_DEC_AUDIO_ERROR = 505;//Decode audio data failed
        public const int NET_PLAYM4_ALLOC_MEMORY_ERROR = 506;//Allocate memory failed
        public const int NET_PLAYM4_OPEN_FILE_ERROR = 507;//Open the file failed
        public const int NET_PLAYM4_CREATE_OBJ_ERROR = 508;//Create thread or event failed
        public const int NET_PLAYM4_CREATE_DDRAW_ERROR = 509;//Create DirectDraw object failed
        public const int NET_PLAYM4_CREATE_OFFSCREEN_ERROR = 510;//failed when creating off-screen surface
        public const int NET_PLAYM4_BUF_OVER = 511;//buffer is overflow
        public const int NET_PLAYM4_CREATE_SOUND_ERROR = 512;//failed when creating audio device
        public const int NET_PLAYM4_SET_VOLUME_ERROR = 513;//Set volume failed
        public const int NET_PLAYM4_SUPPORT_FILE_ONLY = 514;//The function only support play file
        public const int NET_PLAYM4_SUPPORT_STREAM_ONLY = 515;//The function only support play stream
        public const int NET_PLAYM4_SYS_NOT_SUPPORT = 516;//System not support
        public const int NET_PLAYM4_FILEHEADER_UNKNOWN = 517;//No file header
        public const int NET_PLAYM4_VERSION_INCORRECT = 518;//The version of decoder and encoder is not adapted
        public const int NET_PALYM4_INIT_DECODER_ERROR = 519;//Initialize decoder failed
        public const int NET_PLAYM4_CHECK_FILE_ERROR = 520;//The file data is unknown
        public const int NET_PLAYM4_INIT_TIMER_ERROR = 521;//Initialize multimedia clock failed
        public const int NET_PLAYM4_BLT_ERROR = 522;//Blt failed
        public const int NET_PLAYM4_UPDATE_ERROR = 523;//Update failed
        public const int NET_PLAYM4_OPEN_FILE_ERROR_MULTI = 524;//openfile error, streamtype is multi
        public const int NET_PLAYM4_OPEN_FILE_ERROR_VIDEO = 525;//openfile error, streamtype is video
        public const int NET_PLAYM4_JPEG_COMPRESS_ERROR = 526;//JPEG compress error
        public const int NET_PLAYM4_EXTRACT_NOT_SUPPORT = 527;//Don't support the version of this file
        public const int NET_PLAYM4_EXTRACT_DATA_ERROR = 528;//extract video data failed
        /*******************全局错误码 end**********************/

        /*************************************************
        NET_DVR_IsSupport()返回值
        1－9位分别表示以下信息（位与是TRUE)表示支持；
        **************************************************/
        public const int NET_DVR_SUPPORT_DDRAW = 1;//支持DIRECTDRAW，如果不支持，则播放器不能工作
        public const int NET_DVR_SUPPORT_BLT = 2;//显卡支持BLT操作，如果不支持，则播放器不能工作
        public const int NET_DVR_SUPPORT_BLTFOURCC = 4;//显卡BLT支持颜色转换，如果不支持，播放器会用软件方法作RGB转换
        public const int NET_DVR_SUPPORT_BLTSHRINKX = 8;//显卡BLT支持X轴缩小；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_BLTSHRINKY = 16;//显卡BLT支持Y轴缩小；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_BLTSTRETCHX = 32;//显卡BLT支持X轴放大；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_BLTSTRETCHY = 64;//显卡BLT支持Y轴放大；如果不支持，系统会用软件方法转换
        public const int NET_DVR_SUPPORT_SSE = 128;//CPU支持SSE指令，Intel Pentium3以上支持SSE指令
        public const int NET_DVR_SUPPORT_MMX = 256;//CPU支持MMX指令集，Intel Pentium3以上支持SSE指令

        /**********************云台控制命令 begin*************************/
        public const int LIGHT_PWRON = 2;// 接通灯光电源
        public const int WIPER_PWRON = 3;// 接通雨刷开关 
        public const int FAN_PWRON = 4;// 接通风扇开关
        public const int HEATER_PWRON = 5;// 接通加热器开关
        public const int AUX_PWRON1 = 6;// 接通辅助设备开关
        public const int AUX_PWRON2 = 7;// 接通辅助设备开关 
        public const int SET_PRESET = 8;// 设置预置点 
        public const int CLE_PRESET = 9;// 清除预置点 

        public const int ZOOM_IN = 11;// 焦距以速度SS变大(倍率变大)
        public const int ZOOM_OUT = 12;// 焦距以速度SS变小(倍率变小)
        public const int FOCUS_NEAR = 13;// 焦点以速度SS前调 
        public const int FOCUS_FAR = 14;// 焦点以速度SS后调
        public const int IRIS_OPEN = 15;// 光圈以速度SS扩大
        public const int IRIS_CLOSE = 16;// 光圈以速度SS缩小 

        public const int TILT_UP = 21;/* 云台以SS的速度上仰 */
        public const int TILT_DOWN = 22;/* 云台以SS的速度下俯 */
        public const int PAN_LEFT = 23;/* 云台以SS的速度左转 */
        public const int PAN_RIGHT = 24;/* 云台以SS的速度右转 */
        public const int UP_LEFT = 25;/* 云台以SS的速度上仰和左转 */
        public const int UP_RIGHT = 26;/* 云台以SS的速度上仰和右转 */
        public const int DOWN_LEFT = 27;/* 云台以SS的速度下俯和左转 */
        public const int DOWN_RIGHT = 28;/* 云台以SS的速度下俯和右转 */
        public const int PAN_AUTO = 29;/* 云台以SS的速度左右自动扫描 */

        public const int FILL_PRE_SEQ = 30;/* 将预置点加入巡航序列 */
        public const int SET_SEQ_DWELL = 31;/* 设置巡航点停顿时间 */
        public const int SET_SEQ_SPEED = 32;/* 设置巡航速度 */
        public const int CLE_PRE_SEQ = 33;/* 将预置点从巡航序列中删除 */
        public const int STA_MEM_CRUISE = 34;/* 开始记录轨迹 */
        public const int STO_MEM_CRUISE = 35;/* 停止记录轨迹 */
        public const int RUN_CRUISE = 36;/* 开始轨迹 */
        public const int RUN_SEQ = 37;/* 开始巡航 */
        public const int STOP_SEQ = 38;/* 停止巡航 */
        public const int GOTO_PRESET = 39;/* 快球转到预置点 */
        /**********************云台控制命令 end*************************/

        /*************************************************
        回放时播放控制命令宏定义 
        NET_DVR_PlayBackControl
        NET_DVR_PlayControlLocDisplay
        NET_DVR_DecPlayBackCtrl的宏定义
        具体支持查看函数说明和代码
        **************************************************/
        public const int NET_DVR_PLAYSTART = 1;//开始播放
        public const int NET_DVR_PLAYSTOP = 2;//停止播放
        public const int NET_DVR_PLAYPAUSE = 3;//暂停播放
        public const int NET_DVR_PLAYRESTART = 4;//恢复播放
        public const int NET_DVR_PLAYFAST = 5;//快放
        public const int NET_DVR_PLAYSLOW = 6;//慢放
        public const int NET_DVR_PLAYNORMAL = 7;//正常速度
        public const int NET_DVR_PLAYFRAME = 8;//单帧放
        public const int NET_DVR_PLAYSTARTAUDIO = 9;//打开声音
        public const int NET_DVR_PLAYSTOPAUDIO = 10;//关闭声音
        public const int NET_DVR_PLAYAUDIOVOLUME = 11;//调节音量
        public const int NET_DVR_PLAYSETPOS = 12;//改变文件回放的进度
        public const int NET_DVR_PLAYGETPOS = 13;//获取文件回放的进度
        public const int NET_DVR_PLAYGETTIME = 14;//获取当前已经播放的时间(按文件回放的时候有效)
        public const int NET_DVR_PLAYGETFRAME = 15;//获取当前已经播放的帧数(按文件回放的时候有效)
        public const int NET_DVR_GETTOTALFRAMES = 16;//获取当前播放文件总的帧数(按文件回放的时候有效)
        public const int NET_DVR_GETTOTALTIME = 17;//获取当前播放文件总的时间(按文件回放的时候有效)
        public const int NET_DVR_THROWBFRAME = 20;//丢B帧
        public const int NET_DVR_SETSPEED = 24;//设置码流速度
        public const int NET_DVR_KEEPALIVE = 25;//保持与设备的心跳(如果回调阻塞，建议2秒发送一次)
        public const int NET_DVR_PLAYSETTIME = 26;//按绝对时间定位
        public const int NET_DVR_PLAYGETTOTALLEN = 27;//获取按时间回放对应时间段内的所有文件的总长度
        public const int NET_DVR_PLAY_FORWARD = 29;//倒放切换为正放
        public const int NET_DVR_PLAY_REVERSE = 30;//正放切换为倒放
        public const int NET_DVR_SET_TRANS_TYPE = 32;//设置转封装类型
        public const int NET_DVR_PLAY_CONVERT = 33;//正放切换为倒放

        //远程按键定义如下：
        /* key value send to CONFIG program */
        public const int KEY_CODE_1 = 1;
        public const int KEY_CODE_2 = 2;
        public const int KEY_CODE_3 = 3;
        public const int KEY_CODE_4 = 4;
        public const int KEY_CODE_5 = 5;
        public const int KEY_CODE_6 = 6;
        public const int KEY_CODE_7 = 7;
        public const int KEY_CODE_8 = 8;
        public const int KEY_CODE_9 = 9;
        public const int KEY_CODE_0 = 10;
        public const int KEY_CODE_POWER = 11;
        public const int KEY_CODE_MENU = 12;
        public const int KEY_CODE_ENTER = 13;
        public const int KEY_CODE_CANCEL = 14;
        public const int KEY_CODE_UP = 15;
        public const int KEY_CODE_DOWN = 16;
        public const int KEY_CODE_LEFT = 17;
        public const int KEY_CODE_RIGHT = 18;
        public const int KEY_CODE_EDIT = 19;
        public const int KEY_CODE_ADD = 20;
        public const int KEY_CODE_MINUS = 21;
        public const int KEY_CODE_PLAY = 22;
        public const int KEY_CODE_REC = 23;
        public const int KEY_CODE_PAN = 24;
        public const int KEY_CODE_M = 25;
        public const int KEY_CODE_A = 26;
        public const int KEY_CODE_F1 = 27;
        public const int KEY_CODE_F2 = 28;

        /* for PTZ control */
        public const int KEY_PTZ_UP_START = KEY_CODE_UP;
        public const int KEY_PTZ_UP_STOP = 32;

        public const int KEY_PTZ_DOWN_START = KEY_CODE_DOWN;
        public const int KEY_PTZ_DOWN_STOP = 33;


        public const int KEY_PTZ_LEFT_START = KEY_CODE_LEFT;
        public const int KEY_PTZ_LEFT_STOP = 34;

        public const int KEY_PTZ_RIGHT_START = KEY_CODE_RIGHT;
        public const int KEY_PTZ_RIGHT_STOP = 35;

        public const int KEY_PTZ_AP1_START = KEY_CODE_EDIT;/* 光圈+ */
        public const int KEY_PTZ_AP1_STOP = 36;

        public const int KEY_PTZ_AP2_START = KEY_CODE_PAN;/* 光圈- */
        public const int KEY_PTZ_AP2_STOP = 37;

        public const int KEY_PTZ_FOCUS1_START = KEY_CODE_A;/* 聚焦+ */
        public const int KEY_PTZ_FOCUS1_STOP = 38;

        public const int KEY_PTZ_FOCUS2_START = KEY_CODE_M;/* 聚焦- */
        public const int KEY_PTZ_FOCUS2_STOP = 39;

        public const int KEY_PTZ_B1_START = 40;/* 变倍+ */
        public const int KEY_PTZ_B1_STOP = 41;

        public const int KEY_PTZ_B2_START = 42;/* 变倍- */
        public const int KEY_PTZ_B2_STOP = 43;

        //9000新增
        public const int KEY_CODE_11 = 44;
        public const int KEY_CODE_12 = 45;
        public const int KEY_CODE_13 = 46;
        public const int KEY_CODE_14 = 47;
        public const int KEY_CODE_15 = 48;
        public const int KEY_CODE_16 = 49;

        /*************************参数配置命令 begin*******************************/
        //用于NET_DVR_SetDVRConfig和NET_DVR_GetDVRConfig,注意其对应的配置结构
        public const int NET_DVR_GET_DEVICECFG = 100;//获取设备参数
        public const int NET_DVR_SET_DEVICECFG = 101;//设置设备参数
        public const int NET_DVR_GET_NETCFG = 102;//获取网络参数
        public const int NET_DVR_SET_NETCFG = 103;//设置网络参数
        public const int NET_DVR_GET_PICCFG = 104;//获取图象参数
        public const int NET_DVR_SET_PICCFG = 105;//设置图象参数
        public const int NET_DVR_GET_COMPRESSCFG = 106;//获取压缩参数
        public const int NET_DVR_SET_COMPRESSCFG = 107;//设置压缩参数
        public const int NET_DVR_GET_RECORDCFG = 108;//获取录像时间参数
        public const int NET_DVR_SET_RECORDCFG = 109;//设置录像时间参数
        public const int NET_DVR_GET_DECODERCFG = 110;//获取解码器参数
        public const int NET_DVR_SET_DECODERCFG = 111;//设置解码器参数
        public const int NET_DVR_GET_RS232CFG = 112;//获取232串口参数
        public const int NET_DVR_SET_RS232CFG = 113;//设置232串口参数
        public const int NET_DVR_GET_ALARMINCFG = 114;//获取报警输入参数
        public const int NET_DVR_SET_ALARMINCFG = 115;//设置报警输入参数
        public const int NET_DVR_GET_ALARMOUTCFG = 116;//获取报警输出参数
        public const int NET_DVR_SET_ALARMOUTCFG = 117;//设置报警输出参数
        public const int NET_DVR_GET_TIMECFG = 118;//获取DVR时间
        public const int NET_DVR_SET_TIMECFG = 119;//设置DVR时间
        public const int NET_DVR_GET_PREVIEWCFG = 120;//获取预览参数
        public const int NET_DVR_SET_PREVIEWCFG = 121;//设置预览参数
        public const int NET_DVR_GET_VIDEOOUTCFG = 122;//获取视频输出参数
        public const int NET_DVR_SET_VIDEOOUTCFG = 123;//设置视频输出参数
        public const int NET_DVR_GET_USERCFG = 124;//获取用户参数
        public const int NET_DVR_SET_USERCFG = 125;//设置用户参数
        public const int NET_DVR_GET_EXCEPTIONCFG = 126;//获取异常参数
        public const int NET_DVR_SET_EXCEPTIONCFG = 127;//设置异常参数
        public const int NET_DVR_GET_ZONEANDDST = 128;//获取时区和夏时制参数
        public const int NET_DVR_SET_ZONEANDDST = 129;//设置时区和夏时制参数
        public const int NET_DVR_GET_SHOWSTRING = 130;//获取叠加字符参数
        public const int NET_DVR_SET_SHOWSTRING = 131;//设置叠加字符参数
        public const int NET_DVR_GET_EVENTCOMPCFG = 132;//获取事件触发录像参数
        public const int NET_DVR_SET_EVENTCOMPCFG = 133;//设置事件触发录像参数

        public const int NET_DVR_GET_AUXOUTCFG = 140;//获取报警触发辅助输出设置(HS设备辅助输出2006-02-28)
        public const int NET_DVR_SET_AUXOUTCFG = 141;//设置报警触发辅助输出设置(HS设备辅助输出2006-02-28)
        public const int NET_DVR_GET_PREVIEWCFG_AUX = 142;//获取-s系列双输出预览参数(-s系列双输出2006-04-13)
        public const int NET_DVR_SET_PREVIEWCFG_AUX = 143;//设置-s系列双输出预览参数(-s系列双输出2006-04-13)

        public const int NET_DVR_GET_PICCFG_EX = 200;//获取图象参数(SDK_V14扩展命令)
        public const int NET_DVR_SET_PICCFG_EX = 201;//设置图象参数(SDK_V14扩展命令)
        public const int NET_DVR_GET_USERCFG_EX = 202;//获取用户参数(SDK_V15扩展命令)
        public const int NET_DVR_SET_USERCFG_EX = 203;//设置用户参数(SDK_V15扩展命令)
        public const int NET_DVR_GET_COMPRESSCFG_EX = 204;//获取压缩参数(SDK_V15扩展命令2006-05-15)
        public const int NET_DVR_SET_COMPRESSCFG_EX = 205;//设置压缩参数(SDK_V15扩展命令2006-05-15)

        public const int NET_DVR_GET_NETAPPCFG = 222;//获取网络应用参数 NTP/DDNS/EMAIL
        public const int NET_DVR_SET_NETAPPCFG = 223;//设置网络应用参数 NTP/DDNS/EMAIL
        public const int NET_DVR_GET_NTPCFG = 224;//获取网络应用参数 NTP
        public const int NET_DVR_SET_NTPCFG = 225;//设置网络应用参数 NTP
        public const int NET_DVR_GET_DDNSCFG = 226;//获取网络应用参数 DDNS
        public const int NET_DVR_SET_DDNSCFG = 227;//设置网络应用参数 DDNS
        //对应NET_DVR_EMAILPARA
        public const int NET_DVR_GET_EMAILCFG = 228;//获取网络应用参数 EMAIL
        public const int NET_DVR_SET_EMAILCFG = 229;//设置网络应用参数 EMAIL

        public const int NET_DVR_GET_NFSCFG = 230;/* NFS disk config */
        public const int NET_DVR_SET_NFSCFG = 231;/* NFS disk config */

        public const int NET_DVR_GET_SHOWSTRING_EX = 238;//获取叠加字符参数扩展(支持8条字符)
        public const int NET_DVR_SET_SHOWSTRING_EX = 239;//设置叠加字符参数扩展(支持8条字符)
        public const int NET_DVR_GET_NETCFG_OTHER = 244;//获取网络参数
        public const int NET_DVR_SET_NETCFG_OTHER = 245;//设置网络参数

        //对应NET_DVR_EMAILCFG结构
        public const int NET_DVR_GET_EMAILPARACFG = 250;//Get EMAIL parameters
        public const int NET_DVR_SET_EMAILPARACFG = 251;//Setup EMAIL parameters

        public const int NET_DVR_GET_DDNSCFG_EX = 274;//获取扩展DDNS参数
        public const int NET_DVR_SET_DDNSCFG_EX = 275;//设置扩展DDNS参数

        public const int NET_DVR_SET_PTZPOS = 292;//云台设置PTZ位置
        public const int NET_DVR_GET_PTZPOS = 293;//云台获取PTZ位置
        public const int NET_DVR_GET_PTZSCOPE = 294;//云台获取PTZ范围

        public const int NET_DVR_GET_AP_INFO_LIST = 305;//获取无线网络资源参数
        public const int NET_DVR_SET_WIFI_CFG = 306;//设置IP监控设备无线参数
        public const int NET_DVR_GET_WIFI_CFG = 307;//获取IP监控设备无线参数
        public const int NET_DVR_SET_WIFI_WORKMODE = 308;//设置IP监控设备网口工作模式参数
        public const int NET_DVR_GET_WIFI_WORKMODE = 309;//获取IP监控设备网口工作模式参数 
        public const int NET_DVR_GET_WIFI_STATUS = 310;	//获取设备当前wifi连接状态

        /***************************智能服务器 begin *****************************/
        //智能设备类型
        public const int DS6001_HF_B = 60;//行为分析：DS6001-HF/B
        public const int DS6001_HF_P = 61;//车牌识别：DS6001-HF/P
        public const int DS6002_HF_B = 62;//双机跟踪：DS6002-HF/B
        public const int DS6101_HF_B = 63;//行为分析：DS6101-HF/B
        public const int IDS52XX = 64;//智能分析仪IVMS
        public const int DS9000_IVS = 65;//9000系列智能DVR
        public const int DS8004_AHL_A = 66;//智能ATM, DS8004AHL-S/A
        public const int DS6101_HF_P = 67;//车牌识别：DS6101-HF/P

        //能力获取命令
        public const int VCA_DEV_ABILITY = 256;//设备智能分析的总能力
        public const int VCA_CHAN_ABILITY = 272;//行为分析能力
        public const int MATRIXDECODER_ABILITY = 512;//多路解码器显示、解码能力
        //获取/设置大接口参数配置命令
        //车牌识别（NET_VCA_PLATE_CFG）
        public const int NET_DVR_SET_PLATECFG = 150;//设置车牌识别参数
        public const int NET_DVR_GET_PLATECFG = 151;//获取车牌识别参数
        //行为对应（NET_VCA_RULECFG）
        public const int NET_DVR_SET_RULECFG = 152;//设置行为分析规则
        public const int NET_DVR_GET_RULECFG = 153;//获取行为分析规则

        //双摄像机标定参数（NET_DVR_LF_CFG）
        public const int NET_DVR_SET_LF_CFG = 160;//设置双摄像机的配置参数
        public const int NET_DVR_GET_LF_CFG = 161;//获取双摄像机的配置参数

        //智能分析仪取流配置结构
        public const int NET_DVR_SET_IVMS_STREAMCFG = 162;//设置智能分析仪取流参数
        public const int NET_DVR_GET_IVMS_STREAMCFG = 163;//获取智能分析仪取流参数

        //智能控制参数结构
        public const int NET_DVR_SET_VCA_CTRLCFG = 164;//设置智能控制参数
        public const int NET_DVR_GET_VCA_CTRLCFG = 165;//获取智能控制参数

        //屏蔽区域NET_VCA_MASK_REGION_LIST
        public const int NET_DVR_SET_VCA_MASK_REGION = 166;//设置屏蔽区域参数
        public const int NET_DVR_GET_VCA_MASK_REGION = 167;//获取屏蔽区域参数

        //ATM进入区域 NET_VCA_ENTER_REGION
        public const int NET_DVR_SET_VCA_ENTER_REGION = 168;//设置进入区域参数
        public const int NET_DVR_GET_VCA_ENTER_REGION = 169;//获取进入区域参数

        //标定线配置NET_VCA_LINE_SEGMENT_LIST
        public const int NET_DVR_SET_VCA_LINE_SEGMENT = 170;//设置标定线
        public const int NET_DVR_GET_VCA_LINE_SEGMENT = 171;//获取标定线

        // ivms屏蔽区域NET_IVMS_MASK_REGION_LIST
        public const int NET_DVR_SET_IVMS_MASK_REGION = 172;//设置IVMS屏蔽区域参数
        public const int NET_DVR_GET_IVMS_MASK_REGION = 173;//获取IVMS屏蔽区域参数
        // ivms进入检测区域NET_IVMS_ENTER_REGION
        public const int NET_DVR_SET_IVMS_ENTER_REGION = 174;//设置IVMS进入区域参数
        public const int NET_DVR_GET_IVMS_ENTER_REGION = 175;//获取IVMS进入区域参数

        public const int NET_DVR_SET_IVMS_BEHAVIORCFG = 176;//设置智能分析仪行为规则参数
        public const int NET_DVR_GET_IVMS_BEHAVIORCFG = 177;//获取智能分析仪行为规则参数

        // IVMS 回放检索
        public const int NET_DVR_IVMS_SET_SEARCHCFG = 178;//设置IVMS回放检索参数
        public const int NET_DVR_IVMS_GET_SEARCHCFG = 179;//获取IVMS回放检索参数     

        /***************************DS9000新增命令(_V30) begin *****************************/
        //网络(NET_DVR_NETCFG_V30结构)
        public const int NET_DVR_GET_NETCFG_V30 = 1000;//获取网络参数
        public const int NET_DVR_SET_NETCFG_V30 = 1001;//设置网络参数

        //图象(NET_DVR_PICCFG_V30结构)
        public const int NET_DVR_GET_PICCFG_V30 = 1002;//获取图象参数
        public const int NET_DVR_SET_PICCFG_V30 = 1003;//设置图象参数

        //图象(NET_DVR_PICCFG_V40结构)
        public const int NET_DVR_GET_PICCFG_V40 = 6179;//获取图象参数V40扩展
        public const int NET_DVR_SET_PICCFG_V40 = 6180;//设置图象参数V40扩展

        //录像时间(NET_DVR_RECORD_V30结构)
        public const int NET_DVR_GET_RECORDCFG_V30 = 1004;//获取录像参数
        public const int NET_DVR_SET_RECORDCFG_V30 = 1005;//设置录像参数

        public const int NET_DVR_GET_RECORDCFG_V40 = 1008; //获取录像参数(扩展)
        public const int NET_DVR_SET_RECORDCFG_V40 = 1009; //设置录像参数(扩展)

        //用户(NET_DVR_USER_V30结构)
        public const int NET_DVR_GET_USERCFG_V30 = 1006;//获取用户参数
        public const int NET_DVR_SET_USERCFG_V30 = 1007;//设置用户参数

        //9000DDNS参数配置(NET_DVR_DDNSPARA_V30结构)
        public const int NET_DVR_GET_DDNSCFG_V30 = 1010;//获取DDNS(9000扩展)
        public const int NET_DVR_SET_DDNSCFG_V30 = 1011;//设置DDNS(9000扩展)

        //EMAIL功能(NET_DVR_EMAILCFG_V30结构)
        public const int NET_DVR_GET_EMAILCFG_V30 = 1012;//获取EMAIL参数 
        public const int NET_DVR_SET_EMAILCFG_V30 = 1013;//设置EMAIL参数 

        //巡航参数 (NET_DVR_CRUISE_PARA结构)
        public const int NET_DVR_GET_CRUISE = 1020;
        public const int NET_DVR_SET_CRUISE = 1021;

        //报警输入结构参数 (NET_DVR_ALARMINCFG_V30结构)
        public const int NET_DVR_GET_ALARMINCFG_V30 = 1024;
        public const int NET_DVR_SET_ALARMINCFG_V30 = 1025;

        //报警输出结构参数 (NET_DVR_ALARMOUTCFG_V30结构)
        public const int NET_DVR_GET_ALARMOUTCFG_V30 = 1026;
        public const int NET_DVR_SET_ALARMOUTCFG_V30 = 1027;

        //视频输出结构参数 (NET_DVR_VIDEOOUT_V30结构)
        public const int NET_DVR_GET_VIDEOOUTCFG_V30 = 1028;
        public const int NET_DVR_SET_VIDEOOUTCFG_V30 = 1029;

        //叠加字符结构参数 (NET_DVR_SHOWSTRING_V30结构)
        public const int NET_DVR_GET_SHOWSTRING_V30 = 1030;
        public const int NET_DVR_SET_SHOWSTRING_V30 = 1031;

        //异常结构参数 (NET_DVR_EXCEPTION_V30结构)
        public const int NET_DVR_GET_EXCEPTIONCFG_V30 = 1034;
        public const int NET_DVR_SET_EXCEPTIONCFG_V30 = 1035;

        //串口232结构参数 (NET_DVR_RS232CFG_V30结构)
        public const int NET_DVR_GET_RS232CFG_V30 = 1036;
        public const int NET_DVR_SET_RS232CFG_V30 = 1037;

        //网络硬盘接入结构参数 (NET_DVR_NET_DISKCFG结构)
        public const int NET_DVR_GET_NET_DISKCFG = 1038;//网络硬盘接入获取
        public const int NET_DVR_SET_NET_DISKCFG = 1039;//网络硬盘接入设置

        //压缩参数 (NET_DVR_COMPRESSIONCFG_V30结构)
        public const int NET_DVR_GET_COMPRESSCFG_V30 = 1040;
        public const int NET_DVR_SET_COMPRESSCFG_V30 = 1041;

        //获取485解码器参数 (NET_DVR_DECODERCFG_V30结构)
        public const int NET_DVR_GET_DECODERCFG_V30 = 1042;//获取解码器参数
        public const int NET_DVR_SET_DECODERCFG_V30 = 1043;//设置解码器参数

        //获取预览参数 (NET_DVR_PREVIEWCFG_V30结构)
        public const int NET_DVR_GET_PREVIEWCFG_V30 = 1044;//获取预览参数
        public const int NET_DVR_SET_PREVIEWCFG_V30 = 1045;//设置预览参数

        //辅助预览参数 (NET_DVR_PREVIEWCFG_AUX_V30结构)
        public const int NET_DVR_GET_PREVIEWCFG_AUX_V30 = 1046;//获取辅助预览参数
        public const int NET_DVR_SET_PREVIEWCFG_AUX_V30 = 1047;//设置辅助预览参数

        //IP接入配置参数 （NET_DVR_IPPARACFG结构）
        public const int NET_DVR_GET_IPPARACFG = 1048; //获取IP接入配置信息 
        public const int NET_DVR_SET_IPPARACFG = 1049;//设置IP接入配置信息

        //IP接入配置参数 （NET_DVR_IPPARACFG_V40结构）
        public const int NET_DVR_GET_IPPARACFG_V40 = 1062; //获取IP接入配置信息 
        public const int NET_DVR_SET_IPPARACFG_V40 = 1063;//设置IP接入配置信息

        //IP报警输入接入配置参数 （NET_DVR_IPALARMINCFG结构）
        public const int NET_DVR_GET_IPALARMINCFG = 1050; //获取IP报警输入接入配置信息 
        public const int NET_DVR_SET_IPALARMINCFG = 1051; //设置IP报警输入接入配置信息

        //IP报警输出接入配置参数 （NET_DVR_IPALARMOUTCFG结构）
        public const int NET_DVR_GET_IPALARMOUTCFG = 1052;//获取IP报警输出接入配置信息 
        public const int NET_DVR_SET_IPALARMOUTCFG = 1053;//设置IP报警输出接入配置信息

        //硬盘管理的参数获取 (NET_DVR_HDCFG结构)
        public const int NET_DVR_GET_HDCFG = 1054;//获取硬盘管理配置参数
        public const int NET_DVR_SET_HDCFG = 1055;//设置硬盘管理配置参数

        //盘组管理的参数获取 (NET_DVR_HDGROUP_CFG结构)
        public const int NET_DVR_GET_HDGROUP_CFG = 1056;//获取盘组管理配置参数
        public const int NET_DVR_SET_HDGROUP_CFG = 1057;//设置盘组管理配置参数

        //设备编码类型配置(NET_DVR_COMPRESSION_AUDIO结构)
        public const int NET_DVR_GET_COMPRESSCFG_AUD = 1058;//获取设备语音对讲编码参数
        public const int NET_DVR_SET_COMPRESSCFG_AUD = 1059;//设置设备语音对讲编码参数

        //IP接入配置参数 （NET_DVR_IPPARACFG_V31结构）
        public const int NET_DVR_GET_IPPARACFG_V31 = 1060;//获取IP接入配置信息 
        public const int NET_DVR_SET_IPPARACFG_V31 = 1061; //设置IP接入配置信息

        //设备参数配置 （NET_DVR_DEVICECFG_V40结构）
        public const int NET_DVR_GET_DEVICECFG_V40 = 1100;//获取设备参数
        public const int NET_DVR_SET_DEVICECFG_V40 = 1101;//设置设备参数

        //多网卡配置(NET_DVR_NETCFG_MULTI结构)
        public const int NET_DVR_GET_NETCFG_MULTI = 1161;
        public const int NET_DVR_SET_NETCFG_MULTI = 1162;

        //BONDING网卡(NET_DVR_NETWORK_BONDING结构)
        public const int NET_DVR_GET_NETWORK_BONDING = 1254;
        public const int NET_DVR_SET_NETWORK_BONDING = 1255;


        //人脸比对库配置
        public const int NET_DVR_GET_FACELIB_TRIGGER = 3962;   //获取人脸比对库的联动配置
        public const int NET_DVR_SET_FACELIB_TRIGGER = 3963;   //设置人脸比对库的联动配置
        public const int NET_DVR_GET_FACELIB_SCHEDULE = 3977; //获取人脸比对库的布防时间配置
        public const int NET_DVR_SET_FACELIB_SCHEDULE = 3978; //设置人脸比对库的布防时间配置

        //NAT映射配置参数 （NET_DVR_NAT_CFG结构）
        public const int NET_DVR_GET_NAT_CFG = 6111;    //获取NAT映射参数
        public const int NET_DVR_SET_NAT_CFG = 6112;    //设置NAT映射参数  

        //电视墙
        public const int NET_DVR_SET_WINCFG = 1202;//窗口参数设置
        public const int NET_DVR_MATRIX_BIGSCREENCFG_GET = 1140; //获取大屏拼接参数
        public const int NET_DVR_MATRIX_BIGSCREENCFG_SET = 1141; //设置大屏拼接参数

        public const int NET_DVR_MATRIX_WALL_GET = 9002;  //获取电视墙中屏幕参数
        public const int NET_DVR_MATRIX_WALL_SET = 9001;  //设置电视墙中屏幕参数

        public const int NET_DVR_WALLWIN_GET = 9003;  //获取电视墙窗口参数
        public const int NET_DVR_WALLWIN_SET = 9004;  //设置电视墙窗口参数

        public const int NET_DVR_WALLWINPARAM_SET = 9005;  //获取电视墙窗口相关参数
        public const int NET_DVR_WALLWINPARAM_GET = 9006;  //设置电视墙窗口相关参数

        public const int NET_DVR_SWITCH_WIN_TOP = 9017;  //窗口置顶
        public const int NET_DVR_SWITCH_WIN_BOTTOM = 9018;  //窗口置底

        public const int NET_DVR_GET_VIDEOWALLDISPLAYPOSITION = 1734;//获取显示输出位置参数
        public const int NET_DVR_SET_VIDEOWALLDISPLAYPOSITION = 1733;//设置显示输出位置参数

        public const int NET_DVR_GET_VIDEOWALLDISPLAYNO = 1732;  //获取设备显示输出号

        public const int NET_DVR_GET_VIDEOWALLWINDOWPOSITION = 1735; //获取电视墙窗口参数
        public const int NET_DVR_SET_VIDEOWALLWINDOWPOSITION = 1736; //设置电视墙窗口参数

        public const int NET_DVR_GET_CHAN_RELATION = 9209;     //获取编码通道关联资源参数
        public const int NET_DVR_SET_CHAN_RELATION = 9210;     //设置编码通道关联资源参数
        public const int NET_DVR_GET_ALL_CHAN_RELATION = 9211; //获取所有编码通道关联资源参数

        public const int NET_DVR_GET_VW_SCENE_PARAM = 1746; //获取电视墙场景模式参数
        public const int NET_DVR_SET_VW_SCENE_PARAM = 1747; //设置电视墙场景模式参数

        public const int NET_DVR_GET_OUTPUT_PIC_WIN_CFG = 9202;    //获取输出口图片窗口参数
        public const int NET_DVR_SET_OUTPUT_PIC_WIN_CFG = 9203;    //设置输出口图片窗口参数

        public const int NET_DVR_GET_OUTPUT_OSD_CFG = 9206;    //获取输出口OSD参数
        public const int NET_DVR_SET_OUTPUT_OSD_CFG = 9207;    //设置输出口OSD参数

        public const int NET_DVR_SCENE_CONTROL = 1744; //场景控制


        public const int NET_DVR_GET_CARD = 2560;
        public const int NET_DVR_SET_CARD = 2561;
        public const int NET_DVR_DEL_CARD = 2562;
        public const int NET_DVR_GET_FINGERPRINT = 2563;
        public const int NET_DVR_SET_FINGERPRINT = 2564;
        public const int NET_DVR_DEL_FINGERPRINT = 2565;
        public const int NET_DVR_GET_FACE = 2566;
        public const int NET_DVR_SET_FACE = 2567;

        public const int NET_DVR_DEL_FACE_PARAM_CFG = 2509;      //delete face param configure
        public const int NET_DVR_CAPTURE_FACE_INFO = 2510;       //capture face information

        //预置点名称获取与设置
        public const int NET_DVR_GET_PRESET_NAME = 3383;
        public const int NET_DVR_SET_PRESET_NAME = 3382;

        public const int NET_VCA_GET_RULECFG_V41 = 5011; //获取行为分析参数
        public const int NET_VCA_SET_RULECFG_V41 = 5012; //设置行为分析参数

        public const int NET_DVR_GET_TRAVERSE_PLANE_DETECTION = 3360; //获取越界侦测配置
        public const int NET_DVR_SET_TRAVERSE_PLANE_DETECTION = 3361; //设置越界侦测配置

        public const int NET_DVR_GET_THERMOMETRY_ALARMRULE = 3627; //获取预置点测温报警规则配置
        public const int NET_DVR_SET_THERMOMETRY_ALARMRULE = 3628; //设置预置点测温报警规则配置     
        public const int NET_DVR_GET_THERMOMETRY_TRIGGER = 3632; //获取测温联动配置
        public const int NET_DVR_SET_THERMOMETRY_TRIGGER = 3633; //设置测温联动配置

        public const int NET_DVR_SET_MANUALTHERM_BASICPARAM = 6716;  //设置手动测温基本参数
        public const int NET_DVR_GET_MANUALTHERM_BASICPARAM = 6717;  //获取手动测温基本参数

        public const int NET_DVR_SET_MANUALTHERM = 6708; //设置手动测温数据设置

        public const int NET_DVR_GET_MULTI_STREAM_COMPRESSIONCFG = 3216; //远程获取多码流压缩参数
        public const int NET_DVR_SET_MULTI_STREAM_COMPRESSIONCFG = 3217; //远程设置多码流压缩参数 

        public const int NET_DVR_VIDEO_CALL_SIGNAL_PROCESS = 16032;  //可视话对讲信令处理

        public const int NET_DVR_ARM_ALARMHOST_SUBSYSTEM = 2036;//按布防类型对子系统布防

        public const int NET_DVR_GET_MULTI_CARD_CFG_V50 = 2515;    //获取多重卡参数V50
        public const int NET_DVR_SET_MULTI_CARD_CFG_V50 = 2516;    //设置多重卡参数V50

        public const int NET_DVR_BARRIERGATE_CTRL = 3128; //道闸控制

        public const int NET_DVR_INQUEST_GET_CDW_STATUS = 6350;  //获取审讯机刻录状态-长连接

        public const int NET_DVR_GET_REALTIME_THERMOMETRY = 3629;    //实时温度检测

        public const int NET_DVR_GET_ACS_EVENT = 2514;//设备事件获取

        public const int NET_SDK_GET_NEXT_STATUS_SUCCESS = 1000;
        public const int NET_SDK_GET_NEXT_STATUS_NEED_WAIT = 1001;
        public const int NET_SDK_GET_NEXT_STATUS_FINISH = 1002;
        public const int NET_SDK_GET_NEXT_STATUS_FAILED = 1003;
        /*************************参数配置命令 end*******************************/


        /************************DVR日志 begin***************************/
        /* 报警 */
        //主类型
        public const int MAJOR_ALARM = 1;
        //次类型
        public const int MINOR_ALARM_IN = 1;/* 报警输入 */
        public const int MINOR_ALARM_OUT = 2;/* 报警输出 */
        public const int MINOR_MOTDET_START = 3; /* 移动侦测报警开始 */
        public const int MINOR_MOTDET_STOP = 4; /* 移动侦测报警结束 */
        public const int MINOR_HIDE_ALARM_START = 5;/* 遮挡报警开始 */
        public const int MINOR_HIDE_ALARM_STOP = 6;/* 遮挡报警结束 */
        public const int MINOR_VCA_ALARM_START = 7;/*智能报警开始*/
        public const int MINOR_VCA_ALARM_STOP = 8;/*智能报警停止*/

        /* 异常 */
        //主类型
        public const int MAJOR_EXCEPTION = 2;
        //次类型
        public const int MINOR_VI_LOST = 33;/* 视频信号丢失 */
        public const int MINOR_ILLEGAL_ACCESS = 34;/* 非法访问 */
        public const int MINOR_HD_FULL = 35;/* 硬盘满 */
        public const int MINOR_HD_ERROR = 36;/* 硬盘错误 */
        public const int MINOR_DCD_LOST = 37;/* MODEM 掉线(保留不使用) */
        public const int MINOR_IP_CONFLICT = 38;/* IP地址冲突 */
        public const int MINOR_NET_BROKEN = 39;/* 网络断开*/
        public const int MINOR_REC_ERROR = 40;/* 录像出错 */
        public const int MINOR_IPC_NO_LINK = 41;/* IPC连接异常 */
        public const int MINOR_VI_EXCEPTION = 42;/* 视频输入异常(只针对模拟通道) */
        public const int MINOR_IPC_IP_CONFLICT = 43;/*ipc ip 地址 冲突*/

        //视频综合平台
        public const int MINOR_FANABNORMAL = 49;/* 视频综合平台：风扇状态异常 */
        public const int MINOR_FANRESUME = 50;/* 视频综合平台：风扇状态恢复正常 */
        public const int MINOR_SUBSYSTEM_ABNORMALREBOOT = 51;/* 视频综合平台：6467异常重启 */
        public const int MINOR_MATRIX_STARTBUZZER = 52;/* 视频综合平台：dm6467异常，启动蜂鸣器 */

        /* 操作 */
        //主类型
        public const int MAJOR_OPERATION = 3;
        //次类型
        public const int MINOR_START_DVR = 65;/* 开机 */
        public const int MINOR_STOP_DVR = 66;/* 关机 */
        public const int MINOR_STOP_ABNORMAL = 67;/* 异常关机 */
        public const int MINOR_REBOOT_DVR = 68;/*本地重启设备*/

        public const int MINOR_LOCAL_LOGIN = 80;/* 本地登陆 */
        public const int MINOR_LOCAL_LOGOUT = 81;/* 本地注销登陆 */
        public const int MINOR_LOCAL_CFG_PARM = 82;/* 本地配置参数 */
        public const int MINOR_LOCAL_PLAYBYFILE = 83;/* 本地按文件回放或下载 */
        public const int MINOR_LOCAL_PLAYBYTIME = 84;/* 本地按时间回放或下载*/
        public const int MINOR_LOCAL_START_REC = 85;/* 本地开始录像 */
        public const int MINOR_LOCAL_STOP_REC = 86;/* 本地停止录像 */
        public const int MINOR_LOCAL_PTZCTRL = 87;/* 本地云台控制 */
        public const int MINOR_LOCAL_PREVIEW = 88;/* 本地预览 (保留不使用)*/
        public const int MINOR_LOCAL_MODIFY_TIME = 89;/* 本地修改时间(保留不使用) */
        public const int MINOR_LOCAL_UPGRADE = 90;/* 本地升级 */
        public const int MINOR_LOCAL_RECFILE_OUTPUT = 91;/* 本地备份录象文件 */
        public const int MINOR_LOCAL_FORMAT_HDD = 92;/* 本地初始化硬盘 */
        public const int MINOR_LOCAL_CFGFILE_OUTPUT = 93;/* 导出本地配置文件 */
        public const int MINOR_LOCAL_CFGFILE_INPUT = 94;/* 导入本地配置文件 */
        public const int MINOR_LOCAL_COPYFILE = 95;/* 本地备份文件 */
        public const int MINOR_LOCAL_LOCKFILE = 96;/* 本地锁定录像文件 */
        public const int MINOR_LOCAL_UNLOCKFILE = 97;/* 本地解锁录像文件 */
        public const int MINOR_LOCAL_DVR_ALARM = 98;/* 本地手动清除和触发报警*/
        public const int MINOR_IPC_ADD = 99;/* 本地添加IPC */
        public const int MINOR_IPC_DEL = 100;/* 本地删除IPC */
        public const int MINOR_IPC_SET = 101;/* 本地设置IPC */
        public const int MINOR_LOCAL_START_BACKUP = 102;/* 本地开始备份 */
        public const int MINOR_LOCAL_STOP_BACKUP = 103;/* 本地停止备份*/
        public const int MINOR_LOCAL_COPYFILE_START_TIME = 104;/* 本地备份开始时间*/
        public const int MINOR_LOCAL_COPYFILE_END_TIME = 105;/* 本地备份结束时间*/
        public const int MINOR_LOCAL_ADD_NAS = 106;/*本地添加网络硬盘*/
        public const int MINOR_LOCAL_DEL_NAS = 107;/* 本地删除nas盘*/
        public const int MINOR_LOCAL_SET_NAS = 108;/* 本地设置nas盘*/

        public const int MINOR_REMOTE_LOGIN = 112;/* 远程登录 */
        public const int MINOR_REMOTE_LOGOUT = 113;/* 远程注销登陆 */
        public const int MINOR_REMOTE_START_REC = 114;/* 远程开始录像 */
        public const int MINOR_REMOTE_STOP_REC = 115;/* 远程停止录像 */
        public const int MINOR_START_TRANS_CHAN = 116;/* 开始透明传输 */
        public const int MINOR_STOP_TRANS_CHAN = 117;/* 停止透明传输 */
        public const int MINOR_REMOTE_GET_PARM = 118;/* 远程获取参数 */
        public const int MINOR_REMOTE_CFG_PARM = 119;/* 远程配置参数 */
        public const int MINOR_REMOTE_GET_STATUS = 120;/* 远程获取状态 */
        public const int MINOR_REMOTE_ARM = 121;/* 远程布防 */
        public const int MINOR_REMOTE_DISARM = 122;/* 远程撤防 */
        public const int MINOR_REMOTE_REBOOT = 123;/* 远程重启 */
        public const int MINOR_START_VT = 124;/* 开始语音对讲 */
        public const int MINOR_STOP_VT = 125;/* 停止语音对讲 */
        public const int MINOR_REMOTE_UPGRADE = 126;/* 远程升级 */
        public const int MINOR_REMOTE_PLAYBYFILE = 127;/* 远程按文件回放 */
        public const int MINOR_REMOTE_PLAYBYTIME = 128;/* 远程按时间回放 */
        public const int MINOR_REMOTE_PTZCTRL = 129;/* 远程云台控制 */
        public const int MINOR_REMOTE_FORMAT_HDD = 130;/* 远程格式化硬盘 */
        public const int MINOR_REMOTE_STOP = 131;/* 远程关机 */
        public const int MINOR_REMOTE_LOCKFILE = 132;/* 远程锁定文件 */
        public const int MINOR_REMOTE_UNLOCKFILE = 133;/* 远程解锁文件 */
        public const int MINOR_REMOTE_CFGFILE_OUTPUT = 134;/* 远程导出配置文件 */
        public const int MINOR_REMOTE_CFGFILE_INTPUT = 135;/* 远程导入配置文件 */
        public const int MINOR_REMOTE_RECFILE_OUTPUT = 136;/* 远程导出录象文件 */
        public const int MINOR_REMOTE_DVR_ALARM = 137;/* 远程手动清除和触发报警*/
        public const int MINOR_REMOTE_IPC_ADD = 138;/* 远程添加IPC */
        public const int MINOR_REMOTE_IPC_DEL = 139;/* 远程删除IPC */
        public const int MINOR_REMOTE_IPC_SET = 140;/* 远程设置IPC */
        public const int MINOR_REBOOT_VCA_LIB = 141;/*重启智能库*/
        public const int MINOR_REMOTE_ADD_NAS = 142;/* 远程添加nas盘*/
        public const int MINOR_REMOTE_DEL_NAS = 143;/* 远程删除nas盘*/
        public const int MINOR_REMOTE_SET_NAS = 144;/* 远程设置nas盘*/

        //2009-12-16 增加视频综合平台日志类型
        public const int MINOR_SUBSYSTEMREBOOT = 160;/*视频综合平台：dm6467 正常重启*/
        public const int MINOR_MATRIX_STARTTRANSFERVIDEO = 161;	/*视频综合平台：矩阵切换开始传输图像*/
        public const int MINOR_MATRIX_STOPTRANSFERVIDEO = 162;	/*视频综合平台：矩阵切换停止传输图像*/
        public const int MINOR_REMOTE_SET_ALLSUBSYSTEM = 163;	/*视频综合平台：设置所有6467子系统信息*/
        public const int MINOR_REMOTE_GET_ALLSUBSYSTEM = 164;	/*视频综合平台：获取所有6467子系统信息*/
        public const int MINOR_REMOTE_SET_PLANARRAY = 165;	/*视频综合平台：设置计划轮询组*/
        public const int MINOR_REMOTE_GET_PLANARRAY = 166;	/*视频综合平台：获取计划轮询组*/
        public const int MINOR_MATRIX_STARTTRANSFERAUDIO = 167;	/*视频综合平台：矩阵切换开始传输音频*/
        public const int MINOR_MATRIX_STOPRANSFERAUDIO = 168;	/*视频综合平台：矩阵切换停止传输音频*/
        public const int MINOR_LOGON_CODESPITTER = 169;	/*视频综合平台：登陆码分器*/
        public const int MINOR_LOGOFF_CODESPITTER = 170;	/*视频综合平台：退出码分器*/

        //2010-12-16 报警板日志
        public const int MINOR_REMOTE_BYPASS = 0xd0;    /* 远程旁路*/
        public const int MINOR_REMOTE_UNBYPASS = 0xd1;    /* 远程旁路恢复*/
        public const int MINOR_REMOTE_SET_ALARMIN_CFG = 0xd2;    /* 远程设置报警输入参数*/
        public const int MINOR_REMOTE_GET_ALARMIN_CFG = 0xd3;    /* 远程获取报警输入参数*/
        public const int MINOR_REMOTE_SET_ALARMOUT_CFG = 0xd4;    /* 远程设置报警输出参数*/
        public const int MINOR_REMOTE_GET_ALARMOUT_CFG = 0xd5;    /* 远程获取报警输出参数*/
        public const int MINOR_REMOTE_ALARMOUT_OPEN_MAN = 0xd6;    /* 远程手动开启报警输出*/
        public const int MINOR_REMOTE_ALARMOUT_CLOSE_MAN = 0xd7;    /* 远程手动关闭报警输出*/
        public const int MINOR_REMOTE_ALARM_ENABLE_CFG = 0xd8;    /* 远程设置报警主机的RS485串口使能状态*/
        public const int MINOR_DBDATA_OUTPUT = 0xd9;    /* 导出数据库记录 */
        public const int MINOR_DBDATA_INPUT = 0xda;    /* 导入数据库记录 */
        public const int MINOR_MU_SWITCH = 0xdb;    /* 级联切换 */
        public const int MINOR_MU_PTZ = 0xdc;    /* 级联PTZ控制 */
        public const int MINOR_DELETE_LOGO = 0xdd;    /* 删除logo */
        public const int MINOR_REMOTE_INQUEST_DEL_FILE = 0xde;       /*远程删除文件*/

        /*日志附加信息*/
        //主类型
        public const int MAJOR_INFORMATION = 4;/*附加信息*/
        //次类型
        public const int MINOR_HDD_INFO = 161;/*硬盘信息*/
        public const int MINOR_SMART_INFO = 162;/*SMART信息*/
        public const int MINOR_REC_START = 163;/*开始录像*/
        public const int MINOR_REC_STOP = 164;/*停止录像*/
        public const int MINOR_REC_OVERDUE = 165;/*过期录像删除*/
        public const int MINOR_LINK_START = 166;//连接前端设备
        public const int MINOR_LINK_STOP = 167;//断开前端设备　
        public const int MINOR_NET_DISK_INFO = 168;//网络硬盘信息

        //当日志的主类型为MAJOR_OPERATION=03，次类型为MINOR_LOCAL_CFG_PARM=0x52或者MINOR_REMOTE_GET_PARM=0x76或者MINOR_REMOTE_CFG_PARM=0x77时，dwParaType:参数类型有效，其含义如下：
        public const int PARA_VIDEOOUT = 1;
        public const int PARA_IMAGE = 2;
        public const int PARA_ENCODE = 4;
        public const int PARA_NETWORK = 8;
        public const int PARA_ALARM = 16;
        public const int PARA_EXCEPTION = 32;
        public const int PARA_DECODER = 64;/*解码器*/
        public const int PARA_RS232 = 128;
        public const int PARA_PREVIEW = 256;
        public const int PARA_SECURITY = 512;
        public const int PARA_DATETIME = 1024;
        public const int PARA_FRAMETYPE = 2048;/*帧格式*/
        //vca
        public const int PARA_VCA_RULE = 4096;//行为规则
        /************************DVR日志 End***************************/


        /*******************查找文件和日志函数返回值*************************/
        public const int NET_DVR_FILE_SUCCESS = 1000;//获得文件信息
        public const int NET_DVR_FILE_NOFIND = 1001;//没有文件
        public const int NET_DVR_ISFINDING = 1002;//正在查找文件
        public const int NET_DVR_NOMOREFILE = 1003;//查找文件时没有更多的文件
        public const int NET_DVR_FILE_EXCEPTION = 1004;//查找文件时异常

        /*********************回调函数类型 begin************************/
        public const int COMM_ALARM = 0x1100;//8000报警信息主动上传，对应NET_DVR_ALARMINFO
        public const int COMM_ALARM_RULE = 0x1102;//行为分析报警信息，对应NET_VCA_RULE_ALARM
        public const int COMM_ALARM_PDC = 0x1103;//人流量统计报警上传，对应NET_DVR_PDC_ALRAM_INFO
        public const int COMM_ALARM_ALARMHOST = 0x1105;//网络报警主机报警上传，对应NET_DVR_ALARMHOST_ALARMINFO
        public const int COMM_ALARM_FACE = 0x1106;//人脸检测识别报警信息，对应NET_DVR_FACEDETECT_ALARM
        public const int COMM_RULE_INFO_UPLOAD = 0x1107;  // 事件数据信息上传
        public const int COMM_ALARM_AID = 0x1110;  //交通事件报警信息
        public const int COMM_ALARM_TPS = 0x1111;  //交通参数统计报警信息
        public const int COMM_UPLOAD_FACESNAP_RESULT = 0x1112;  //人脸识别结果上传
        public const int COMM_ALARM_FACE_DETECTION = 0x4010; //人脸侦测报警信息
        public const int COMM_ALARM_TFS = 0x1113;  //交通取证报警信息
        public const int COMM_ALARM_TPS_V41 = 0x1114;  //交通参数统计报警信息扩展
        public const int COMM_ALARM_AID_V41 = 0x1115;  //交通事件报警信息扩展
        public const int COMM_ALARM_VQD_EX = 0x1116;	 //视频质量诊断报警
        public const int COMM_SENSOR_VALUE_UPLOAD = 0x1120;  //模拟量数据实时上传
        public const int COMM_SENSOR_ALARM = 0x1121;  //模拟量报警上传
        public const int COMM_SWITCH_ALARM = 0x1122;	 //开关量报警
        public const int COMM_ALARMHOST_EXCEPTION = 0x1123; //报警主机故障报警
        public const int COMM_ALARMHOST_OPERATEEVENT_ALARM = 0x1124;  //操作事件报警上传
        public const int COMM_ALARMHOST_SAFETYCABINSTATE = 0x1125;	 //防护舱状态
        public const int COMM_ALARMHOST_ALARMOUTSTATUS = 0x1126;	 //报警输出口/警号状态
        public const int COMM_ALARMHOST_CID_ALARM = 0x1127;	 //CID报告报警上传
        public const int COMM_ALARMHOST_EXTERNAL_DEVICE_ALARM = 0x1128;	 //报警主机外接设备报警上传
        public const int COMM_ALARMHOST_DATA_UPLOAD = 0x1129;	 //报警数据上传
        public const int COMM_UPLOAD_VIDEO_INTERCOM_EVENT = 0x1132;  //可视对讲事件记录上传
        public const int COMM_ALARM_AUDIOEXCEPTION = 0x1150;	 //声音报警信息
        public const int COMM_ALARM_DEFOCUS = 0x1151;	 //虚焦报警信息
        public const int COMM_ALARM_BUTTON_DOWN_EXCEPTION = 0x1152;	 //按钮按下报警信息
        public const int COMM_ALARM_ALARMGPS = 0x1202; //GPS报警信息上传
        public const int COMM_TRADEINFO = 0x1500;  //ATMDVR主动上传交易信息
        public const int COMM_UPLOAD_PLATE_RESULT = 0x2800;	 //上传车牌信息
        public const int COMM_ITC_STATUS_DETECT_RESULT = 0x2810;  //实时状态检测结果上传(智能高清IPC)
        public const int COMM_IPC_AUXALARM_RESULT = 0x2820;  //PIR报警、无线报警、呼救报警上传
        public const int COMM_UPLOAD_PICTUREINFO = 0x2900;	 //上传图片信息
        public const int COMM_SNAP_MATCH_ALARM = 0x2902;  //禁止名单比对结果上传
        public const int COMM_ITS_PLATE_RESULT = 0x3050;  //终端图片上传
        public const int COMM_ITS_TRAFFIC_COLLECT = 0x3051;  //终端统计数据上传
        public const int COMM_ITS_GATE_VEHICLE = 0x3052;  //出入口车辆抓拍数据上传
        public const int COMM_ITS_GATE_FACE = 0x3053; //出入口人脸抓拍数据上传
        public const int COMM_ITS_GATE_COSTITEM = 0x3054;  //出入口过车收费明细 2013-11-19
        public const int COMM_ITS_GATE_HANDOVER = 0x3055; //出入口交接班数据 2013-11-19
        public const int COMM_ITS_PARK_VEHICLE = 0x3056;  //停车场数据上传
        public const int COMM_ITS_BLOCKLIST_ALARM = 0x3057;  //禁止名单报警上传
        public const int COMM_ALARM_TPS_REAL_TIME = 0x3081;  //TPS实时过车数据上传
        public const int COMM_ALARM_TPS_STATISTICS = 0x3082;  //TPS统计过车数据上传
        public const int COMM_ALARM_V30 = 0x4000;	 //9000报警信息主动上传
        public const int COMM_IPCCFG = 0x4001;	 //9000设备IPC接入配置改变报警信息主动上传
        public const int COMM_IPCCFG_V31 = 0x4002;	 //9000设备IPC接入配置改变报警信息主动上传扩展 9000_1.1
        public const int COMM_IPCCFG_V40 = 0x4003; // IVMS 2000 编码服务器 NVR IPC接入配置改变时报警信息上传
        public const int COMM_ALARM_DEVICE = 0x4004;  //设备报警内容，由于通道值大于256而扩展
        public const int COMM_ALARM_CVR = 0x4005;  //CVR 2.0.X外部报警类型
        public const int COMM_ALARM_HOT_SPARE = 0x4006;  //热备异常报警（N+1模式异常报警）
        public const int COMM_ALARM_V40 = 0x4007;	//移动侦测，视频丢失，遮挡，IO信号量等报警信息主动上传，报警数据为可变长
        public const int COMM_UPLOAD_HEATMAP_RESULT = 0x4008; //热度图报警上传

        public const int COMM_ITS_ROAD_EXCEPTION = 0x4500;	 //路口设备异常报警
        public const int COMM_ITS_EXTERNAL_CONTROL_ALARM = 0x4520;  //外控报警
        public const int COMM_FIREDETECTION_ALARM = 0x4991;  //火点检测报警
        public const int COMM_SCREEN_ALARM = 0x5000;  //多屏控制器报警类型
        public const int COMM_DVCS_STATE_ALARM = 0x5001;  //分布式大屏控制器报警上传
        public const int COMM_ALARM_VQD = 0x6000;  //VQD主动报警上传 
        public const int COMM_PUSH_UPDATE_RECORD_INFO = 0x6001;  //推模式录像信息上传
        public const int COMM_DIAGNOSIS_UPLOAD = 0x5100;  //诊断服务器VQD报警上传
        public const int COMM_ALARM_ACS = 0x5002;  //门禁主机报警
        public const int COMM_ID_INFO_ALARM = 0x5200;  //身份证信息上传
        public const int COMM_PASSNUM_INFO_ALARM = 0x5201;  //通行人数上报
        public const int COMM_ISAPI_ALARM = 0x6009;

        public const int COMM_THERMOMETRY_ALARM = 0x5212; //温度报警信息

        public const int COMM_UPLOAD_AIOP_VIDEO = 0x4021; //设备支持AI开放平台接入，上传视频检测数据
        public const int COMM_UPLOAD_AIOP_PICTURE = 0x4022; //设备支持AI开放平台接入，上传图片检测数据
        public const int COMM_UPLOAD_AIOP_POLLING_SNAP = 0x4023; //设备支持AI开放平台接入，上传轮巡抓图图片检测数据 对应的结构体(NET_AIOP_POLLING_SNAP_HEAD)
        public const int COMM_UPLOAD_AIOP_POLLING_VIDEO = 0x4024; //设备支持AI开放平台接入，上传轮巡视频检测数据 对应的结构体(NET_AIOP_POLLING_VIDEO_HEAD)



        public const int NET_DVR_JSON_CONFIG = 2550;
        public const int NET_DVR_FACE_DATA_RECORD = 2551;
        public const int NET_DVR_FACE_DATA_SEARCH = 2552;
        public const int NET_DVR_FACE_DATA_MODIFY = 2553;

        public const int NET_DVR_REMOTECONTROL_GATEWAY = 16009;  //远程开锁
        #endregion
        public const int ERROR_MSG_LEN = 32;
        public const int MAX_FINGER_PRINT_LEN = 768;
        public const int NET_DVR_CAPTURE_FINGERPRINT_INFO = 2504;

        public const int MAX_CENTERNUM = 4;

        public const int ALARMHOST_ABILITY = 0x500;

        public const int NET_DVR_SET_ALARMHOST_NETCFG_V50 = 2225;    //Set Net info V50
        public const int NET_DVR_GET_ALARMHOST_NETCFG_V50 = 2224;    //Get Net infoV50

        public const int MAX_AUDIO_V40 = 8;

        public const int NET_DVR_GET_NETCFG_V50 = 1015;    //Get network parameter configuration (V50) 
        public const int NET_DVR_SET_NETCFG_V50 = 1016;    //Set network parameter configuration (V50) 

        public const int DOOR_NAME_LEN = 32;//door name len 
        public const int STRESS_PASSWORD_LEN = 8;//stress password len
        public const int SUPER_PASSWORD_LEN = 8;//super password len
        public const int UNLOCK_PASSWORD_LEN = 8;
        public const int MAX_DOOR_NUM = 32;
        public const int MAX_GROUP_NUM = 32;
        public const int LOCAL_CONTROLLER_NAME_LEN = 32;

        public const int NET_DVR_GET_DOOR_CFG = 2108; //get door parameter
        public const int NET_DVR_SET_DOOR_CFG = 2109; //set door parameter

        public const int NET_DVR_SET_ALARMHOST_REPORT_CENTER_V40 = 2065;   // set data report mode v30

        /*************操作异常类型(消息方式, 回调方式(保留))****************/
        public const int EXCEPTION_EXCHANGE = 32768;//用户交互时异常
        public const int EXCEPTION_AUDIOEXCHANGE = 32769;//语音对讲异常
        public const int EXCEPTION_ALARM = 32770;//报警异常
        public const int EXCEPTION_PREVIEW = 32771;//网络预览异常
        public const int EXCEPTION_SERIAL = 32772;//透明通道异常
        public const int EXCEPTION_RECONNECT = 32773;//预览时重连
        public const int EXCEPTION_ALARMRECONNECT = 32774;//报警时重连
        public const int EXCEPTION_SERIALRECONNECT = 32775;//透明通道重连
        public const int EXCEPTION_PLAYBACK = 32784;//回放异常
        public const int EXCEPTION_DISKFMT = 32785;//硬盘格式化

        /********************预览回调函数*********************/
        public const int NET_DVR_SYSHEAD = 1;//系统头数据
        public const int NET_DVR_STREAMDATA = 2;//视频流数据（包括复合流和音视频分开的视频流数据）
        public const int NET_DVR_AUDIOSTREAMDATA = 3;//音频流数据
        public const int NET_DVR_STD_VIDEODATA = 4;//标准视频流数据
        public const int NET_DVR_STD_AUDIODATA = 5;//标准音频流数据

        //回调预览中的状态和消息
        public const int NET_DVR_REALPLAYEXCEPTION = 111;//预览异常
        public const int NET_DVR_REALPLAYNETCLOSE = 112;//预览时连接断开
        public const int NET_DVR_REALPLAY5SNODATA = 113;//预览5s没有收到数据
        public const int NET_DVR_REALPLAYRECONNECT = 114;//预览重连

        /********************回放回调函数*********************/
        public const int NET_DVR_PLAYBACKOVER = 101;//回放数据播放完毕
        public const int NET_DVR_PLAYBACKEXCEPTION = 102;//回放异常
        public const int NET_DVR_PLAYBACKNETCLOSE = 103;//回放时候连接断开
        public const int NET_DVR_PLAYBACK5SNODATA = 104;//回放5s没有收到数据

        /*********************回调函数类型 end************************/
        //设备型号(DVR类型)
        /* 设备类型 */
        public const int DVR = 1;/*对尚未定义的dvr类型返回NETRET_DVR*/
        public const int ATMDVR = 2;/*atm dvr*/
        public const int DVS = 3;/*DVS*/
        public const int DEC = 4;/* 6001D */
        public const int ENC_DEC = 5;/* 6001F */
        public const int DVR_HC = 6;/*8000HC*/
        public const int DVR_HT = 7;/*8000HT*/
        public const int DVR_HF = 8;/*8000HF*/
        public const int DVR_HS = 9;/* 8000HS DVR(no audio) */
        public const int DVR_HTS = 10; /* 8016HTS DVR(no audio) */
        public const int DVR_HB = 11; /* HB DVR(SATA HD) */
        public const int DVR_HCS = 12; /* 8000HCS DVR */
        public const int DVS_A = 13; /* 带ATA硬盘的DVS */
        public const int DVR_HC_S = 14; /* 8000HC-S */
        public const int DVR_HT_S = 15;/* 8000HT-S */
        public const int DVR_HF_S = 16;/* 8000HF-S */
        public const int DVR_HS_S = 17; /* 8000HS-S */
        public const int ATMDVR_S = 18;/* ATM-S */
        public const int LOWCOST_DVR = 19;/*7000H系列*/
        public const int DEC_MAT = 20; /*多路解码器*/
        public const int DVR_MOBILE = 21;/* mobile DVR */
        public const int DVR_HD_S = 22;   /* 8000HD-S */
        public const int DVR_HD_SL = 23;/* 8000HD-SL */
        public const int DVR_HC_SL = 24;/* 8000HC-SL */
        public const int DVR_HS_ST = 25;/* 8000HS_ST */
        public const int DVS_HW = 26; /* 6000HW */
        public const int DS630X_D = 27; /* 多路解码器 */
        public const int IPCAM = 30;/*IP 摄像机*/
        public const int MEGA_IPCAM = 31;/*X52MF系列,752MF,852MF*/
        public const int IPCAM_X62MF = 32;/*X62MF系列可接入9000设备,762MF,862MF*/
        public const int IPDOME = 40; /*IP 标清球机*/
        public const int IPDOME_MEGA200 = 41;/*IP 200万高清球机*/
        public const int IPDOME_MEGA130 = 42;/*IP 130万高清球机*/
        public const int IPMOD = 50;/*IP 模块*/
        public const int DS71XX_H = 71;/* DS71XXH_S */
        public const int DS72XX_H_S = 72;/* DS72XXH_S */
        public const int DS73XX_H_S = 73;/* DS73XXH_S */
        public const int DS76XX_H_S = 76;/* DS76XX_H_S */
        public const int DS81XX_HS_S = 81;/* DS81XX_HS_S */
        public const int DS81XX_HL_S = 82;/* DS81XX_HL_S */
        public const int DS81XX_HC_S = 83;/* DS81XX_HC_S */
        public const int DS81XX_HD_S = 84;/* DS81XX_HD_S */
        public const int DS81XX_HE_S = 85;/* DS81XX_HE_S */
        public const int DS81XX_HF_S = 86;/* DS81XX_HF_S */
        public const int DS81XX_AH_S = 87;/* DS81XX_AH_S */
        public const int DS81XX_AHF_S = 88;/* DS81XX_AHF_S */
        public const int DS90XX_HF_S = 90;  /*DS90XX_HF_S*/
        public const int DS91XX_HF_S = 91;  /*DS91XX_HF_S*/
        public const int DS91XX_HD_S = 92; /*91XXHD-S(MD)*/
        /**********************设备类型 end***********************/

        /**********************能力集类型 begin***********************/
        public const int DEVICE_SOFTHARDWARE_ABILITY = 0x001;
        public const int DEVICE_NETWORK_ABILITY = 0x002;
        public const int DEVICE_ENCODE_ALL_ABILITY_V20 = 0x008;
        public const int IPC_FRONT_PARAMETER_V20 = 0x009;
        public const int DEVICE_RAID_ABILITY = 0x007;
        public const int DEVICE_ALARM_ABILITY = 0x00a;
        public const int DEVICE_DYNCHAN_ABILITY = 0x00b;
        public const int DEVICE_USER_ABILITY = 0x00c;
        public const int DEVICE_NETAPP_ABILITY = 0x00d;
        public const int DEVICE_VIDEOPIC_ABILITY = 0x00e;
        public const int DEVICE_JPEG_CAP_ABILITY = 0x00f;
        public const int DEVICE_SERIAL_ABILITY = 0x010;
        public const int DEVICE_ABILITY_INFO = 0x011;
        /**********************能力集类型 end***********************/

        /*************************************************
        门禁事件类型
        **************************************************/
        #region acs event upload

        /* Alarm */
        // Main Type
        //public const int MAJOR_ALARM = 0x1;
        // Hypo- Type
        public const int MINOR_ALARMIN_SHORT_CIRCUIT = 0x400; // region short circuit 
        public const int MINOR_ALARMIN_BROKEN_CIRCUIT = 0x401; // region broken circuit
        public const int MINOR_ALARMIN_EXCEPTION = 0x402; // region exception 
        public const int MINOR_ALARMIN_RESUME = 0x403; // region resume 
        public const int MINOR_HOST_DESMANTLE_ALARM = 0x404; // host desmantle alarm
        public const int MINOR_HOST_DESMANTLE_RESUME = 0x405; //  host desmantle resume
        public const int MINOR_CARD_READER_DESMANTLE_ALARM = 0x406; // card reader desmantle alarm 
        public const int MINOR_CARD_READER_DESMANTLE_RESUME = 0x407; // card reader desmantle resume
        public const int MINOR_CASE_SENSOR_ALARM = 0x408; // case sensor alarm 
        public const int MINOR_CASE_SENSOR_RESUME = 0x409; // case sensor resume 
        public const int MINOR_STRESS_ALARM = 0x40a; // stress alarm 
        public const int MINOR_OFFLINE_ECENT_NEARLY_FULL = 0x40b; // offline ecent nearly full 
        public const int MINOR_CARD_MAX_AUTHENTICATE_FAIL = 0x40c; // card max authenticate fall 
        public const int MINOR_SD_CARD_FULL = 0x40d; // SD card is full
        public const int MINOR_LINKAGE_CAPTURE_PIC = 0x40e; // lingage capture picture
        public const int MINOR_SECURITY_MODULE_DESMANTLE_ALARM = 0x40f;  //Door control security module desmantle alarm
        public const int MINOR_SECURITY_MODULE_DESMANTLE_RESUME = 0x410;  //Door control security module desmantle resume
        public const int MINOR_POS_START_ALARM = 0x411; // POS Start
        public const int MINOR_POS_END_ALARM = 0x412; // POS end
        public const int MINOR_FACE_IMAGE_QUALITY_LOW = 0x413; // face image quality low
        public const int MINOR_FINGE_RPRINT_QUALITY_LOW = 0x414; // finger print quality low
        public const int MINOR_FIRE_IMPORT_SHORT_CIRCUIT = 0x415; // Fire import short circuit
        public const int MINOR_FIRE_IMPORT_BROKEN_CIRCUIT = 0x416; // Fire import broken circuit
        public const int MINOR_FIRE_IMPORT_RESUME = 0x417; // Fire import resume
        public const int MINOR_FIRE_BUTTON_TRIGGER = 0x418; // fire button trigger
        public const int MINOR_FIRE_BUTTON_RESUME = 0x419; // fire button resume
        public const int MINOR_MAINTENANCE_BUTTON_TRIGGER = 0x41a; // maintenance button trigger
        public const int MINOR_MAINTENANCE_BUTTON_RESUME = 0x41b; // maintenance button resume
        public const int MINOR_EMERGENCY_BUTTON_TRIGGER = 0x41c; // emergency button trigger
        public const int MINOR_EMERGENCY_BUTTON_RESUME = 0x41d; // emergency button resume
        public const int MINOR_DISTRACT_CONTROLLER_ALARM = 0x41e; // distract controller alarm
        public const int MINOR_DISTRACT_CONTROLLER_RESUME = 0x41f; // distract controller resume
        public const int MINOR_CHANNEL_CONTROLLER_DESMANTLE_ALARM = 0x422; //channel controller desmantle alarm
        public const int MINOR_CHANNEL_CONTROLLER_DESMANTLE_RESUME = 0x423; //channel controller desmantle resume
        public const int MINOR_CHANNEL_CONTROLLER_FIRE_IMPORT_ALARM = 0x424; //channel controller fire import alarm
        public const int MINOR_CHANNEL_CONTROLLER_FIRE_IMPORT_RESUME = 0x425;  //channel controller fire import resume
        public const int MINOR_PRINTER_OUT_OF_PAPER = 0x440;  //printer no paper
        public const int MINOR_LEGAL_EVENT_NEARLY_FULL = 0x442;  //Legal event nearly full

        /* Exception*/
        // Main Type
        //public const int MAJOR_EXCEPTION = 0x2;
        // Hypo- Type

        //public const int MINOR_NET_BROKEN = 0x27; // Network disconnected 
        public const int MINOR_RS485_DEVICE_ABNORMAL = 0x3a; // RS485 connect status exception
        public const int MINOR_RS485_DEVICE_REVERT = 0x3b; // RS485 connect status exception recovery

        public const int MINOR_DEV_POWER_ON = 0x400; // device power on
        public const int MINOR_DEV_POWER_OFF = 0x401; // device power off
        public const int MINOR_WATCH_DOG_RESET = 0x402; // watch dog reset 
        public const int MINOR_LOW_BATTERY = 0x403; // low battery 
        public const int MINOR_BATTERY_RESUME = 0x404; // battery resume
        public const int MINOR_AC_OFF = 0x405; // AC off
        public const int MINOR_AC_RESUME = 0x406; // AC resume 
        public const int MINOR_NET_RESUME = 0x407; // Net resume
        public const int MINOR_FLASH_ABNORMAL = 0x408; // FLASH abnormal 
        public const int MINOR_CARD_READER_OFFLINE = 0x409; // card reader offline 
        public const int MINOR_CARD_READER_RESUME = 0x40a; // card reader resume 
        public const int MINOR_INDICATOR_LIGHT_OFF = 0x40b; // Indicator Light Off
        public const int MINOR_INDICATOR_LIGHT_RESUME = 0x40c; // Indicator Light Resume
        public const int MINOR_CHANNEL_CONTROLLER_OFF = 0x40d; // channel controller off
        public const int MINOR_CHANNEL_CONTROLLER_RESUME = 0x40e; // channel controller resume
        public const int MINOR_SECURITY_MODULE_OFF = 0x40f; // Door control security module off
        public const int MINOR_SECURITY_MODULE_RESUME = 0x410; // Door control security module resume
        public const int MINOR_BATTERY_ELECTRIC_LOW = 0x411; // battery electric low
        public const int MINOR_BATTERY_ELECTRIC_RESUME = 0x412; // battery electric resume
        public const int MINOR_LOCAL_CONTROL_NET_BROKEN = 0x413; // Local control net broken
        public const int MINOR_LOCAL_CONTROL_NET_RSUME = 0x414; // Local control net resume
        public const int MINOR_MASTER_RS485_LOOPNODE_BROKEN = 0x415; // Master RS485 loop node broken
        public const int MINOR_MASTER_RS485_LOOPNODE_RESUME = 0x416; // Master RS485 loop node resume
        public const int MINOR_LOCAL_CONTROL_OFFLINE = 0x417; // Local control offline
        public const int MINOR_LOCAL_CONTROL_RESUME = 0x418; // Local control resume
        public const int MINOR_LOCAL_DOWNSIDE_RS485_LOOPNODE_BROKEN = 0x419; // Local downside RS485 loop node broken
        public const int MINOR_LOCAL_DOWNSIDE_RS485_LOOPNODE_RESUME = 0x41a; // Local downside RS485 loop node resume
        public const int MINOR_DISTRACT_CONTROLLER_ONLINE = 0x41b; // distract controller online
        public const int MINOR_DISTRACT_CONTROLLER_OFFLINE = 0x41c; // distract controller offline
        public const int MINOR_ID_CARD_READER_NOT_CONNECT = 0x41d; // Id card reader not connected(intelligent dedicated)
        public const int MINOR_ID_CARD_READER_RESUME = 0x41e; //Id card reader connection restored(intelligent dedicated)
        public const int MINOR_FINGER_PRINT_MODULE_NOT_CONNECT = 0x41f; // fingerprint module is not connected(intelligent dedicated)
        public const int MINOR_FINGER_PRINT_MODULE_RESUME = 0x420; // The fingerprint module connection restored(intelligent dedicated)
        public const int MINOR_CAMERA_NOT_CONNECT = 0x421; // Camera not connected
        public const int MINOR_CAMERA_RESUME = 0x422; // Camera connection restored
        public const int MINOR_COM_NOT_CONNECT = 0x423; // COM not connected
        public const int MINOR_COM_RESUME = 0x424;// COM connection restored
        public const int MINOR_DEVICE_NOT_AUTHORIZE = 0x425; // device are not authorized
        public const int MINOR_PEOPLE_AND_ID_CARD_DEVICE_ONLINE = 0x426; // people and ID card device online
        public const int MINOR_PEOPLE_AND_ID_CARD_DEVICE_OFFLINE = 0x427;// people and ID card device offline
        public const int MINOR_LOCAL_LOGIN_LOCK = 0x428; // local login lock
        public const int MINOR_LOCAL_LOGIN_UNLOCK = 0x429; //local login unlock
        public const int MINOR_SUBMARINEBACK_COMM_BREAK = 0x42a;  //submarineback communicate break
        public const int MINOR_SUBMARINEBACK_COMM_RESUME = 0x42b;  //submarineback communicate resume
        public const int MINOR_MOTOR_SENSOR_EXCEPTION = 0x42c;  //motor sensor exception
        public const int MINOR_CAN_BUS_EXCEPTION = 0x42d;  //can bus exception
        public const int MINOR_CAN_BUS_RESUME = 0x42e;  //can bus resume
        public const int MINOR_GATE_TEMPERATURE_OVERRUN = 0x42f; //gate temperature over run
        public const int MINOR_IR_EMITTER_EXCEPTION = 0x430; //IR emitter exception
        public const int MINOR_IR_EMITTER_RESUME = 0x431;  //IR emitter resume
        public const int MINOR_LAMP_BOARD_COMM_EXCEPTION = 0x432;  //lamp board communicate exception
        public const int MINOR_LAMP_BOARD_COMM_RESUME = 0x433;  //lamp board communicate resume
        public const int MINOR_IR_ADAPTOR_COMM_EXCEPTION = 0x434; //IR adaptor communicate exception
        public const int MINOR_IR_ADAPTOR_COMM_RESUME = 0x435;  //IR adaptor communicate resume
        public const int MINOR_PRINTER_ONLINE = 0x436; //printer online
        public const int MINOR_PRINTER_OFFLINE = 0x437; //printer offline
        public const int MINOR_4G_MOUDLE_ONLINE = 0x438; //4G module online
        public const int MINOR_4G_MOUDLE_OFFLINE = 0x439; //4G module offline


        /* Operation  */
        // Main Type
        //public const int MAJOR_OPERATION = 0x3;

        // Hypo- Type
        //public const int MINOR_LOCAL_UPGRADE = 0x5a; // Upgrade  (local)
        //public const int MINOR_REMOTE_LOGIN = 0x70; // Login  (remote)
        //public const int MINOR_REMOTE_LOGOUT = 0x71; // Logout   (remote)
        //public const int MINOR_REMOTE_ARM = 0x79; // On guard   (remote)
        //public const int MINOR_REMOTE_DISARM = 0x7a; // Disarm   (remote)
        //public const int MINOR_REMOTE_REBOOT = 0x7b; // Reboot   (remote)
        //public const int MINOR_REMOTE_UPGRADE = 0x7e; // upgrade  (remote)
        //public const int MINOR_REMOTE_CFGFILE_OUTPUT = 0x86; // Export Configuration   (remote) 
        //public const int MINOR_REMOTE_CFGFILE_INTPUT = 0x87; // Import Configuration  (remote) 
        //public const int MINOR_REMOTE_ALARMOUT_OPEN_MAN = 0xd6; // remote mamual open alarmout 
        //public const int MINOR_REMOTE_ALARMOUT_CLOSE_MAN = 0xd7; // remote mamual close alarmout 

        public const int MINOR_REMOTE_OPEN_DOOR = 0x400; // remote open door 
        public const int MINOR_REMOTE_CLOSE_DOOR = 0x401; // remote close door (controlled) 
        public const int MINOR_REMOTE_ALWAYS_OPEN = 0x402; // remote always open door (free) 
        public const int MINOR_REMOTE_ALWAYS_CLOSE = 0x403; // remote always close door (forbiden)
        public const int MINOR_REMOTE_CHECK_TIME = 0x404; // remote check time 
        public const int MINOR_NTP_CHECK_TIME = 0x405; // ntp check time 
        public const int MINOR_REMOTE_CLEAR_CARD = 0x406; // remote clear card 
        public const int MINOR_REMOTE_RESTORE_CFG = 0x407; // remote restore configure 
        public const int MINOR_ALARMIN_ARM = 0x408; // alarm in arm 
        public const int MINOR_ALARMIN_DISARM = 0x409; // alarm in disarm 
        public const int MINOR_LOCAL_RESTORE_CFG = 0x40a; // local configure restore 
        public const int MINOR_REMOTE_CAPTURE_PIC = 0x40b; // remote capture picture 
        public const int MINOR_MOD_NET_REPORT_CFG = 0x40c; // modify net report cfg 
        public const int MINOR_MOD_GPRS_REPORT_PARAM = 0x40d; // modify GPRS report param 
        public const int MINOR_MOD_REPORT_GROUP_PARAM = 0x40e; // modify report group param 
        public const int MINOR_UNLOCK_PASSWORD_OPEN_DOOR = 0x40f; // unlock password open door 
        public const int MINOR_AUTO_RENUMBER = 0x410; // auto renumber 
        public const int MINOR_AUTO_COMPLEMENT_NUMBER = 0x411; // auto complement number 
        public const int MINOR_NORMAL_CFGFILE_INPUT = 0x412; // normal cfg file input 
        public const int MINOR_NORMAL_CFGFILE_OUTTPUT = 0x413; // normal cfg file output 
        public const int MINOR_CARD_RIGHT_INPUT = 0x414; // card right input 
        public const int MINOR_CARD_RIGHT_OUTTPUT = 0x415; // card right output 
        public const int MINOR_LOCAL_USB_UPGRADE = 0x416; // local USB upgrade 
        public const int MINOR_REMOTE_VISITOR_CALL_LADDER = 0x417; // visitor call ladder 
        public const int MINOR_REMOTE_HOUSEHOLD_CALL_LADDER = 0x418; // household call ladder 
        public const int MINOR_REMOTE_ACTUAL_GUARD = 0x419;  //remote actual guard
        public const int MINOR_REMOTE_ACTUAL_UNGUARD = 0x41a;  //remote actual unguard
        public const int MINOR_REMOTE_CONTROL_NOT_CODE_OPER_FAILED = 0x41b; //remote control not code operate failed
        public const int MINOR_REMOTE_CONTROL_CLOSE_DOOR = 0x41c; //remote control close door
        public const int MINOR_REMOTE_CONTROL_OPEN_DOOR = 0x41d; //remote control open door
        public const int MINOR_REMOTE_CONTROL_ALWAYS_OPEN_DOOR = 0x41e; //remote control always open door

        /* Additional Log Info*/
        // Main Type
        public const int MAJOR_EVENT = 0x5;/*event*/
        // Hypo- Type
        public const int MINOR_LEGAL_CARD_PASS = 0x01; // legal card pass
        public const int MINOR_CARD_AND_PSW_PASS = 0x02; // swipe and password pass
        public const int MINOR_CARD_AND_PSW_FAIL = 0x03; // swipe and password fail
        public const int MINOR_CARD_AND_PSW_TIMEOUT = 0x04; // swipe and password timeout
        public const int MINOR_CARD_AND_PSW_OVER_TIME = 0x05; // swipe and password over time
        public const int MINOR_CARD_NO_RIGHT = 0x06; // card no right 
        public const int MINOR_CARD_INVALID_PERIOD = 0x07; // invalid period 
        public const int MINOR_CARD_OUT_OF_DATE = 0x08; // card out of date
        public const int MINOR_INVALID_CARD = 0x09; // invalid card 
        public const int MINOR_ANTI_SNEAK_FAIL = 0x0a; // anti sneak fail 
        public const int MINOR_INTERLOCK_DOOR_NOT_CLOSE = 0x0b; // interlock door doesn't close
        public const int MINOR_NOT_BELONG_MULTI_GROUP = 0x0c; // card no belong multi group 
        public const int MINOR_INVALID_MULTI_VERIFY_PERIOD = 0x0d; // invalid multi verify period 
        public const int MINOR_MULTI_VERIFY_SUPER_RIGHT_FAIL = 0x0e; // have no super right in multi verify mode 
        public const int MINOR_MULTI_VERIFY_REMOTE_RIGHT_FAIL = 0x0f; // have no remote right in multi verify mode 
        public const int MINOR_MULTI_VERIFY_SUCCESS = 0x10; // success in multi verify mode 
        public const int MINOR_LEADER_CARD_OPEN_BEGIN = 0x11; // leader card begin to open
        public const int MINOR_LEADER_CARD_OPEN_END = 0x12; // leader card end to open 
        public const int MINOR_ALWAYS_OPEN_BEGIN = 0x13; // always open begin
        public const int MINOR_ALWAYS_OPEN_END = 0x14; // always open end
        public const int MINOR_LOCK_OPEN = 0x15; // lock open
        public const int MINOR_LOCK_CLOSE = 0x16; // lock close
        public const int MINOR_DOOR_BUTTON_PRESS = 0x17; // press door open button 
        public const int MINOR_DOOR_BUTTON_RELEASE = 0x18; // release door open button 
        public const int MINOR_DOOR_OPEN_NORMAL = 0x19; // door open normal 
        public const int MINOR_DOOR_CLOSE_NORMAL = 0x1a; // door close normal 
        public const int MINOR_DOOR_OPEN_ABNORMAL = 0x1b; // open door abnormal 
        public const int MINOR_DOOR_OPEN_TIMEOUT = 0x1c; // open door timeout 
        public const int MINOR_ALARMOUT_ON = 0x1d; // alarm out turn on 
        public const int MINOR_ALARMOUT_OFF = 0x1e; // alarm out turn off 
        public const int MINOR_ALWAYS_CLOSE_BEGIN = 0x1f; // always close begin 
        public const int MINOR_ALWAYS_CLOSE_END = 0x20; // always close end 
        public const int MINOR_MULTI_VERIFY_NEED_REMOTE_OPEN = 0x21; // need remote open in multi verify mode 
        public const int MINOR_MULTI_VERIFY_SUPERPASSWD_VERIFY_SUCCESS = 0x22; // superpasswd verify success in multi verify mode 
        public const int MINOR_MULTI_VERIFY_REPEAT_VERIFY = 0x23; // repeat verify in multi verify mode 
        public const int MINOR_MULTI_VERIFY_TIMEOUT = 0x24; // timeout in multi verify mode 
        public const int MINOR_DOORBELL_RINGING = 0x25; // doorbell ringing 
        public const int MINOR_FINGERPRINT_COMPARE_PASS = 0x26; // fingerprint compare pass 
        public const int MINOR_FINGERPRINT_COMPARE_FAIL = 0x27; // fingerprint compare fail 
        public const int MINOR_CARD_FINGERPRINT_VERIFY_PASS = 0x28; // card and fingerprint verify pass 
        public const int MINOR_CARD_FINGERPRINT_VERIFY_FAIL = 0x29; // card and fingerprint verify fail 
        public const int MINOR_CARD_FINGERPRINT_VERIFY_TIMEOUT = 0x2a; // card and fingerprint verify timeout 
        public const int MINOR_CARD_FINGERPRINT_PASSWD_VERIFY_PASS = 0x2b; // card and fingerprint and passwd verify pass 
        public const int MINOR_CARD_FINGERPRINT_PASSWD_VERIFY_FAIL = 0x2c; // card and fingerprint and passwd verify fail 
        public const int MINOR_CARD_FINGERPRINT_PASSWD_VERIFY_TIMEOUT = 0x2d; // card and fingerprint and passwd verify timeout 
        public const int MINOR_FINGERPRINT_PASSWD_VERIFY_PASS = 0x2e; // fingerprint and passwd verify pass 
        public const int MINOR_FINGERPRINT_PASSWD_VERIFY_FAIL = 0x2f; // fingerprint and passwd verify fail 
        public const int MINOR_FINGERPRINT_PASSWD_VERIFY_TIMEOUT = 0x30; // fingerprint and passwd verify timeout 
        public const int MINOR_FINGERPRINT_INEXISTENCE = 0x31; // fingerprint inexistence 
        public const int MINOR_CARD_PLATFORM_VERIFY = 0x32; // card platform verify 
        public const int MINOR_CALL_CENTER = 0x33; // call center 
        public const int MINOR_FIRE_RELAY_TURN_ON_DOOR_ALWAYS_OPEN = 0x34; // fire relay turn on door always open 
        public const int MINOR_FIRE_RELAY_RECOVER_DOOR_RECOVER_NORMAL = 0x35; // fire relay recover door recover normal 
        public const int MINOR_FACE_AND_FP_VERIFY_PASS = 0x36; // face and finger print verify pass 
        public const int MINOR_FACE_AND_FP_VERIFY_FAIL = 0x37; // face and finger print verify fail 
        public const int MINOR_FACE_AND_FP_VERIFY_TIMEOUT = 0x38; // face and finger print verify timeout 
        public const int MINOR_FACE_AND_PW_VERIFY_PASS = 0x39; // face and password verify pass 
        public const int MINOR_FACE_AND_PW_VERIFY_FAIL = 0x3a; // face and password verify fail 
        public const int MINOR_FACE_AND_PW_VERIFY_TIMEOUT = 0x3b; // face and password verify timeout 
        public const int MINOR_FACE_AND_CARD_VERIFY_PASS = 0x3c; // face and card verify pass 
        public const int MINOR_FACE_AND_CARD_VERIFY_FAIL = 0x3d; // face and card verify fail 
        public const int MINOR_FACE_AND_CARD_VERIFY_TIMEOUT = 0x3e; // face and card verify timeout 
        public const int MINOR_FACE_AND_PW_AND_FP_VERIFY_PASS = 0x3f; // face and password and finger print verify pass 
        public const int MINOR_FACE_AND_PW_AND_FP_VERIFY_FAIL = 0x40; // face and password and finger print verify fail 
        public const int MINOR_FACE_AND_PW_AND_FP_VERIFY_TIMEOUT = 0x41; // face and password and finger print verify timeout 
        public const int MINOR_FACE_CARD_AND_FP_VERIFY_PASS = 0x42; // face and card and finger print verify pass 
        public const int MINOR_FACE_CARD_AND_FP_VERIFY_FAIL = 0x43; // face and card and finger print verify fail 
        public const int MINOR_FACE_CARD_AND_FP_VERIFY_TIMEOUT = 0x44; // face and card and finger print verify timeout 
        public const int MINOR_EMPLOYEENO_AND_FP_VERIFY_PASS = 0x45; // employee and finger print verify pass 
        public const int MINOR_EMPLOYEENO_AND_FP_VERIFY_FAIL = 0x46; // employee and finger print verify fail 
        public const int MINOR_EMPLOYEENO_AND_FP_VERIFY_TIMEOUT = 0x47; // employee and finger print verify timeout 
        public const int MINOR_EMPLOYEENO_AND_FP_AND_PW_VERIFY_PASS = 0x48; // employee and finger print and password verify pass 
        public const int MINOR_EMPLOYEENO_AND_FP_AND_PW_VERIFY_FAIL = 0x49; // employee and finger print and password verify fail 
        public const int MINOR_EMPLOYEENO_AND_FP_AND_PW_VERIFY_TIMEOUT = 0x4a; // employee and finger print and password verify timeout
        public const int MINOR_FACE_VERIFY_PASS = 0x4b; // face verify pass 
        public const int MINOR_FACE_VERIFY_FAIL = 0x4c; // face verify fail 
        public const int MINOR_EMPLOYEENO_AND_FACE_VERIFY_PASS = 0x4d; // employee no and face verify pass 
        public const int MINOR_EMPLOYEENO_AND_FACE_VERIFY_FAIL = 0x4e; // employee no and face verify fail 
        public const int MINOR_EMPLOYEENO_AND_FACE_VERIFY_TIMEOUT = 0x4f; // employee no and face verify time out 
        public const int MINOR_FACE_RECOGNIZE_FAIL = 0x50; // face recognize fail 
        public const int MINOR_FIRSTCARD_AUTHORIZE_BEGIN = 0x51; // first card authorize begin 
        public const int MINOR_FIRSTCARD_AUTHORIZE_END = 0x52; // first card authorize end 
        public const int MINOR_DOORLOCK_INPUT_SHORT_CIRCUIT = 0x53; // door lock input short circuit 
        public const int MINOR_DOORLOCK_INPUT_BROKEN_CIRCUIT = 0x54; // door lock input broken circuit 
        public const int MINOR_DOORLOCK_INPUT_EXCEPTION = 0x55; // door lock input exception 
        public const int MINOR_DOORCONTACT_INPUT_SHORT_CIRCUIT = 0x56; // door contact input short circuit 
        public const int MINOR_DOORCONTACT_INPUT_BROKEN_CIRCUIT = 0x57; // door contact input broken circuit 
        public const int MINOR_DOORCONTACT_INPUT_EXCEPTION = 0x58; // door contact input exception 
        public const int MINOR_OPENBUTTON_INPUT_SHORT_CIRCUIT = 0x59; // open button input short circuit 
        public const int MINOR_OPENBUTTON_INPUT_BROKEN_CIRCUIT = 0x5a; // open button input broken circuit 
        public const int MINOR_OPENBUTTON_INPUT_EXCEPTION = 0x5b; // open button input exception 
        public const int MINOR_DOORLOCK_OPEN_EXCEPTION = 0x5c; // door lock open exception 
        public const int MINOR_DOORLOCK_OPEN_TIMEOUT = 0x5d; // door lock open timeout 
        public const int MINOR_FIRSTCARD_OPEN_WITHOUT_AUTHORIZE = 0x5e; // first card open without authorize 
        public const int MINOR_CALL_LADDER_RELAY_BREAK = 0x5f; // call ladder relay break 
        public const int MINOR_CALL_LADDER_RELAY_CLOSE = 0x60; // call ladder relay close 
        public const int MINOR_AUTO_KEY_RELAY_BREAK = 0x61; // auto key relay break 
        public const int MINOR_AUTO_KEY_RELAY_CLOSE = 0x62; // auto key relay close 
        public const int MINOR_KEY_CONTROL_RELAY_BREAK = 0x63; // key control relay break 
        public const int MINOR_KEY_CONTROL_RELAY_CLOSE = 0x64; // key control relay close 
        public const int MINOR_EMPLOYEENO_AND_PW_PASS = 0x65; // minor employee no and password pass 
        public const int MINOR_EMPLOYEENO_AND_PW_FAIL = 0x66; // minor employee no and password fail 
        public const int MINOR_EMPLOYEENO_AND_PW_TIMEOUT = 0x67; // minor employee no and password timeout 
        public const int MINOR_HUMAN_DETECT_FAIL = 0x68; // human detect fail 
        public const int MINOR_PEOPLE_AND_ID_CARD_COMPARE_PASS = 0x69; // the comparison with people and id card success 
        public const int MINOR_PEOPLE_AND_ID_CARD_COMPARE_FAIL = 0x70; // the comparison with people and id card failed 
        public const int MINOR_CERTIFICATE_BLOCKLIST = 0x71; // block list 
        public const int MINOR_LEGAL_MESSAGE = 0x72; // legal message 
        public const int MINOR_ILLEGAL_MESSAGE = 0x73; // illegal messag 
        public const int MINOR_MAC_DETECT = 0x74; // mac detect 
        public const int MINOR_DOOR_OPEN_OR_DORMANT_FAIL = 0x75; //door open or dormant fail
        public const int MINOR_AUTH_PLAN_DORMANT_FAIL = 0x76;  //auth plan dormant fail
        public const int MINOR_CARD_ENCRYPT_VERIFY_FAIL = 0x77; //card encrypt verify fail
        public const int MINOR_SUBMARINEBACK_REPLY_FAIL = 0x78;  //submarineback reply fail
        public const int MINOR_DOOR_OPEN_OR_DORMANT_OPEN_FAIL = 0x82;  //door open or dormant open fail
        public const int MINOR_DOOR_OPEN_OR_DORMANT_LINKAGE_OPEN_FAIL = 0x84; //door open or dormant linkage open fail
        public const int MINOR_TRAILING = 0x85;  //trailing
        public const int MINOR_HEART_BEAT = 0x83;  //heart beat event
        public const int MINOR_REVERSE_ACCESS = 0x86; //reverse access
        public const int MINOR_FORCE_ACCESS = 0x87; //force access
        public const int MINOR_CLIMBING_OVER_GATE = 0x88; //climbing over gate
        public const int MINOR_PASSING_TIMEOUT = 0x89;  //passing timeout
        public const int MINOR_INTRUSION_ALARM = 0x8a;  //intrusion alarm
        public const int MINOR_FREE_GATE_PASS_NOT_AUTH = 0x8b; //free gate pass not auth
        public const int MINOR_DROP_ARM_BLOCK = 0x8c; //drop arm block
        public const int MINOR_DROP_ARM_BLOCK_RESUME = 0x8d;  //drop arm block resume
        public const int MINOR_LOCAL_FACE_MODELING_FAIL = 0x8e;  //device upgrade with module failed
        public const int MINOR_STAY_EVENT = 0x8f;  //stay event
        public const int MINOR_PASSWORD_MISMATCH = 0x97;  //password mismatch
        public const int MINOR_EMPLOYEE_NO_NOT_EXIST = 0x98;  //employee no not exist
        public const int MINOR_COMBINED_VERIFY_PASS = 0x99;  //combined verify pass
        public const int MINOR_COMBINED_VERIFY_TIMEOUT = 0x9a;  //combined verify timeout
        public const int MINOR_VERIFY_MODE_MISMATCH = 0x9b;  //verify mode mismatch
        #endregion

        /*************************************************
        参数配置结构、参数(其中_V30为9000新增)
        **************************************************/

        /*设备报警和异常处理方式*/
        public const int NOACTION = 0x0;/*无响应*/
        public const int WARNONMONITOR = 0x1;/*监视器上警告*/
        public const int WARNONAUDIOOUT = 0x2;/*声音警告*/
        public const int UPTOCENTER = 0x4;/*上传中心*/
        public const int TRIGGERALARMOUT = 0x8;/*触发报警输出*/
        public const int TRIGGERCATPIC = 0x10;/*触发抓图并上传E-mail*/
        public const int SEND_PIC_FTP = 0x200;  /*抓图并上传ftp*/

        //IPC接入参数配置

        //ATM专用
        /****************************ATM(begin)***************************/
        public const int NCR = 0;
        public const int DIEBOLD = 1;
        public const int WINCOR_NIXDORF = 2;
        public const int SIEMENS = 3;
        public const int OLIVETTI = 4;
        public const int FUJITSU = 5;
        public const int HITACHI = 6;
        public const int SMI = 7;
        public const int IBM = 8;
        public const int BULL = 9;
        public const int YiHua = 10;
        public const int LiDe = 11;
        public const int GDYT = 12;
        public const int Mini_Banl = 13;
        public const int GuangLi = 14;
        public const int DongXin = 15;
        public const int ChenTong = 16;
        public const int NanTian = 17;
        public const int XiaoXing = 18;
        public const int GZYY = 19;
        public const int QHTLT = 20;
        public const int DRS918 = 21;
        public const int KALATEL = 22;
        public const int NCR_2 = 23;
        public const int NXS = 24;


        /*编码类型*/
        public const int NET_DVR_ENCODER_UNKOWN = 0;/*未知编码格式*/
        public const int NET_DVR_ENCODER_H264 = 1;/*HIK 264*/
        public const int NET_DVR_ENCODER_S264 = 2;/*Standard H264*/
        public const int NET_DVR_ENCODER_MPEG4 = 3;/*MPEG4*/
        public const int NET_DVR_ORIGINALSTREAM = 4;/*Original Stream*/
        public const int NET_DVR_PICTURE = 5;//*Picture*/
        public const int NET_DVR_ENCODER_MJPEG = 6;
        public const int NET_DVR_ECONDER_MPEG2 = 7;
        /* 打包格式 */
        public const int NET_DVR_STREAM_TYPE_UNKOWN = 0;/*未知打包格式*/
        public const int NET_DVR_STREAM_TYPE_HIKPRIVT = 1; /*海康自定义打包格式*/
        public const int NET_DVR_STREAM_TYPE_TS = 7;/* TS打包 */
        public const int NET_DVR_STREAM_TYPE_PS = 8;/* PS打包 */
        public const int NET_DVR_STREAM_TYPE_RTP = 9;/* RTP打包 */

        /*解码设备控制码定义*/
        public const int NET_DEC_STARTDEC = 1;
        public const int NET_DEC_STOPDEC = 2;
        public const int NET_DEC_STOPCYCLE = 3;
        public const int NET_DEC_CONTINUECYCLE = 4;
        public const int MAX_RESOLUTIONNUM = 64; //支持的最大分辨率数目

        public const int MAX_OSD_LEN = 64;  //输出口OSD长度
        /*显示通道状态*/
        public const int NET_DVR_MAX_DISPREGION = 16;         /*每个显示通道最多可以显示的窗口*/

        //低帧率定义
        public const int LOW_DEC_FPS_1_2 = 51;
        public const int LOW_DEC_FPS_1_4 = 52;
        public const int LOW_DEC_FPS_1_8 = 53;
        public const int LOW_DEC_FPS_1_16 = 54;

        public const int PASSIVE_DEC_PAUSE = 1;	/*被动解码暂停(仅文件流有效)*/
        public const int PASSIVE_DEC_RESUME = 2;	/*恢复被动解码(仅文件流有效)*/
        public const int PASSIVE_DEC_FAST = 3;   /*快速被动解码(仅文件流有效)*/
        public const int PASSIVE_DEC_SLOW = 4;   /*慢速被动解码(仅文件流有效)*/
        public const int PASSIVE_DEC_NORMAL = 5;   /*正常被动解码(仅文件流有效)*/
        public const int PASSIVE_DEC_ONEBYONE = 6;  /*被动解码单帧播放(保留)*/
        public const int PASSIVE_DEC_AUDIO_ON = 7;   /*音频开启*/
        public const int PASSIVE_DEC_AUDIO_OFF = 8; 	 /*音频关闭*/
        public const int PASSIVE_DEC_RESETBUFFER = 9;    /*清空缓冲区*/

        public const int MAX_SUBSYSTEM_NUM = 80;   //一个矩阵系统中最多子系统数量
        public const int MAX_SUBSYSTEM_NUM_V40 = 120;   //一个矩阵系统中最多子系统数量
        public const int MAX_SERIALLEN = 36;  //最大序列号长度
        public const int MAX_LOOPPLANNUM = 16;  //最大计划切换组
        public const int DECODE_TIMESEGMENT = 4;     //计划解码每天时间段数

        public const int MAX_DOMAIN_NAME = 64;  /* 最大域名长度 */
        public const int MAX_DISKNUM_V30 = 33; //9000设备最大硬盘数/* 最多33个硬盘(包括16个内置SATA硬盘、1个eSATA硬盘和16个NFS盘) */
        public const int MAX_DAYS = 7;       //每周天数
        public const int MAX_DISPNUM_V41 = 32;
        public const int MAX_WINDOWS_NUM = 12;
        public const int MAX_VOUTNUM = 32;
        public const int MAX_SUPPORT_RES = 32;
        public const int MAX_BIGSCREENNUM = 100;

        public const int VIDEOPLATFORM_ABILITY = 0x210; //视频综合平台能力集
        public const int MATRIXDECODER_ABILITY_V41 = 0x260; //解码器能力集      


        public const int MAX_DECODECHANNUM = 32;//多路解码器最大解码通道数
        public const int MAX_DISPCHANNUM = 24;//多路解码器最大显示通道数

        public const int NET_DVR_DEV_ADDRESS_MAX_LEN = 129;
        public const int NET_DVR_LOGIN_USERNAME_MAX_LEN = 64;
        public const int NET_DVR_LOGIN_PASSWD_MAX_LEN = 64;

        //智能控制信息
        public const int MAX_VCA_CHAN = 16;//最大智能通道数

        public const int MAX_NET_DISK = 16;

        //邦诺CVR
        public const int MAX_ID_COUNT = 256;
        public const int MAX_STREAM_ID_COUNT = 1024;
        public const int STREAM_ID_LEN = 32;
        public const int PLAN_ID_LEN = 32;

        //事件搜索条件 200-04-07 9000_1.1
        public const int SEARCH_EVENT_INFO_LEN = 300;

        public const int MAX_TIMESEGMENT_V30 = 8; //Maximum number of time segments in 9000 DVR's guard schedule
        public const int HOLIDAY_GROUP_NAME_LEN = 32;  //holiday group name len
        public const int MAX_HOLIDAY_PLAN_NUM = 16;  //holiday max plan number
        public const int TEMPLATE_NAME_LEN = 32; //plan template name len 
        public const int MAX_HOLIDAY_GROUP_NUM = 16;   //plan template max group number

        public const int NET_DVR_GET_WEEK_PLAN_CFG = 2100; //get door status week plan config 
        public const int NET_DVR_SET_WEEK_PLAN_CFG = 2101; //set door status week plan config 
        public const int NET_DVR_GET_DOOR_STATUS_HOLIDAY_PLAN = 2102; //get door status holiday week plan config 
        public const int NET_DVR_SET_DOOR_STATUS_HOLIDAY_PLAN = 2103; //set door status holiday week plan config
        public const int NET_DVR_GET_DOOR_STATUS_HOLIDAY_GROUP = 2104; //get door holiday group parameter
        public const int NET_DVR_SET_DOOR_STATUS_HOLIDAY_GROUP = 2105; //set door holiday group parameter
        public const int NET_DVR_GET_DOOR_STATUS_PLAN_TEMPLATE = 2106; //get door status plan template parameter
        public const int NET_DVR_SET_DOOR_STATUS_PLAN_TEMPLATE = 2107; //set door status plan template parameter
        public const int NET_DVR_GET_VERIFY_WEEK_PLAN = 2124; //get reader card verfy week plan
        public const int NET_DVR_SET_VERIFY_WEEK_PLAN = 2125; //set reader card verfy week plan
        public const int NET_DVR_GET_CARD_RIGHT_WEEK_PLAN = 2126;  //get card right week plan 
        public const int NET_DVR_SET_CARD_RIGHT_WEEK_PLAN = 2127; //set card right week plan 
        public const int NET_DVR_GET_VERIFY_HOLIDAY_PLAN = 2128; //get card reader verify holiday plan 
        public const int NET_DVR_SET_VERIFY_HOLIDAY_PLAN = 2129; //set card reader verify holiday plan 
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_PLAN = 2130; //get card right holiday plan 
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_PLAN = 2131; //set card right holiday plan 
        public const int NET_DVR_GET_VERIFY_HOLIDAY_GROUP = 2132; //get card reader verify holiday group 
        public const int NET_DVR_SET_VERIFY_HOLIDAY_GROUP = 2133; //set card reader verify holiday group 
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_GROUP = 2134; //get card right holiday group 
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_GROUP = 2135; //set card right holiday group 
        public const int NET_DVR_GET_VERIFY_PLAN_TEMPLATE = 2136; //get card reader verify plan template 
        public const int NET_DVR_SET_VERIFY_PLAN_TEMPLATE = 2137; //set card reader verify plan template 
        public const int NET_DVR_GET_CARD_RIGHT_PLAN_TEMPLATE = 2138; //get card right plan template
        public const int NET_DVR_SET_CARD_RIGHT_PLAN_TEMPLATE = 2139; //set card right plan template
        // V50
        public const int NET_DVR_GET_CARD_RIGHT_WEEK_PLAN_V50 = 2304;  //Access card right V50 weeks plan parameters
        public const int NET_DVR_SET_CARD_RIGHT_WEEK_PLAN_V50 = 2305;  //Set card right V50 weeks plan parameters 
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_PLAN_V50 = 2310;  //Access card right parameters V50 holiday plan  
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_PLAN_V50 = 2311;  //Set card right parameters V50 holiday plan
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_GROUP_V50 = 2316; //Access card right parameters V50 holiday group
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_GROUP_V50 = 2317; //Set card right parameters V50 holiday group
        public const int NET_DVR_GET_CARD_RIGHT_PLAN_TEMPLATE_V50 = 2322; //Access card right parameters V50 plan template
        public const int NET_DVR_SET_CARD_RIGHT_PLAN_TEMPLATE_V50 = 2323; //Set card right parameters V50 plan template

        public const int INQUEST_START_INFO = 0x1001;      /*讯问开始信息*/
        public const int INQUEST_STOP_INFO = 0x1002;       /*讯问停止信息*/
        public const int INQUEST_TAG_INFO = 0x1003;       /*重点标记信息*/
        public const int INQUEST_SEGMENT_INFO = 0x1004;      /*审讯片断状态信息*/

        /********************************智能交通事件 begin****************************************/
        public const int MAX_REGION_NUM = 8;  // 区域列表最大数目
        public const int MAX_TPS_RULE = 8;   // 最大参数规则数目
        public const int MAX_AID_RULE = 8;   // 最大事件规则数目
        public const int MAX_LANE_NUM = 8;   // 最大车道数目

        public const int MAX_POSITION_NUM = 10;

        /*可用来命名图片的相关元素 */
        public const int PICNAME_ITEM_DEV_NAME = 1;		/*设备名*/
        public const int PICNAME_ITEM_DEV_NO = 2;		/*设备号*/
        public const int PICNAME_ITEM_DEV_IP = 3;		/*设备IP*/
        public const int PICNAME_ITEM_CHAN_NAME = 4;	/*通道名*/
        public const int PICNAME_ITEM_CHAN_NO = 5;		/*通道号*/
        public const int PICNAME_ITEM_TIME = 6;		/*时间*/
        public const int PICNAME_ITEM_CARDNO = 7;		/*卡号*/
        public const int PICNAME_ITEM_PLATE_NO = 8;   /*车牌号码*/
        public const int PICNAME_ITEM_PLATE_COLOR = 9;   /*车牌颜色*/
        public const int PICNAME_ITEM_CAR_CHAN = 10;  /*车道号*/
        public const int PICNAME_ITEM_CAR_SPEED = 11;  /*车辆速度*/
        public const int PICNAME_ITEM_CARCHAN = 12;  /*监测点*/
        public const int PICNAME_ITEM_PIC_NUMBER = 13;  //图片序号
        public const int PICNAME_ITEM_CAR_NUMBER = 14;  //车辆序号

        public const int PICNAME_ITEM_SPEED_LIMIT_VALUES = 15; //限速值
        public const int PICNAME_ITEM_ILLEGAL_CODE = 16; //国标违法代码
        public const int PICNAME_ITEM_CROSS_NUMBER = 17; //路口编号
        public const int PICNAME_ITEM_DIRECTION_NUMBER = 18; //方向编号

        public const int PICNAME_MAXITEM = 15;

        public const int MAX_RECT_NUM = 6;

        public const int MAX_LINE_SEG_NUM = 8;

        public const int MAX_SAMPLE_NUM = 5;

        public const int CALIB_PT_NUM = 4;

        public const int NET_ITC_GET_TRIGGERCFG = 3003; //获取触发参数
        public const int NET_ITC_SET_TRIGGERCFG = 3004; //设置触发参数
        public const int NET_DVR_GET_CURTRIGGERMODE = 3130; //获取设备当前触发模式
        public const int NET_ITC_GET_VIDEO_TRIGGERCFG = 3017;  //获取视频电警触发参数
        public const int NET_ITC_SET_VIDEO_TRIGGERCFG = 3018;  //设置视频电警触发参数

        public const int MAX_ITC_LANE_NUM = 6;
        public const int MAX_IOOUT_NUM = 4;
        public const int MAX_LANEAREA_NUM = 2;
        public const int MAX_IOIN_NUMEX = 10;

        //命名规则：2013-09-27
        public const int PICNAME_ITEM_PARK_DEV_IP = 1;  /*设备IP*/
        public const int PICNAME_ITEM_PARK_PLATE_NO = 2;/*车牌号码*/
        public const int PICNAME_ITEM_PARK_TIME = 3;    /*时间*/
        public const int PICNAME_ITEM_PARK_INDEX = 4;   /*车位编号*/
        public const int PICNAME_ITEM_PARK_STATUS = 5;  /*车位状态*/

        public const int MAX_LED_INFO_LEN = 512;
        public const int MAX_VOICE_INFO_LEN = 128;

        public const int NET_DVR_GET_LEDDISPLAY_CFG = 3673;
        public const int NET_DVR_SET_LEDDISPLAY_CFG = 3672;
        public const int NET_DVR_SET_VOICEBROADCAST_CFG = 3675;

        public const int MAX_ALERTLINE_NUM = 8; //最大警戒线条数	

        /***************************** end *********************************************/
        public const int IPC_PROTOCOL_NUM = 50;  //ipc 协议最大个数

        public const int MAX_INTRUSIONREGION_NUM = 8; //最大区域数数

        public const int MAX_ZEROCHAN_NUM = 16;

        public const int DESC_LEN_64 = 64;

        public const int PROCESSING = 0;    //正在处理
        public const int PROCESS_SUCCESS = 100;   //过程完成
        public const int PROCESS_EXCEPTION = 400;   //过程异常
        public const int PROCESS_FAILED = 500;   //过程失败
        public const int PROCESS_QUICK_SETUP_PD_COUNT = 501; //一键配置至少3块硬盘

        public const int SOFTWARE_VERSION_LEN = 48;

        public const int MAX_SADP_NUM = 256;  //搜索到设备最大数目

        /*******************************备份结构 begin********************************/
        //获取备份设备信息接口定义
        public const int DESC_LEN_32 = 32;   //描述字长度
        public const int MAX_NODE_NUM = 256;  //节点个数

        //备份进度列表
        public const int BACKUP_SUCCESS = 100;  //备份完成
        public const int BACKUP_CHANGE_DEVICE = 101;  //备份设备已满，更换设备继续备份

        public const int BACKUP_SEARCH_DEVICE = 300;  //正在搜索备份设备
        public const int BACKUP_SEARCH_FILE = 301;  //正在搜索录像文件
        public const int BACKUP_SEARCH_LOG_FILE = 302;  //正在搜索日志文件

        public const int BACKUP_EXCEPTION = 400;  //备份异常
        public const int BACKUP_FAIL = 500;  //备份失败

        public const int BACKUP_TIME_SEG_NO_FILE = 501;  //时间段内无录像文件
        public const int BACKUP_NO_RESOURCE = 502;  //申请不到资源
        public const int BACKUP_DEVICE_LOW_SPACE = 503;  //备份设备容量不足
        public const int BACKUP_DISK_FINALIZED = 504;  //刻录光盘封盘
        public const int BACKUP_DISK_EXCEPTION = 505;  //刻录光盘异常
        public const int BACKUP_DEVICE_NOT_EXIST = 506;  //备份设备不存在
        public const int BACKUP_OTHER_BACKUP_WORK = 507;  //有其他备份操作在进行
        public const int BACKUP_USER_NO_RIGHT = 508;  //用户没有操作权限
        public const int BACKUP_OPERATE_FAIL = 509;  //操作失败
        public const int BACKUP_NO_LOG_FILE = 510;  //硬盘中无日志

        public const int MAX_ABILITYTYPE_NUM = 12;   //最大能力项

        public const int MAX_HOLIDAY_NUM = 32;

        public const int MAX_LINK_V30 = 128;

        public const int MAX_BOND_NUM = 2;

        public const int MAX_PIC_EVENT_NUM = 32;
        public const int MAX_ALARMIN_CAPTURE = 16;

        //录像标签
        public const int LABEL_NAME_LEN = 40;
        public const int LABEL_IDENTIFY_LEN = 64;

        public const int MAX_DEL_LABEL_IDENTIFY = 20;// 删除的最大标签标识个数

        public const int CARDNUM_LEN_V30 = 40;
        public const int PICTURE_NAME_LEN = 64;

        public const int MAX_FACE_PIC_NUM = 30;      /*人脸子图个数*/

        public const int MAX_RECORD_PICTURE_NUM = 50;   //最大备份图片张数  

        public const int STEP_READY = 0;    //准备升级
        public const int STEP_RECV_DATA = 1;    //接收升级包数据
        public const int STEP_UPGRADE = 2;    //升级系统
        public const int STEP_BACKUP = 3;    //备份系统
        public const int STEP_SEARCH = 255;  //搜索升级文件

        public const int NET_DVR_V6PSUBSYSTEMARAM_GET = 1501;//获取V6子系统配置
        public const int NET_DVR_V6PSUBSYSTEMARAM_SET = 1502;//设置V6子系统配置

        public const int MAX_REDAREA_NUM = 6;   //最大红绿灯区域个数

        public const int INQUEST_MESSAGE_LEN = 44;    //审讯重点标记信息长度
        public const int INQUEST_MAX_ROOM_NUM = 2;    //最大审讯室个数
        public const int MAX_RESUME_SEGMENT = 2;     //支持同时恢复的片段数目

        public const int MAX_INQUEST_CDRW_NUM = 4;     //最大刻录机数目

        public const int UPLOAD_CERTIFICATE = 1; //上传证书

        public const int MATRIX_PROTOCOL_NUM = 20;    //支持的最大矩阵协议数
        public const int KEYBOARD_PROTOCOL_NUM = 20;    //支持的最大键盘协议数

        public const int MAX_DISPLAY_NUM = 512; //最大显示输出个数

        public const int MAX_FACE_PIC_LEN = 6144;   //最大人脸图片数据长度

        /********************************智能人脸识别 end****************************/
        //分辨率
        public const int NOT_AVALIABLE = 0;
        public const int SVGA_60HZ = 52505660;
        public const int SVGA_75HZ = 52505675;
        public const int XGA_60HZ = 67207228;
        public const int XGA_75HZ = 67207243;
        public const int SXGA_60HZ = 84017212;
        public const int SXGA2_60HZ = 84009020;
        public const int _720P_60HZ = 83978300;
        public const int _720P_50HZ = 83978290;
        public const int _1080I_60HZ = 394402876;
        public const int _1080I_50HZ = 394402866;
        public const int _1080P_60HZ = 125967420;
        public const int _1080P_50HZ = 125967410;
        public const int _1080P_30HZ = 125967390;
        public const int _1080P_25HZ = 125967385;
        public const int _1080P_24HZ = 125967384;
        public const int UXGA_60HZ = 105011260;
        public const int UXGA_30HZ = 105011230;
        public const int WSXGA_60HZ = 110234940;
        public const int WUXGA_60HZ = 125982780;
        public const int WUXGA_30HZ = 125982750;
        public const int WXGA_60HZ = 89227324;
        public const int SXGA_PLUS_60HZ = 91884860;

        public const int MAX_WINDOWS = 16;//最大窗口数
        public const int MAX_WINDOWS_V41 = 36;

        public const int STARTDISPCHAN_VGA = 1;
        public const int STARTDISPCHAN_BNC = 9;
        public const int STARTDISPCHAN_HDMI = 25;
        public const int STARTDISPCHAN_DVI = 29;

        public const int MAX_BIGSCREENNUM_SCENE = 100;

        public const int NET_DVR_GET_ALLWINCFG = 1503; //窗口参数获取

        /*******************************窗口设置*******************************/
        public const int MAX_WIN_COUNT = 224; //支持的最大开窗数

        public const int MAX_LAYOUT_COUNT = 16;     //最大布局数

        public const int MAX_CAM_COUNT = 224;

        /*******************************能力集*******************************/
        public const int SCREEN_PROTOCOL_NUM = 20;   //支持的最大大屏控制器协议数

        /*******************************OSD*******************************/
        public const int MAX_OSDCHAR_NUM = 256;

        /*******************************预案管理*******************************/
        public const int MAX_PLAN_ACTION_NUM = 32;  //预案动作个数
        public const int DAYS_A_WEEK = 7;   //一周7天
        public const int MAX_PLAN_COUNT = 16;   //预案个数

        //安全拔盘状态
        public const int PULL_DISK_SUCCESS = 1;     // 安全拔盘成功
        public const int PULL_DISK_FAIL = 2;        // 安全拔盘失败
        public const int PULL_DISK_PROCESSING = 3;  // 正在停止阵列
        public const int PULL_DISK_NO_ARRAY = 4;    // 阵列不存在 
        public const int PULL_DISK_NOT_SUPPORT = 5; // 不支持安全拔盘

        //扫描阵列状态
        public const int SCAN_RAID_SUC = 1;     // 扫描阵列成功
        public const int SCAN_RAID_FAIL = 2;    // 扫描阵列失败
        public const int SCAN_RAID_PROCESSING = 3;  // 正在扫描阵列
        public const int SCAN_RAID_NOT_SUPPORT = 4; // 不支持阵列扫描

        //设置前端相机类型状态
        public const int SET_CAMERA_TYPE_SUCCESS = 1;  // 成功
        public const int SET_CAMERA_TYPE_FAIL = 2;  // 失败
        public const int SET_CAMERA_TYPE_PROCESSING = 3;   // 正在处理

        public const int SEARCH_EVENT_INFO_LEN_V40 = 800;

        public const int NET_SDK_MAX_TAPE_INDEX_LEN = 32; //磁带编号最大长度
        public const int NET_SDK_MAX_FILE_LEN = 256;      //文件名最大长度

        public const int MAX_PRO_PATH = 256; //最大协议路径长度

        ///抓拍机
        ///
        public const int MAX_OVERLAP_ITEM_NUM = 50;       //最大字符叠加种数
        public const int NET_ITS_GET_OVERLAP_CFG = 5072;//获取字符叠加参数配置（相机或ITS终端）
        public const int NET_ITS_SET_OVERLAP_CFG = 5073;//设置字符叠加参数配置（相机或ITS终端）
        public const int NET_ITS_SET_LAMP_EXTERNAL_CFG = 5095;  //设置外控配置参数

        public const int MAX_RELAY_NUM = 12;
        public const int MAX_IOIN_NUM = 8;
        public const int MAX_VEHICLE_TYPE_NUM = 8;

        public const int NET_DVR_GET_ENTRANCE_PARAMCFG = 3126; //获取出入口控制参数
        public const int NET_DVR_SET_ENTRANCE_PARAMCFG = 3127; //设置出入口控制参数

        public const int CID_CODE_LEN = 4;
        public const int ACCOUNTNUM_LEN = 6;
        public const int ACCOUNTNUM_LEN_32 = 32;

        public const int MAX_FACE_NUM = 2;                       //max face number

        public const int NET_SDK_MONITOR_ID_LEN = 64; //监控点ID长度

        public const int MAX_FILE_PATH_LEN = 256;     //文件路径长度

        //设备区域设置
        public const int REGIONTYPE = 0;//代表区域
        public const int MATRIXTYPE = 11;//矩阵节点
        public const int DEVICETYPE = 2;//代表设备
        public const int CHANNELTYPE = 3;//代表通道
        public const int USERTYPE = 5;//代表用户

        public const int NET_SDK_MAX_FDID_LEN = 256;

        public const int MAX_UPLOADFILE_URL_LEN = 240;

        public const int DISP_CMD_ENLARGE_WINDOW = 1;   /*显示通道放大某个窗口*/
        public const int DISP_CMD_RENEW_WINDOW = 2; /*显示通道窗口还原*/

        public const int MAX_CHINESE_CHAR_NUM = 64;    // 最大汉字类别数量

        //2009-8-18 抓拍机
        public const int PLATE_INFO_LEN = 1024;
        public const int PLATE_NUM_LEN = 16;
        public const int FILE_NAME_LEN = 256;

        public const int NET_DVR_GET_CCDPARAMCFG = 1067;       //IPC获取CCD参数配置
        public const int NET_DVR_SET_CCDPARAMCFG = 1068;      //IPC设置CCD参数配置

        public const int NET_DVR_GET_IMAGEREGION = 1062;       //图像增强仪图像增强去燥区域获取
        public const int NET_DVR_SET_IMAGEREGION = 1063;       //图像增强仪图像增强去燥区域获取
        public const int NET_DVR_GET_IMAGEPARAM = 1064;       // 图像增强仪图像参数(去噪、增强级别，稳定性使能)获取
        public const int NET_DVR_SET_IMAGEPARAM = 1065;       // 图像增强仪图像参数(去噪、增强级别，稳定性使能)设置

        public const int WM_NETERROR = 0x0400 + 102;          //网络异常消息
        public const int WM_STREAMEND = 0x0400 + 103;         //文件播放结束

        public const int FILE_HEAD = 0;      //文件头
        public const int VIDEO_I_FRAME = 1;  //视频I帧
        public const int VIDEO_B_FRAME = 2;  //视频B帧
        public const int VIDEO_P_FRAME = 3;  //视频P帧
        public const int VIDEO_BP_FRAME = 4; //视频BP帧
        public const int VIDEO_BBP_FRAME = 5; //视频B帧B帧P帧
        public const int AUDIO_PACKET = 10;   //音频包

        public const int DATASTREAM_HEAD = 0;       //数据头
        public const int DATASTREAM_BITBLOCK = 1;       //字节数据
        public const int DATASTREAM_KEYFRAME = 2;       //关键帧数据
        public const int DATASTREAM_NORMALFRAME = 3;        //非关键帧数据

        public const int MESSAGEVALUE_DISKFULL = 0x01;
        public const int MESSAGEVALUE_SWITCHDISK = 0x02;
        public const int MESSAGEVALUE_CREATEFILE = 0x03;
        public const int MESSAGEVALUE_DELETEFILE = 0x04;
        public const int MESSAGEVALUE_SWITCHFILE = 0x05;

        public const int NET_DVR_SHOWLOGO = 1;/*显示LOGO*/
        public const int NET_DVR_HIDELOGO = 2;/*隐藏LOGO*/

        public const int MAX_ALARMHOST_VIDEO_CHAN = 64;

        #endregion

        static Lazy<IHikHCNetSdkProxy> _netDevSdk = new Lazy<IHikHCNetSdkProxy>(() => new HikHCNetSdkLoader(), true);
        static Lazy<IHikPlayCtrlSdkProxy> _playCtrlSdk = new Lazy<IHikPlayCtrlSdkProxy>(() => new HikPlayCtrlSdkLoader(), true);
        /// <summary>
        /// plugins内容实例
        /// </summary>
        public static IHikHCNetSdkProxy Instance { get => _netDevSdk.Value; }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IHikHCNetSdkProxy Create(bool isBase = false)
        {
            if (!isBase) { return _netDevSdk.Value; }
            return Environment.Is64BitProcess ? HikHCNetSdkDllerX64.Instance : HikHCNetSdkDllerX86.Instance;
        }
        /// <summary>
        /// 创建PlayM4的SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IHikPlayCtrlSdkProxy CreatePlayM4(bool isBase = false)
        {
            if (!isBase) { return _playCtrlSdk.Value; }
            return Environment.Is64BitProcess ? HikPlayCtrlSdkDllerX64.Instance : HikPlayCtrlSdkDllerX86.Instance;
        }
    }
}
