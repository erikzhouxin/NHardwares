using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.YuShiITSSDK
{
    /// <summary>
    /// 宇视导入SDK
    /// </summary>
    public class NETDEVSDK
    {
        /// <summary>
        /// 真值
        /// </summary>
        public const int TRUE = 1;
        /// <summary>
        /// 假值
        /// </summary>
        public const int FALSE = 0;
        /// <summary>
        /// 最大路径
        /// </summary>
        public const int MAX_PATH = 260;
        /// <summary>
        /// 长度8
        /// </summary>
        public const int NETDEV_LEN_8 = 8;
        /// <summary>
        /// 长度32
        /// </summary>
        public const int NETDEV_LEN_32 = 32;
        /// <summary>
        /// 长度64
        /// </summary>
        public const int NETDEV_LEN_64 = 64;
        /// <summary>
        /// 最大长度68
        /// </summary>
        public const int NETDEV_OSD_TEXT_MAX_LEN = 64 + 4;
        /// <summary>
        /// 最大预置数
        /// </summary>
        public const int NETDEV_MAX_PRESET_NUM = 256;
        /// <summary>
        /// 循环数
        /// </summary>
        public const int NETDEV_MAX_CRUISEROUTE_NUM = 16;
        /// <summary>
        /// 循环点
        /// </summary>
        public const int NETDEV_MAX_CRUISEPOINT_NUM = 32;
        public const int NETDEV_TRAFFIC_PIC_MAX_NUM = 8;
        public const int NETDEV_UNIVIEW_MAX_TIME_LEN = 18;
        public const int NETDEV_DEV_ID_MAX_LEN = 32;
        public const int NETDEV_TOLLGATE_NAME_MAX_LEN = 64;
        public const int NETDEV_PLACE_NAME_MAX_LEN = 256;
        public const int NETDEV_DIRECTION_NAME_MAX_LEN = 64;
        public const int NETDEV_CAR_PLATE_MAX_LEN = 32;
        public const int NETDEV_CAR_VEHICLE_BRAND_LEN = 4;
        public const int NETDEV_PECCANCYTYPE_CODE_MAX_NUM = 16;
        public static IntPtr m_lpDevHandle = IntPtr.Zero;
        public static IntPtr m_oPlayHandleMap = IntPtr.Zero;
        public static IntPtr m_oPicHandleMap = IntPtr.Zero;
        public static Int32 bStreamConnect = NETDEVSDK.FALSE;
        public static Int32 bautoconnect = NETDEVSDK.FALSE;
        public static IntPtr lpRePlayHandle = IntPtr.Zero;
        public static IntPtr lpRePicHandle = IntPtr.Zero;

        /*************************************** OSD相关宏定义 **************************************/
        /*@brief OSD 叠加内容最大行数 */
        public const uint IMOS_MW_INFO_OSD_LINE_MAX = 8;

        /*@brief OSD 颜色 */
        public const uint NETDEV_E_OSD_COLOR_WHITE = 0;              /**< 白 */
        public const uint NETDEV_E_OSD_COLOR_RED = 1;                /**< 红 */
        public const uint NETDEV_E_OSD_COLOR_YELLOW = 2;             /**< 黄 */
        public const uint NETDEV_E_OSD_COLOR_BLUE = 3;               /**< 蓝 */
        public const uint NETDEV_E_OSD_COLOR_BLACK = 4;              /**< 黑 */
        public const uint NETDEV_E_OSD_COLOR_GREEN = 5;              /**< 绿 */
        public const uint NETDEV_E_OSD_COLOR_PURPLE = 6;             /**< 紫 */

        /*@brief OSD 透明度 */
        public const uint NETDEV_E_OSD_ALPHA_NO = 0;                 /**< 不透明 */
        public const uint NETDEV_E_OSD_ALPHA_SEMI = 1;               /**< 半透明 */
        public const uint NETDEV_E_OSD_ALPHA_ALL = 2;                /**< 全透明 */

        /********************************************************************************************/

        public struct NETDEV_PIC_DATA_S
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_TRAFFIC_PIC_MAX_NUM)]
            public IntPtr[] apcData;                                                             /**< 数据指针 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_TRAFFIC_PIC_MAX_NUM)]
            public uint[] aulDataLen;                                                                  /**< 数据长度 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_TRAFFIC_PIC_MAX_NUM)]
            public uint[] aulPicType;                                                                   /**< 照片类型, 参照:IMOS_MW_IMAGE_VEHICLE */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)(NETDEV_TRAFFIC_PIC_MAX_NUM * NETDEV_UNIVIEW_MAX_TIME_LEN))]
            public char[] acPassTime;         /**< 经过时间 */

            public uint ulPicNumber;                                                                  /**< 照片张数 */

            /* 设备信息 */
            public int lApplicationType;                                    /* 应用类型:对应相关产品 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_DEV_ID_MAX_LEN)]
            public char[] szCamID;                        /* 设备编号:采集设备统一编号或卡口相机编码, 不可为空 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_DEV_ID_MAX_LEN)]
            public char[] szTollgateID;                   /* 卡口编号:产生该信息的卡口代码 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_TOLLGATE_NAME_MAX_LEN)]
            public char[] szTollgateName;          /* 卡口名称:可选字段 */

            public uint ulCameraType;                                       /* 相机类型 0 全景 1特性 */
            public uint ulRecordID;                                         /* 车辆信息编号:由1开始自动增长(转换成字符串要求不超过16字节) */

            /* 时间、地点信息 */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_UNIVIEW_MAX_TIME_LEN)]
            public char[] szPassTime;               /* 经过时刻:YYYYMMDDHHMMSS, 时间按24小时制 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_PLACE_NAME_MAX_LEN)]
            public char[] szPlaceName;                /* 地点名称 */

            public int lLaneID;                /* 车道编号:从1开始, 车辆行驶方向最左车道为1，由左向右顺序编号 */
            public int lLaneType;              /* 车道类型:0-机动车道，1-非机动车道 */

            /* 方向编号:1-东向西 2-西向东 3-南向北 4-北向南 
               5-东南向西北 6-西北向东南 7-东北向西南 8-西南向东北 */
            public int lDirection;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_DIRECTION_NAME_MAX_LEN)]
            public char[] szDirectionName;       /* 方向名称:可选字段 */

            /* 车牌信息 */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_CAR_PLATE_MAX_LEN)]
            public char[] szCarPlate;              /* 号牌号码:不能自动识别的用"-"表示 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)4)]
            public uint[] aulLPRRect;                                     /* 车牌坐标:XL=a[0], YL=a[1], XR=a[2], YR=a[3] */

            public int lPlateType;                                         /* 号牌种类:按GA24.7编码 */
            public int lPlateColor;                                        /* 号牌颜色:0-白色1-黄色 2-蓝色 3-黑色 4-其他 */
            public int lPlateNumber;                                       /* 号牌数量 */

            /* 号牌一致: 
               0-车头和车尾号牌号码不一致 
               1-车头和车尾号牌号码完全一致 
               2-车头号牌号码无法自动识别 
               3-车尾号牌号码无法自动识别 
               4-车头和车尾号牌号码均无法自动识别 */
            public int lPlateCoincide;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_CAR_PLATE_MAX_LEN)]
            public char[] szRearVehiclePlateID;   /* 尾部号牌号码:被查控车辆车尾号牌号码，允许车辆尾部号牌号码不全。不能自动识别的用"-"表示 */

            public int lRearPlateColor;                                   /* 尾部号牌颜色: 0-白色1-黄色 2-蓝色 3-黑色 4-其他 */
            public int lRearPlateType;                                    /* 尾部号牌种类: 按GA24.7编码; 或者1－单排 2－武警 3－警用 4－双排 5－其他 */

            /* 车辆信息 */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)4)]
            public uint[] aulVehicleXY;                                 /* 车辆坐标:XL=a[0], YL=a[1], XR=a[2], YR=a[3] */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_CAR_VEHICLE_BRAND_LEN)]
            public byte[] szVehicleBrand;       /* 车辆厂牌编码(自行编码) 考虑到字节对齐定义长度为4，实际使用长度为2 */

            public int lVehicleBody;                                     /* 车辆外型编码(自行编码) */
            public int lVehicleType;                                     /* 车辆类型 0-未知，1-小型车 2-中型车 3-大型车 4-其他 */
            public int lVehicleLength;                                   /* 车外廓长(以厘米为单位) */
            public int lVehicleColorDept;                                /* 车身颜色深浅:0-未知，1-浅，2-深 */

            /* 车身颜色: 
               A：白，B：灰，C：黄，D：粉，E：红，F：紫，G：绿，H：蓝， 
               I：棕，J：黑，K：橙，L：青，M：银，N：银白，Z：其他(!) */
            public byte cVehicleColor;            /* 车身颜色 */

            /* 识别，注:后面的UCHAR紧跟CHAR */
            public byte ucPlateScore;            /* 此次识别中，整牌的置信度，100最大 */
            public byte ucRearPlateScore;        /* 尾部号码置信度，100最大 */
            public byte ucPicType;               /* 0:实时照片，1:历史照片 */
            public int lIdentifyStatus;          /* 识别状态:0－识别成功 1－不成功 2－不完整(!)  3-表示需要平台识别 */
            public int lIdentifyTime;            /* 识别时间, 单位毫秒 */
            public int lDressColor;              /* 行人衣着颜色(!) */
            public int lDealTag;                 /* 处理标记:0-初始状态未校对 1-已校对和保存 2-无效信息 3-已处理和保存(!) */

            /* 车速 */
            public int lVehicleSpeed;            /* 车辆速度: 单位km/h, -1-无测速功能 */
            public int lLimitedSpeed;            /* 执法限速: 车辆限速, 单位km/h */
            public int lMarkedSpeed;             /* 标识限速 */
            public int lDriveStatus;             /* 行驶状态:0-正常 1-嫌疑或按GA408.1编码 */

            /* 红灯信息 */
            public int lRedLightTime;                                   /* 红灯时间 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_UNIVIEW_MAX_TIME_LEN)]
            public char[] szRedLightStartTime;  /* 红灯开始时间:YYYYMMDDHHMMSS, 精确到毫秒, 时间按24小时制 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_UNIVIEW_MAX_TIME_LEN)]
            public char[] szRedLightEndTime;    /* 红灯结束时间:YYYYMMDDHHMMSS, 精确到毫秒, 时间按24小时制 */

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_PECCANCYTYPE_CODE_MAX_NUM + 4)]
            public char[] szDriveStatus;    /* 行驶状态:0-正常 1-嫌疑或按GA408.1编码, 支持字符串，为了兼容不删除lDriveStatus */

            public int lTriggerType;      /*抓拍类型 参考 NETDEV_CAPTURE_TYPE_E */
        }

        /// <summary>
        /// @struct tagNETDEVDeviceInfo
        /// @brief 设备信息 结构体定义 Device information Structure definition
        /// @attention 无 none
        /// </summary>
        public struct NETDEV_DEVICE_INFO_S
        {
            public Int32 dwDevType;                       /* 设备类型,参见枚举#NETDEV_DEVICETYPE_E  Device type, see enumeration #NETDEV_DEVICETYPE_E */
            public Int16 wAlarmInPortNum;                 /* 报警输入个数  Number of alarm inputs */
            public Int16 wAlarmOutPortNum;                /* 报警输出个数  Number of alarm outputs */
            public Int32 dwChannelNum;                    /* 通道个数  Number of Channels */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)48)]
            public byte[] byRes;                          /* 保留字段  Reserved */
        };

        /*************************************** OSD相关结构体 **************************************/

        /// <summary>
        /// @struct tagNETDEVContentInfo
        /// @brief 内容信息 Content
        /// @attention 无 none
        /// </summary>
        public struct NETDEV_CONTENT_INFO_S
        {

            public uint udwContentType;         /* OSD内容类型,参见枚举NETDEV_OSD_CONTENT_TYPE_E OSD content type. For enumeration, see NETDEV_OSD_CONTENT_TYPE_E*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_OSD_TEXT_MAX_LEN)]
            public byte[] szOSDText;            /* OSD文本信息 OSD text*/
        };

        /// <summary>
        /// @struct tagNETDEVOSDContentInfo
        /// @brief 通道OSD内容信息 Channel OSD content
        /// @attention 无 none
        /// </summary>
        public struct NETDEV_OSD_CONTENT_INFO_S
        {
            public uint bEnabled;                                        /* OSD区域使能 Enable OSD area*/
            public uint udwOSDID;                                        /* OSD区域序号，范围[0,7] Area No., ranges from 0 to 7.*/
            public uint udwAreaOSDNum;                                   /* 当前区域内OSD数目 Number of OSD in current area*/
            public uint udwTopLeftX;                                     /* OSD区域横坐标,范围[0,9999] X-axis of OSD area, ranges from 0 to 999*/
            public uint udwTopLeftY;                                     /* OSD区域纵坐标,范围[0,9999] Y-axisof OSD area, ranges from 0 to 999*/
            public uint udwBotRightX;                                    /* old无此参数，OSD区域横坐标,范围[0,9999] X-axis of OSD area, ranges from 0 to 999*/
            public uint udwBotRightY;                                    /* old无此参数，OSD区域纵坐标,范围[0,9999] Y-axisof OSD area, ranges from 0 to 999*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_LEN_8)]
            public NETDEV_CONTENT_INFO_S[] astContentInfo;               /* 当前区域内OSD内容信息 OSD content in current area*/
        };

        /// <summary>
        /// @struct tagNETDEVOsdContent
        /// @brief 通道OSD所有内容 All contents of channel OSD
        /// @attention 无 none
        /// </summary>
        public struct NETDEV_OSD_CONTENT_S
        {
            public uint udwNum;                                  /* OSD区域数量 Number of OSD area*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_LEN_32)]
            public NETDEV_OSD_CONTENT_INFO_S[] astContentList;   /* OSD区域内容信息列表 Content list of OSD area*/
        };

        /// <summary>
        /// @struct tagNETDEVOsdContentStyle
        /// @brief 通道OSD内容样式 Display Style of channel OSD
        /// @attention 无 none
        /// </summary>
        public struct NETDEV_OSD_CONTENT_STYLE_S
        {
            public uint udwFontStyle;                         /* 字体形式，参见枚举NETDEV_OSD_FONT_STYLE_E。  Font style. For enumeration, seeNETDEV_OSD_FONT_STYLE_E*/
            public uint udwFontSize;                          /* 字体大小，参见枚举NETDEV_OSD_FONT_SIZE_E。  Font Size. For enumeration, seeNETDEV_OSD_FONT_SIZE_E*/
            public uint udwColor;                             /* 颜色 Color*/
            public uint udwDateFormat;                        /* 日期格式，参见枚举NETDEV_OSD_DATE_FORMAT_E。  Date Format. For enumeration, seeNETDEV_OSD_DATE_FORMAT_E */
            public uint udwTimeFormat;                        /* 时间格式，参见枚举NETDEV_OSD_TIME_FORMAT_E。  Date Format. For enumeration, seeNETDEV_OSD_DATE_FORMAT_E */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEV_LEN_8)]
            public uint[] audwFontAlignList;                  /* 区域内字体对齐，固定8个区域，IPC支持,参见枚举NETDEV_OSD_ALIGN_E。  Font align in area, 8 areasfixed, IPcamera supported. For enumeration, seeNETDEV_OSD_ALIGN_E */
            public uint udwMargin;                            /* 边缘空的字符数，IPC支持，参见枚举NETDEV_OSD_MIN_MARGIN_E。  Number of character with margin, IP camera supported. For enumeration, seeNETDEV_OSD_MIN_MARGIN_E */
        };

        /********************************************************************************************/

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Init();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_EnableCarplate(int iEnable);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Cleanup();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_Login(String szDevIP, Int16 wDevPort, String szUserName, String szPassword, IntPtr pstDevInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Logout(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr NETDEV_RealPlay(IntPtr lpUserID, ref NETDEV_PREVIEWINFO_S pstPreviewInfo, IntPtr cbPlayDataCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopRealPlay(IntPtr lpRealHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetLastError();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetAlarmCallBack(IntPtr lpUserID, IntPtr cbAlarmMessCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetExceptionCallBack(IntPtr cbExceptionCallBack, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_AlarmMessCallBack_PF(IntPtr lpUserID, Int32 dwChannelID, NETDEV_ALARM_INFO_S stAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void NETDEV_ExceptionCallBack_PF(IntPtr lpUserID, Int32 dwType, IntPtr stAlarmInfo, IntPtr lpExpHandle, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetLogPath(String strLogPath);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_CapturePicture(IntPtr lpRealHandle, String szFileName, Int32 dwCaptureMode);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpOutBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, IntPtr lpInBuffer, ref int dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_DEVICE_BASICINFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PARKSTATUS_INFO_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_CARPORT_CFG_S lpInBuffer, Int32 dwOutBufferSize, ref int pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_NETWORKCFG_S lpInBuffer, Int32 dwInBufferSize);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZControl_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCommand, Int32 dwSpeed);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZPreset_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZPresetCmd, String pszPresetName, Int32 dwPresetID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetDevConfig(IntPtr lpUserID, Int32 dwChannelID, Int32 dwCommand, ref NETDEV_PTZ_ALLPRESETS_S lpOutBuffer, Int32 dwOutBufferSize, ref Int32 pdwBytesReturned);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZGetCruise(IntPtr lpUserID, Int32 dwChannelID, ref NETDEV_CRUISE_LIST_S pstCruiseList);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_PTZCruise_Other(IntPtr lpUserID, Int32 dwChannelID, Int32 dwPTZCruiseCmd, ref NETDEV_CRUISE_INFO_S pstCruiseInfo);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StartPicStream(IntPtr lpUserID, IntPtr hPlayWnd, bool bReTran, string pcReTranIP, NETDEV_PIC_UPLOAD_PF pfnPicDataCBFun, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_StopPicStream(IntPtr lpPlayHandle);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_GetSDKVersion();

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Trigger(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_TriggerSync(IntPtr lpUserID, ref IntPtr ppstPicData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetOutputSwitchStatusCfg(IntPtr lpUserID);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_SetDiscoveryCallBack(NETDEV_DISCOVERY_CALLBACK_PF cbDiscoveryCallBack, IntPtr lpUserData);

        [DllImport("NetDEVSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 NETDEV_Discovery(String pszBeginIP, String pszEndIP);

    }
    /// <summary>
    /// 协议
    /// </summary>
    public enum NETDEV_PROTOCAL_E
    {
        /// <summary>
        /// TCP协议
        /// </summary>
        NETDEV_TRANSPROTOCAL_RTPTCP = 1,         /* TCP */
        /// <summary>
        /// UDP协议
        /// </summary>
        NETDEV_TRANSPROTOCAL_RTPUDP = 2          /* UDP */
    };

    public enum NETDEV_LIVE_STREAM_INDEX_E
    {
        NETDEV_LIVE_STREAM_INDEX_MAIN = 0,
        NETDEV_LIVE_STREAM_INDEX_AUX = 1,
        NETDEV_LIVE_STREAM_INDEX_THIRD = 2,

        NETDEV_LIVE_STREAM_INDEX_INVALID
    };

    public enum NETDEV_ALARM_TYPE_E
    {
        /* 有恢复类型的告警  Recoverable alarms */
        NETDEV_ALARM_MOVE_DETECT = 1,            /* 运动检测告警  Motion detection alarm */
        NETDEV_ALARM_VIDEO_LOST = 2,            /* 视频丢失告警  Video loss alarm */
        NETDEV_ALARM_VIDEO_TAMPER_DETECT = 3,            /* 遮挡侦测告警  Tampering detection alarm */
        NETDEV_ALARM_INPUT_SWITCH = 4,            /* 输入开关量告警  boolean input alarm */
        NETDEV_ALARM_TEMPERATURE_HIGH = 5,            /* 高温告警  High temperature alarm */
        NETDEV_ALARM_TEMPERATURE_LOW = 6,            /* 低温告警  Low temperature alarm */
        NETDEV_ALARM_AUDIO_DETECT = 7,            /* 声音检测告警  Audio detection alarm */
        NETDEV_ALARM_DISK_ABNORMAL = 8,            /* 磁盘异常 Disk abnormal */
        NETDEV_ALARM_DISK_OFFLINE = 9,            /* 磁盘下线 Disk online (兼容以前版本,不维护) */
        NETDEV_ALARM_DISK_ONLINE = 10,           /* 磁盘上线 Disk online */
        NETDEV_ALARM_DISK_STORAGE_WILL_FULL = 11,           /* 磁盘存储空间即将满 Disk StorageGoingfull */
        NETDEV_ALARM_DISK_STORAGE_IS_FULL = 12,           /* 存储空间满 StorageIsfull */
        NETDEV_ALARM_DISK_RAID_DISABLED = 13,           /* 阵列损坏 RAIDDisabled */
        NETDEV_ALARM_DISK_RAID_DEGRADED = 14,           /* 阵列衰退 RAIDDegraded */
        NETDEV_ALARM_DISK_RAID_RECOVERED = 15,           /* 阵列恢复正常 RAIDDegraded */

        /* NVR及接入设备状态上报  Status report of NVR and access device 100~199 */
        NETDEV_ALARM_REPORT_DEV_ONLINE = 100,          /* 设备上线  Device online */
        NETDEV_ALARM_REPORT_DEV_OFFLINE = 101,          /* 设备下线  Device offline */
        NETDEV_ALARM_REPORT_DEV_VIDEO_LOSS = 102,          /* 视频丢失  Video loss */
        NETDEV_ALARM_REPORT_DEV_VIDEO_LOSS_RECOVER = 103,          /* 视频丢失恢复  Video loss recover */
        NETDEV_ALARM_REPORT_DEV_REBOOT = 104,          /* 设备重启  Device restart */
        NETDEV_ALARM_REPORT_DEV_SERVICE_REBOOT = 105,          /* 服务重启  Service restart */
        NETDEV_ALARM_REPORT_DEV_DELETE_CHL = 106,          /* 通道删除  Delete channel */

        /* 实况业务异常上报  Live view exception report 200~299 */
        NETDEV_ALARM_NET_FAILED = 200,          /* 会话网络错误 Network error */
        NETDEV_ALARM_NET_TIMEOUT = 201,          /* 会话网络超时 Network timeout */
        NETDEV_ALARM_SHAKE_FAILED = 202,          /* 会话交互错误 Interaction error */
        NETDEV_ALARM_STREAMNUM_FULL = 203,          /* 流数已经满 Stream full */
        NETDEV_ALARM_STREAM_THIRDSTOP = 204,          /* 第三方停止流 Third party stream stopped */
        NETDEV_ALARM_FILE_END = 205,          /* 文件结束 File ended */

        /* 无布防24小时有效的告警  Valid alarms within 24 hours without arming schedule */
        NETDEV_ALARM_ALLTIME_FLAG_START = 400,          /* 无布防告警开始标记  Start marker of alarm without arming schedule */
        NETDEV_ALARM_STOR_ERR = 401,          /* 存储错误  Storage error */
        NETDEV_ALARM_STOR_DISOBEY_PLAN = 402,          /* 未按计划存储  Not stored as planned */

        /* 无恢复类型的告警  Unrecoverable alarms */
        NETDEV_ALARM_NO_RECOVER_FLAG_START = 500,          /* 无恢复类型告警开始标记  Start marker of unrecoverable alarm */
        NETDEV_ALARM_DISK_ERROR = 501,          /* 磁盘错误  Disk error */
        NETDEV_ALARM_ILLEGAL_ACCESS = 502,          /* 非法访问  Illegal access */
        NETDEV_ALARM_LINE_CROSS = 503,          /* 越界告警  Line cross */
        NETDEV_ALARM_OBJECTS_INSIDE = 504,          /* 区域入侵  Objects inside */
        NETDEV_ALARM_FACE_RECOGNIZE = 505,          /* 人脸识别  Face recognize */
        NETDEV_ALARM_IMAGE_BLURRY = 506,          /* 图像虚焦  Image blurry */
        NETDEV_ALARM_SCENE_CHANGE = 507,          /* 场景变更  Scene change */
        NETDEV_ALARM_SMART_TRACK = 508,          /* 智能跟踪  Smart track */

        NETDEV_ALARM_ALLTIME_FLAG_END = 600,          /* 无布防告警结束标记  End marker of alarm without arming schedule */

        /* 告警恢复  Alarm recover */
        NETDEV_ALARM_RECOVER_BASE = 1000,         /* 告警恢复基数  Alarm recover base */
        NETDEV_ALARM_MOVE_DETECT_RECOVER = 1001,         /* 运动检测告警恢复  Motion detection alarm recover */
        NETDEV_ALARM_VIDEO_LOST_RECOVER = 1002,         /* 视频丢失告警恢复  Video loss alarm recover */
        NETDEV_ALARM_VIDEO_TAMPER_RECOVER = 1003,         /* 遮挡侦测告警恢复  Tampering detection alarm recover */
        NETDEV_ALARM_INPUT_SWITCH_RECOVER = 1004,         /* 输入开关量告警恢复  Boolean input alarm recover */
        NETDEV_ALARM_TEMPERATURE_RECOVER = 1005,         /* 温度告警恢复  Temperature alarm recover */
        NETDEV_ALARM_AUDIO_DETECT_RECOVER = 1007,         /* 声音检测告警恢复  Audio detection alarm recover */
        NETDEV_ALARM_DISK_ABNORMAL_RECOVER = 1008,         /* 磁盘异常恢复 Disk abnormal recover */
        NETDEV_ALARM_DISK_OFFLINE_RECOVER = 1009,         /* 磁盘离线恢复 Disk online recover */
        NETDEV_ALARM_DISK_ONLINE_RECOVER = 1010,         /* 磁盘上线恢复 Disk online recover */
        NETDEV_ALARM_DISK_STORAGE_WILL_FULL_RECOVER = 1011,         /* 磁盘存储空间即将满恢复 Disk StorageGoingfull recover */
        NETDEV_ALARM_DISK_STORAGE_IS_FULL_RECOVER = 1012,         /* 存储空间满恢复 StorageIsfull recover */
        NETDEV_ALARM_DISK_RAID_DISABLED_RECOVER = 1013,         /* 阵列损坏恢复 RAIDDisabled recover */
        NETDEV_ALARM_DISK_RAID_DEGRADED_RECOVER = 1014,         /* 阵列衰退恢复 RAIDDegraded recover */

        NETDEV_ALARM_STOR_ERR_RECOVER = 1201,         /* 存储错误恢复  Storage error recover */
        NETDEV_ALARM_STOR_DISOBEY_PLAN_RECOVER = 1202,         /* 未按计划存储恢复  Not stored as planned recover */

        NETDEV_ALARM_IMAGE_BLURRY_RECOVER = 1506,         /* 图像虚焦告警恢复  Image blurry recover */
        NETDEV_ALARM_SMART_TRACK_RECOVER = 1508,         /* 智能跟踪告警恢复  Smart track recover */

        NETDEV_ALARM_INVALID = 0xFFFF        /* 无效值  Invalid value */
    };

    public enum NETDEV_EXCEPTION_TYPE_E
    {
        /*  200~299 */

        /* 300~399 */
        NETDEV_EXCEPTION_REPORT_VOD_END = 300,
        NETDEV_EXCEPTION_REPORT_VOD_ABEND,
        NETDEV_EXCEPTION_REPORT_BACKUP_END,
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_OUT,
        NETDEV_EXCEPTION_REPORT_BACKUP_DISC_FULL,
        NETDEV_EXCEPTION_REPORT_BACKUP_ABEND,

        NETDEV_EXCEPTION_EXCHANGE = 0x8000,            /* 45S */

        NETDEV_EXCEPTION_REPORT_INVALID = 0xFFFF
    };

    public enum NETDEV_PICTURE_FORMAT_E
    {
        NETDEV_PICTURE_BMP = 0,                  /* bmp */
        NETDEV_PICTURE_JPG = 1,                  /* jpg */

        NETDEV_PICTURE_INVALID
    };

    public enum NETDEV_PTZ_E
    {
        NETDEV_PTZ_FOCUSNEAR = 0x0202,       /* Focus near */
        NETDEV_PTZ_FOCUSFAR = 0x0204,       /* Focus far */
        NETDEV_PTZ_ZOOMTELE = 0x0302,       /*   Zoom in */
        NETDEV_PTZ_ZOOMWIDE = 0x0304,       /*   Zoom out */
        NETDEV_PTZ_TILTUP = 0x0402,         /*   Tilt up */
        NETDEV_PTZ_TILTDOWN = 0x0404,       /*   Tilt down */
        NETDEV_PTZ_PANRIGHT = 0x0502,       /*   Pan right */
        NETDEV_PTZ_PANLEFT = 0x0504,        /*   Pan left */
        NETDEV_PTZ_LEFTUP = 0x0702,         /*   Move up left */
        NETDEV_PTZ_LEFTDOWN = 0x0704,       /*   Move down left */
        NETDEV_PTZ_RIGHTUP = 0x0802,        /*   Move up right */
        NETDEV_PTZ_RIGHTDOWN = 0x0804,      /*   Move down right */

        NETDEV_PTZ_ALLSTOP = 0x0901,        /*   All-stop command word */

        NETDEV_PTZ_TRACKCRUISE = 0x1001,                /*   Start route patrol*/
        NETDEV_PTZ_TRACKCRUISESTOP = 0x1002,            /*   Stop route patrol*/
        NETDEV_PTZ_TRACKCRUISEREC = 0x1003,             /*   Start recording route */
        NETDEV_PTZ_TRACKCRUISERECSTOP = 0x1004,         /*   Stop recording route */
        NETDEV_PTZ_TRACKCRUISEADD = 0x1005,             /*   Add patrol route */
        NETDEV_PTZ_TRACKCRUISEDEL = 0x1006,             /*   Delete patrol route */

        NETDEV_PTZ_AREAZOOMIN = 0x1101,                 /*   Zoom in area */
        NETDEV_PTZ_AREAZOOMOUT = 0x1102,                /*   Zoom out area */
        NETDEV_PTZ_AREAZOOM3D = 0x1103,                 /* 3D  3D positioning */

        NETDEV_PTZ_BRUSHON = 0x0A01,                    /*   Wiper on */
        NETDEV_PTZ_BRUSHOFF = 0x0A02,                   /*   Wiper off */

        NETDEV_PTZ_LIGHTON = 0x0B01,                    /*   Lamp on */
        NETDEV_PTZ_LIGHTOFF = 0x0B02,                   /*   Lamp off */

        NETDEV_PTZ_HEATON = 0x0C01,                     /*   Heater on */
        NETDEV_PTZ_HEATOFF = 0x0C02,                    /*   Heater off */

        NETDEV_PTZ_SNOWREMOINGON = 0x0D01,              /*   Snowremoval on */
        NETDEV_PTZ_SNOWREMOINGOFF = 0x0D02,             /*   Snowremoval off  */

        NETDEV_PTZ_BUTT
    };

    public enum NETDEV_PTZ_PRESETCMD_E
    {
        NETDEV_PTZ_SET_PRESET = 0,            /*   Set preset */
        NETDEV_PTZ_CLE_PRESET = 1,            /*   Clear preset */
        NETDEV_PTZ_GOTO_PRESET = 2             /*   Go to preset */
    };

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

        NETDEV_GET_CARPORTCFG = 1010,              /* 获取车位信息 参见#NETDEV_CARPORT_CFG_S */

        NETDEV_GET_OSDSTYLECFG = 1020,              /* 获取叠加OSD样式配置 参见 NETDEV_OSDSTYLE_CFG_S */
        NETDEV_SET_OSDSTYLECFG = 1021,              /* 设置叠加OSD样式配置 参见 NETDEV_OSDSTYLE_CFG_S */

        NETDEV_GET_INFOOSDCFG = 1030,              /* 获取叠加OSD配置 参见 NETDEV_INFOOSD_CFG_S */
        NETDEV_SET_INFOOSDCFG = 1031,              /* 设置叠加OSD配置 参见 NETDEV_INFOOSD_CFG_S */

        NETDEV_CFG_INVALID = 0xFFFF            /*   Invalid value */
    };

    public enum NETDEV_PTZ_CRUISECMD_E
    {
        NETDEV_PTZ_ADD_CRUISE = 0,         /*    Add patrol route */
        NETDEV_PTZ_MODIFY_CRUISE = 1,         /*   Edit patrol route */
        NETDEV_PTZ_DEL_CRUISE = 2,         /*   Delete patrol route */
        NETDEV_PTZ_RUN_CRUISE = 3,         /*   Start patrol */
        NETDEV_PTZ_STOP_CRUISE = 4          /*   Stop patrol */
    };

    public enum NETDEV_CAPTURE_TYPE_E
    {
        NETDEV_AUTO_TRG_MODE = 0,            /* 自动抓拍 */
        NETDEV_MANUAL_TRG_MODE = 1,          /* 平台下发手动抓拍1张 */
        NETDEV_LINKAGE_TRG_MODE = 2,         /* 平台下发联动抓拍 */
        NETDEV_MANUAL_TRG_TWO_MODE = 3,      /* 平台下发手动抓拍2张 */
        NETDEV_ASYREPORT_TRG_MODE = 4,       /* 卡口设备提前上报记录 */
    };

    public enum NETDEV_OSD_CONTENT_TYPE_E
    {
        NETDEV_OSD_CONTENT_TYPE_NOTUSE = 0,                    /* 不使用 Not used*/
        NETDEV_OSD_CONTENT_TYPE_CUSTOM = 1,                    /* 自定义 Custom*/
        NETDEV_OSD_CONTENT_TYPE_DATE_AND_TIME = 2,                    /* 时间日期 Time and date*/
        NETDEV_OSD_CONTENT_TYPE_PTZ_CONTROLLER = 3,                    /* 云台控制者 PTZ controller*/
        NETDEV_OSD_CONTENT_TYPE_PTZ_COORDINATES = 4,                    /* 云台坐标 PTZ Coordinates*/
        NETDEV_OSD_CONTENT_TYPE_CRUISE = 5,                    /* 巡航信息 Patrol*/
        NETDEV_OSD_CONTENT_TYPE_ZOOM = 6,                    /* 变倍信息 Zoom*/
        NETDEV_OSD_CONTENT_TYPE_PRESET = 7,                    /* 预置位信息  Preset*/
        NETDEV_OSD_CONTENT_TYPE_ALARM_INFO = 8,                    /* 报警信息 Alarm */
        NETDEV_OSD_CONTENT_TYPE_ENCODE = 9,                    /* 编码信息 Encoding*/
        NETDEV_OSD_CONTENT_TYPE_SERIAL_PORT = 10,                   /* 串口OSD Serial Port OSD*/
        NETDEV_OSD_CONTENT_TYPE_PTZ_ORIENTATION = 11,                   /* 云台方位信息 PZT direction*/
        NETDEV_OSD_CONTENT_TYPE_CHN_NAME = 12,                   /* 通道名称 Channel name*/
        NETDEV_OSD_CONTENT_TYPE_DEBUG = 13,                   /* 调试OSD  Debug OSD*/
        NETDEV_OSD_CONTENT_TYPE_PEOPLE_COUNTING = 14,                   /* 人数统计OSD People counting OSD*/
        NETDEV_OSD_CONTENT_TYPE_NETWORK_PORT = 15,                   /* 网口OSD Network Port OSD*/
        NETDEV_OSD_CONTENT_TYPE_TIME = 16,                   /* 时间 Time*/
        NETDEV_OSD_CONTENT_TYPE_DATE = 17,                   /* 日期 Date*/
        NETDEV_OSD_CONTENT_TYPE_SMART_CONTENT = 18,                   /* 超感类OSD Sensing OSD*/
        NETDEV_OSD_CONTENT_TYPE_BATTERY = 19,                   /* 电池OSD Battery OSD*/
        NETDEV_OSD_CONTENT_TYPE_SCROLL_OSD = 20,                   /* 滚动字幕OSD Scroll text OSD*/
        NETDEV_OSD_CONTENT_TYPE_PICTURE_OVERLAY = 21,                   /* LOGO OSD */
        NETDEV_OSD_CONTENT_TYPE_MOTOR_VEHICLE_NUM = 22,                   /* 天网卡口机动车流量 Vehicle flow of LPR*/
        NETDEV_OSD_CONTENT_TYPE_NON_MOTOR_VEHICLE_NUM = 23,                   /* 天网卡口非机动车流量 Non-vehicle flow of LPR*/
        NETDEV_OSD_CONTENT_TYPE_PEOPLE_NUM = 24,                   /* 天网卡口行人流量 Pedestrian flow of LPR*/
        NETDEV_OSD_CONTENT_TYPE_INFOOSD_NUM = 25                    /* INFOOSD类型数目 Number of INFOOSDtype*/
    }

    /// <summary>
    /// @enum tagNETDEVOSDFontStyle
    /// @brief OSD字体形式枚举 Enumeration of OSD font style
    /// @attention 无 None
    /// </summary>
    public enum NETDEV_OSD_FONT_STYLE_E
    {
        NETDEV_OSD_FONT_STYLE_BACKGROUND = 0,              /* 背景 Background*/
        NETDEV_OSD_FONT_STYLE_STROKE = 1,                  /* 描边 Stroke*/
        NETDEV_OSD_FONT_STYLE_HOLLOW = 2,                  /* 空心 Hollow*/
        NETDEV_OSD_FONT_STYLE_NORMAL = 3                   /* 正常 Normal*/
    }

    /// <summary>
    /// @enum tagNETDEVOSDFontSize
    /// @brief OSD字体大小枚举 Enumeration of OSD font size
    /// @attention 无 None
    /// </summary>
    public enum NETDEV_OSD_FONT_SIZE_E
    {
        NETDEV_OSD_FONT_SIZE_LARGE = 0,                  /* 特大 X-large*/
        NETDEV_OSD_FONT_SIZE_BIG = 1,                    /* 大 Large*/
        NETDEV_OSD_FONT_SIZE_MEDIUM = 2,                 /* 中 Medium*/
        NETDEV_OSD_FONT_SIZE_SMALL = 3                   /* 小 Small*/
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_INFO_S
    {
        public Int32 dwDevType;
        public Int16 wAlarmInPortNum;                   /* Number of alarm inputs */
        public Int16 wAlarmOutPortNum;                  /* Number of alarm outputs */
        public Int32 dwChannelNum;                      /* Number of Channels */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NETWORKCFG_S
    {
        public Int32 dwMTU;                                         /* MTU value */
        public Int32 dwIPv4DHCP;                                    /* DHCP of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public char[] szIpv4Address;                                /* IP address of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public char[] szIPv4GateWay;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public char[] szIPv4SubnetMask;                          /*  Gateway of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 480)]
        public byte[] byRes;                                        /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISCOVERY_DEVINFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevAddr;                 /* 设备地址  Device address */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevModule;                 /* 设备地址  Device address */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevSerailNum;                 /* 设备地址  Device address */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevMac;                 /* 设备地址  Device address */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevName;                 /* 设备地址  Device address */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevVersion;                 /* 设备地址  Device address */
        int enDevType;                                /* 设备类型  Device type */
        int dwDevPort;                                                /* 设备端口号  Device port number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NETDEVSDK.NETDEV_LEN_64)]
        public char[] szManuFacturer;                       /* 生产商 Device manufacture */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)196)]
        public byte[] byRes;                 /* 设备地址  Device address */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARKSTATUS_INFO_S
    {
        public Int32 ulParkNum;       /**< 车位数量 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public NETDEV_PARK_STATUS_S[] astParkSatus;       /**< 车位状态信息 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PARK_STATUS_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_DEV_ID_MAX_LEN)]
        public char[] szCamID;               /**< 相机编号 */

        public Int32 lParkID;                                           /**< 车位编号 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_UNIVIEW_MAX_TIME_LEN)]
        public char[] szSampleTime;               /**< 采样时刻:YYYYMMDDHHMMSS, 时间按24小时制 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] cReserved;               /**< 保留字段 字节对齐用 */

        public Int32 lParkingLotStatus;                                 /**< 车位状态，0无车，1有车，2识别异常 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CAR_PLATE_MAX_LEN)]
        public char[] szCarPlate;               /**< 车牌号码:不能自动识别的用"-"表示，车位无车时忽略该字段 */

        public Int32 lLEDStatus;                                        /**< 车位指示灯状态 0熄灭，1长亮，2快速闪烁，3慢速闪烁 */
        public Int32 lLEDColor;                                         /**< 车位指示灯颜色 1红色，2绿色，3黄色 */
        public Int32 lCrossAlarm;                                       /**< 跨车位告警 0未跨车位，1跨车位 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CARPORT_CFG_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public char[] szArea;       /**< 车位所属区号 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public NETDEV_IVA_PARK_AREA_INFO_S[] astParkAreaInfo;       /**< 车位所属区号 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IVA_PARK_AREA_INFO_S
    {
        public Int32 ulParkDetstaus;                             /**< 检测使能标志, 0表示不使能,1表示使能,2表示无效 */
        public Int32 ulParkAreaID;                              /**< 车位号 */
        public NETDEV_POLYGON_S stParkAreaLocation;            /**< 车位区域坐标,多边形，最多支持6个点 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_POLYGON_S
    {
        public Int32 ulNum;   /**< 有效点数 */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public NETDEV_AREA_SCOPE_S[] astPoint;       /* 多边形端点坐标 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_AREA_SCOPE_S
    {
        public Int32 ulX;        /**< 横坐标 */
        public Int32 ulY;        /**< 纵坐标 */
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PREVIEWINFO_S
    {
        public Int32 dwChannelID;
        public Int32 dwStreamType;
        public Int32 dwLinkMode;
        public IntPtr hPlayWnd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 264)]
        public byte[] szReserve;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_S
    {
        public Int32 dwAlarmType;
        public Int64 tAlarmTime;
        public Int32 dwChannelID;
        public Int16 wIndex;
        String pszName;                       /* Alarm source name, alarm input/output name */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public byte[] szReserve;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_ALLPRESETS_S
    {
        public Int32 dwSize;                             /*   Total number of presets */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_PRESET_NUM)]
        public NETDEV_PTZ_PRESET_S[] astPreset;   /*   Structure of preset information */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PTZ_PRESET_S
    {
        public Int32 dwPresetID;                                 /* ID  Preset ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szPresetName;                /*   Preset name */
    };

    public struct NETDEV_DEVICE_BASICINFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDevModel;                     /*   Device model */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public char[] szSerialNum;                    /*   Hardware serial number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public char[] szFirmwareVersion;              /*   Software version */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public char[] szMacAddress;                   /* IPv4Mac  MAC address of IPv4 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public char[] szDeviceName;                   /* Device name */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
        public byte[] byRes;                                    /*   Reserved */

    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_LIST_S
    {
        public Int32 dwSize;                                         /*   Number of patrol routes */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_CRUISEROUTE_NUM)]
        public NETDEV_CRUISE_INFO_S[] astCruiseInfo;      /*   Information of patrol routes */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_INFO_S
    {
        public Int32 dwCuriseID;                                     /* ID  Route ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public char[] szCuriseName;                    /*   Route name */
        public Int32 dwSize;                                         /*   Number of presets included in the route */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_MAX_CRUISEPOINT_NUM)]
        public NETDEV_CRUISE_POINT_S[] astCruisePoint;     /*    Information of presets included in the route */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_POINT_S
    {
        public Int32 dwPresetID;                     /* ID  Preset ID */
        public Int32 dwStayTime;                     /*   Stay time */
        public Int32 dwSpeed;                        /*   Speed */
        public Int32 dwReserve;                      /*   Reserved */
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct VEHICLE_INFO
    {
        public Int32 m_lIndex;
        public String m_strCaptureTime;
        public Int32 m_lLaneID;
        public Int32 m_lPlateColor;
        public String m_strCarPlate;
    };

    public struct StuDevInfo
    {
        public string strDevIP;
        public string strDevAdmin;
        public string strDevPassWord;
        public IntPtr lpDevHandle;
        public IntPtr lpPicHandle;
        public uint ulUserId;
        public int bLogin;
        public int bStartStream;
        public IntPtr lpStreamHandle;  /* 用于存储起照片流时传入的用户数据的地址，通过它在照片回调函数中辨别数据属于哪台设备 */
        public uint ulPicCount;
    };

    public delegate void NETDEV_PIC_UPLOAD_PF(IntPtr pstPicData, uint lpUserParam);
    public delegate void NETDEV_DISCOVERY_CALLBACK_PF(IntPtr pstDevInfo, IntPtr lpUserData);
    public delegate uint LoginThread_PF();

}
