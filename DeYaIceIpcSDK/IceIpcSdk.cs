using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// osd叠加信息结构体
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_OSDAttr_S
    {
        //video
        /// <summary>
        /// 叠加位置(0左上，1右上，2左下，3右下，4上居中，5下居中)
        /// </summary>
        public uint u32OSDLocationVideo;
        /// <summary>
        /// 颜色(十六进制RGB颜色值，格式为0x00bbggrr)
        /// </summary>
        public uint u32ColorVideo;
        /// <summary>
        /// 是否叠加日期时间(0不叠加 1叠加)
        /// </summary>
        public uint u32DateVideo;
        /// <summary>
        /// 是否叠加授权信息(0不叠加 1叠加)
        /// </summary>
        public uint u32License;
        /// <summary>
        /// 是否叠加自定义信息(0不叠加 1叠加)
        /// </summary>
        public uint u32CustomVideo;
        /// <summary>
        /// 自定义信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szCustomVideo;

        //jpeg
        /// <summary>
        /// 叠加位置(0左上，1右上，2左下，3右下，4上居中，5下居中)
        /// </summary>
        public uint u32OSDLocationJpeg;
        /// <summary>
        /// 颜色(十六进制RGB颜色值，格式为0x00bbggrr)
        /// </summary>
        public uint u32ColorJpeg;
        /// <summary>
        /// 是否叠加日期时间(0不叠加 1叠加)
        /// </summary>
        public uint u32DateJpeg;
        /// <summary>
        /// 是否叠加算法信息(0不叠加 1叠加)
        /// </summary>
        public uint u32Algo;
        /// <summary>
        /// 是否叠加设备ID(预留，暂未使用)
        /// </summary>
        public uint u32DeviceID;
        /// <summary>
        /// 设备ID(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szDeviceID;
        /// <summary>
        /// 是否叠加设备名称(预留，暂未使用)	
        /// </summary>
        public uint u32DeviceName;
        /// <summary>
        /// 设备名称(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szDeviceName;
        /// <summary>
        /// 是否叠加地点信息(预留，暂未使用)
        /// </summary>
        public uint u32CamreaLocation;
        /// <summary>
        /// 地点信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szCamreaLocation;
        /// <summary>
        /// 是否叠加子地点信息(预留，暂未使用)
        /// </summary>
        public uint u32SubLocation;
        /// <summary>
        /// 子地点信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szSubLocation;
        /// <summary>
        /// 是否叠加相机方向(预留，暂未使用)
        /// </summary>
        public uint u32ShowDirection;
        /// <summary>
        /// 相机方向(预留，暂未使用)
        /// </summary>
        public uint u32CameraDirection;
        /// <summary>
        /// 是否叠加自定义信息(1叠加 0不叠加)	
        /// </summary>
        public uint u32CustomJpeg;

        /// <summary>
        /// 图片信息显示模式（0，多行显示，1，单行显示,默认0）
        /// </summary>
        public uint u32ItemDisplayMode;
        /// <summary>
        /// 日期显示模式（0，xxxx/xx/xx   1，xxxx年xx月xx日，默认0）
        /// </summary>
        public uint u32DateMode;
        /// <summary>
        /// OSD 背景色（0背景全透明，1，背景黑色，默认0）
        /// </summary>
        public uint u32BgColor;
        /// <summary>
        /// 字体大小（0:小，1:中 2:大,默认为中，在540P 以下，中和大会转换为小）
        /// </summary>
        public uint u32FontSize;
        /// <summary>
        /// 自定义信息(预留，暂未使用)
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string szCustomJpeg;
        /// <summary>
        /// 视频自定义信息，每行最多64字节（包含换行符），最多6行，数组长度为64*6
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 384)]
        public string szCustomVideo6;
        /// <summary>
        /// 抓拍图自定义信息，每行最多64字节（包含换行符），最多6行，数组长度为64*6
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 384)]
        public string szCustomJpeg6;
    }
#pragma warning disable CS1570 // XML 注释出现 XML 格式错误
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ICE_RECT_S
    {
        /// <summary>
        /// !< letf x
        /// </summary>
        public short s16Left;
        /// <summary>
        /// !< top y
        /// </summary>
        public short s16Top;
        /// <summary>
        /// !< right x
        /// </summary>
        public short s16Right;
        /// <summary>
        /// !< bottom y
        /// </summary>
        public short s16Bottom;
    }
#pragma warning restore CS1570 // XML 注释出现 XML 格式错误
    /// <summary>
    /// 车牌识别输出结构
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_VLPR_OUTPUT_S
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string as8PlateNum;              //!<  车牌号
        public ICE_RECT_S stPlateRect;          //!<  车牌矩形框；

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.Struct)]
        public ICE_RECT_S[] astPlateCharRect;   //!<  车牌字符矩形框

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.R4)]
        public float[] aflPlateCharConfid;      //!<  车牌字符置信度

        public float flConfidence;              //!<  车牌置信度
        public int s32PlateIntensity;           //!<  车牌亮度
        public int ePlateColor;                 //!<  车牌颜色
        public int ePlateType;                  //!<  车牌类型
        public int eVehicleColor;               //!<  车身颜色
        public float flPlateAngleH;             //!<  车牌水平倾斜角度
        public float flPlateAngleV;             //!<  车牌竖直倾斜角度
        public byte u8PlateColorRate;           //!<  颜色匹配程度
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 19)]
        public string astReserve;               //!<  预留参数
        public uint u32FrameId;                 //!<  时间戳ID
    }

    /// <summary>
    /// 车辆特征码结构体
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_VBR_RESULT_S
    {
        /// ICE_S8[20]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string szLogName;        //主品牌

        /// ICE_S8[88]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 88)]
        public string reserve;     //预留

        /// ICE_FLOAT[20]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.R4)]
        public float[] fResFeature;     //特征码，数组长度为20

        /// ICE_U32[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] iReserved;        //预留
    }

    /// <summary>
    /// 车牌识别数据结构体，由于只使用车辆特征码结构体指针，其余内容都用数组代替
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_VDC_PICTRUE_INFO_S
    {
#if VERSION32
        /// <summary>
        /// 预留（考虑到64位指针长度比32位时指针长度大4，所以32位的预留数组长度比64位大4）
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string cFileName;           
#else
        /// <summary>
        /// 预留（考虑到64位指针长度比32位时指针长度大4，所以32位的预留数组长度比64位大4）
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string cFileName;
#endif

        /// <summary>
        /// ICE_VBR_RESULT_S* 车辆特征码结构体指针
        /// </summary>
        public IntPtr pstVbrResult;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 232)]
        public string data;
        /// <summary>
        /// 车牌信息
        /// </summary>
        public ICE_VLPR_OUTPUT_S stPlateInfo;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string data2;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_CameraInfo
    {

        /// char[128]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szAppVersion;//相机app版本

        /// char[256]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szAlgoVersion;//相机算法版本

        /// int
        public int szIsEnc;//相机是否加密

        /// char[16]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string szAppTime;//版本时间

        /// char[1024]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string szReserved;//预留
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ice_uart
    {
        /// <summary>
        /// 
        /// </summary>
        public int uartEn;
        /// <summary>
        /// 
        /// </summary>
        public int uartWorkMode;
        /// <summary>
        /// 
        /// </summary>
        public int baudRate;
        /// <summary>
        /// 
        /// </summary>
        public int dataBits;
        /// <summary>
        /// 
        /// </summary>
        public int parity;
        /// <summary>
        /// 
        /// </summary>
        public int stopBits;
        /// <summary>
        /// 
        /// </summary>
        public int flowControl;
        /// <summary>
        /// 
        /// </summary>
        public int LEDControlCardType;
        /// <summary>
        /// 
        /// </summary>
        public int LEDBusinessType;
        /// <summary>
        /// 
        /// </summary>
        public int u32UartProcOneReSendCnt;
        /// <summary>
        /// 
        /// </summary>
        public byte screen_mode;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string as32Reserved;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ICE_UART_PARAM
    {
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
        public ice_uart[] uart_param;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I4)]
        public int[] as32Reserved;
    }
    /// <summary>
    /// 
    /// </summary>
    public enum E_LedScreenType
    {

        /// LED_SCREEN_1 -> 0
        LED_SCREEN_1 = 0,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_2,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_3,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_4,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_5,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_6,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_7,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_8,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_9,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_10,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_11,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_12,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_13,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_14,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_15,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_16,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_17,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_18,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_19,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_20,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_21,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_22,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_23,
        /// <summary>
        /// 
        /// </summary>
        LED_SCREEN_MAX,
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct T_SubLedSetup
    {

        /// ICE_U8->unsigned char
        public byte ucContentEnable;

        /// ICE_U8->unsigned char
        public byte ucTimeEnable;

        /// ICE_U8->unsigned char
        public byte ucInterval;

        /// ICE_U8[64]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string aucContent;

        /// ICE_U8->unsigned char
        public byte ucColor;

        /// ICE_U8->unsigned char
        public byte ucLeftVehEnable;

        /// ICE_U8[9]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string aucReserved;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct T_M_SubLedSetup
    {

        /// ICE_U8->unsigned char
        public byte ucContentEnable;

        /// ICE_U8->unsigned char
        public byte ucVehTypeEnable;

        /// ICE_U8->unsigned char
        public byte ucPlateEnable;

        /// ICE_U8->unsigned char
        public byte ucLeftDaysEnable;

        /// ICE_U8->unsigned char
        public byte ucParkPay;

        /// ICE_U8->unsigned char
        public byte ucParkLastTime;

        /// ICE_U8->unsigned char
        public byte ucTmpCardColor;

        /// ICE_U8->unsigned char
        public byte ucMonthCardColor;

        /// ICE_U8[64]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string aucContent;

        /// ICE_U8[10]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string aucReserved;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct T_M_AudioLedSetup
    {

        /// ICE_U8->unsigned char
        public byte ucContentEnable;

        /// ICE_U8->unsigned char
        public byte ucVehTypeEnable;

        /// ICE_U8->unsigned char
        public byte ucPlateEnable;

        /// ICE_U8->unsigned char
        public byte ucLeftDaysEnable;

        /// ICE_U8->unsigned char
        public byte ucParkPay;

        /// ICE_U8->unsigned char
        public byte ucParkLastTime;

        /// ICE_U8->unsigned char
        public byte ucWelorByeEnable;

        /// ICE_U8[64]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string aucWelorByeContent;

        /// ICE_U8[64]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string aucSelfContent;

        /// ICE_U8[10]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string aucReserved;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ICE_OFFLINE_LED_CONFIG
    {

        /// E_LedScreenType->Anonymous_7fc14953_d8c0_4049_9fe6_366a6d28c45c
        public E_LedScreenType sreenType;

        /// ICE_U32->unsigned int
        public uint screenMode;

        /// ICE_U32->unsigned int
        public uint cameraType;

        /// ICE_U8->unsigned char
        public byte ucAudioEnable;

        /// ICE_U8[3]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string ucReserved;

        /// T_SubLedSetup[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_SubLedSetup[] atSubLedInIdle;

        /// T_M_SubLedSetup[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_M_SubLedSetup[] atSubLedInBusy;

        /// T_M_AudioLedSetup->Anonymous_3559f5f9_650c_4a60_a408_da1c05ccff7e
        public T_M_AudioLedSetup atSubLedInBusyAudio;

        /// T_SubLedSetup[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_SubLedSetup[] atSubLedOutIdle;

        /// T_M_SubLedSetup[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public T_M_SubLedSetup[] atSubLedOutBusy;

        /// T_M_AudioLedSetup->Anonymous_3559f5f9_650c_4a60_a408_da1c05ccff7e
        public T_M_AudioLedSetup atSubLedOutBusyAudio;

        public uint uc485ctrlEnable;

        public uint ucLeftVehPlace;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 92)]
        public string aucReserved;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct T_OsdInfoCfg
    {
        public int iEnable;
        public int iLocation;
        public int iType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.U1)]
        public byte[] acCustomInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string acResrv;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct T_SnapOsdCfg
    {
        public int ibgColorMode;
        public int iDateMode;
        public int iFontSize;
        public int iLineMode;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
        public T_OsdInfoCfg[] tOsdInfoCfg;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string acResrv;
    }
    #region // 公共委托
    /**
     * @brief  车牌类型枚举值
     * typedef enum 
        {
            ICE_PLATE_UNCERTAIN	    = 0,	        不确定的
            ICE_PLATE_BLUE	        = 1,	        蓝牌车
            ICE_PLATE_YELLOW	    = 2,	        单层黄牌车
            ICE_PLATE_POL	        = 4,	        警车
            ICE_PLATE_WUJING	    = 8,	        武警车辆
            ICE_PLATE_DBYELLOW	    = 16,	        双层黄牌
            ICE_PLATE_MOTOR	        = 32,	        摩托车
            ICE_PLATE_INSTRUCTIONCAR= 64,	        教练车
            ICE_PLATE_MILITARY	    = 128,	        军车
            ICE_PLATE_PERSONAL	    = 256,	        个性化车
            ICE_PLATE_GANGAO	    = 512,	        港澳车
            ICE_PLATE_EMBASSY	    = 1024,	        使馆车
            ICE_PLATE_NONGLARE	    = 2048,	        老式车牌(不反光)

            ICE_PLATE_WHITE_TWOTWO	= 0x10000001,	2+2模型；
            ICE_PLATE_WHITE_TWOTHR	= 0x10000002,	2+3模型；
            ICE_PLATE_WHITE_THRTWO	= 0x10000004,	3+2模型；
            ICE_PLATE_WHITE_THRTHR	= 0x10000008,	 3+3模型；
            ICE_PLATE_WHITE_THRFOR	= 0x10000010,	3+4模型；

            ICE_PLATE_BLACK_THRTWO	= 0x10000020,	3+2模型；
            ICE_PLATE_BLACK_TWOTHR	= 0x10000040,	2+3模型；
            ICE_PLATE_BLACK_THRTHR	= 0x10000080,	3+3模型；
            ICE_PLATE_BLACK_TWOFOR	= 0x10000100,	2+4模型；
            ICE_PLATE_BLACK_FORTWO	= 0x10000200,	4+2模型；
            ICE_PLATE_BLACK_THRFOR	= 0x10000400,	3+4模型；
        }ICE_PLATETYPE_E;
     */
    /*
     * @brief   报警类型枚举值
        typedef enum{
            ICE_VDC_HD_TRIGER,						//实时_硬触发+临时车辆(0),
            ICE_VDC_VIDEO_TRIGER, 					//实时_视频触发+临时车辆（1），
            ICE_VDC_SOFT_TRIGER,					//实时_软触发+临时车辆（2），
            ICE_VDC_HD_TRIGER_AND_WHITELIST,		//实时_硬触发+有效白名单(3),
            ICE_VDC_VIDEO_TRIGER_AND_WHITELIST,		//实时_视频触发+有效白名单（4），
            ICE_VDC_SOFT_TRIGER_AND_WHITELIST,  	//实时_软触发+有效白名单（5），
            ICE_VDC_HD_TRIGER_AND_BLACKLIST,		//实时_硬触发+黑名单(6),
            ICE_VDC_VIDEO_TRIGER_AND_BLACKLIST,		//实时_视频触发+黑名单（7），
            ICE_VDC_SOFT_TRIGER_AND_BLACKLIST,  	//实时_软触发+黑名单（8），

            ICE_VDC_NC_HD_TRIGER,					//脱机_硬触发+临时车辆(9),
            ICE_VDC_NC_VIDEO_TRIGER, 				//脱机_视频触发+临时车辆（10），
            ICE_VDC_NC_SOFT_TRIGER,					//脱机_软触发+临时车辆（11），
            ICE_VDC_NC_HD_TRIGER_AND_WHITELIST,		//脱机_硬触发+有效白名单(12),
            ICE_VDC_NC_VIDEO_TRIGER_AND_WHITELIST,	//脱机_视频触发+有效白名单（13），
            ICE_VDC_NC_SOFT_TRIGER_AND_WHITELIST,  	//脱机_软触发+有效白名单（14），
            ICE_VDC_NC_HD_TRIGER_AND_BLACKLIST,		//脱机_硬触发+黑名单(15),
            ICE_VDC_NC_VIDEO_TRIGER_AND_BLACKLIST,	//脱机_视频触发+黑名单（16），
            ICE_VDC_NC_SOFT_TRIGER_AND_BLACKLIST,  	//脱机_软触发+黑名单（17），

            ICE_VDC_HD_TRIGER_AND_OVERDUE_WHITELIST,		//实时_硬触发+过期白名单(18),
            ICE_VDC_VIDEO_TRIGER_AND_OVERDUE_WHITELIST,		//实时_视频触发+过期白名单（19），
            ICE_VDC_SOFT_TRIGER_AND_OVERDUE_WHITELIST,  	//实时_软触发+过期白名单（20），
            ICE_VDC_NC_HD_TRIGER_AND_OVERDUE_WHITELIST,		//脱机_硬触发+过期白名单(21),
            ICE_VDC_NC_VIDEO_TRIGER_AND_OVERDUE_WHITELIST,	//脱机_视频触发+过期白名单（22），
            ICE_VDC_NC_SOFT_TRIGER_AND_OVERDUE_WHITELIST,  	//脱机_软触发+过期白名单（23），

            ICE_VDC_ALARM_UNKOWN,
        }ICE_VDC_ALARM_TYPE;
     * /
    /**
     *  @brief  通过该回调函数获得实时识别数据
     *  @param  [OUT] pvParam	         用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（与设置此回调接口的最后一个参数相同）
     *  @param  [OUT] pcIP	             相机ip
     *  @param  [OUT] pcNumber           车牌号	
     *  @param  [OUT] pcColor            车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）
     *  @param  [OUT] pcPicData          全景数据
     *  @param  [OUT] u32PicLen          全景数据长度
     *  @param  [OUT] pcCloseUpPicData   车牌数据
     *  @param  [OUT] u32CloseUpPicLen   车牌数据长度
     *  @param  [OUT] nSpeed             车辆速度
     *  @param  [OUT] nVehicleType       车辆类型（0:未知,1轿车,2面包车,3大型客车,4中型客车,5皮卡,6非机动车,7SUV,8MPV,9微型货车,10轻型货车,11中型货车,12重型货车)
     *  @param  [OUT] nReserved1         预留参数1
     *  @param  [OUT] nReserved2         预留参数2
     *  @param  [OUT] fPlateConfidence   车牌打分值（SDK输出的范围大于IE界面设置的车牌阈值，上限是28，例如：IE设置的是10，范围：10-28）
     *  @param  [OUT] u32VehicleColor    车身颜色（车辆特征码相机版本：(-1:未知,0:黑色,1:蓝色,2:灰色,3:棕色,4:绿色,5:夜间深色,6:紫色,7:红色,8:白色,9:黄色)
     *                                           其它相机版本：(0:未知,1:红色,2:绿色,3:蓝色,4:黄色,5:白色,6:灰色,7:黑色,8:紫色,9:棕色,10:粉色)）
     *  @param  [OUT] u32PlateType       车牌类型，详见车牌类型ICE_PLATETYPE_E枚举值
     *  @param  [OUT] u32VehicleDir      车辆方向（0:车头方向,1:车尾方向,2:车头和车尾方向）
     *  @param  [OUT] u32AlarmType       报警输出，详见报警输出ICE_VDC_ALARM_TYPE枚举值
     *  @param  [OUT] u32SerialNum       抓拍的序号（从相机第一次抓拍开始计数，相机重启后才清零）
     *  @param  [OUT] uCapTime           实时抓拍时间，从1970年1月1日零点开始的秒数
     *  @param  [OUT] u32ResultHigh      车牌识别数据结构体（ICE_VDC_PICTRUE_INFO_S）指针高8位（64位sdk时需要使用）
     *  @param  [OUT] u32ResultLow       车牌识别数据结构体（ICE_VDC_PICTRUE_INFO_S）指针低8位
     *  @return void
     */
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void ICE_IPCSDK_OnPlate(
                IntPtr pvParam,
                [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
                [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcNumber,
                [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcColor,
                IntPtr pcPicData,
                uint u32PicLen,
                IntPtr pcCloseUpPicData,
                uint u32CloseUpPicLen,
                short nSpeed,
                short nVehicleType,
                short nReserved1,
                short nReserved2,
                float fPlateConfidence,
                uint u32VehicleColor,
                uint u32PlateType,
                uint u32VehicleDir,
                uint u32AlarmType,
                uint u32SerialNum,
                uint uCapTime,
                uint u32ResultHigh,
                uint u32ResultLow);

    /**
     *  @brief  通过该回调函数获得断网识别数据
     *  @param  [OUT] pvParam	         用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetPastPlateCallBack传入的最后一个参数）
     *  @param  [OUT] pcIP	             相机ip
     *  @param  [OUT] u32CapTime         抓拍时间   
     *  @param  [OUT] pcNumber           车牌号	
     *  @param  [OUT] pcColor            车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）
     *  @param  [OUT] pcPicData          全景数据
     *  @param  [OUT] u32PicLen          全景数据长度
     *  @param  [OUT] pcCloseUpPicData   车牌数据
     *  @param  [OUT] u32CloseUpPicLen   车牌数据长度
     *  @param  [OUT] s16PlatePosLeft    车牌区域左上角横坐标
     *  @param  [OUT] s16PlatePosTop     车牌区域左上角纵坐标
     *  @param  [OUT] s16PlatePosRight   车牌区域右下角横坐标
     *  @param  [OUT] s16PlatePosBottom  车牌区域右下角纵坐标
     *  @param  [OUT] fPlateConfidence   车牌打分值（SDK输出的范围大于IE界面设置的车牌阈值，上限是28，例如：IE设置的是10，范围：10-28）
     *  @param  [OUT] u32VehicleColor    车身颜色（0:未知,1:红色,2:绿色,3:蓝色,4:黄色,5:白色,6:灰色,7:黑色,8:紫色,9:棕色,10:粉色）
     *  @param  [OUT] u32PlateType       车牌类型，详见车牌类型ICE_PLATETYPE_E枚举值
     *  @param  [OUT] u32VehicleDir      车辆方向（0:车头方向,1:车尾方向,2:车头和车尾方向）
     *  @param  [OUT] u32AlarmType       报警输出，详见报警输出ICE_VDC_ALARM_TYPE枚举值
     *  @param  [OUT] u32Reserved1       预留参数1
     *  @param  [OUT] u32Reserved2       预留参数2
     *  @param  [OUT] u32Reserved3       预留参数3
     *  @param  [OUT] u32Reserved4       预留参数4
     *  @return void
     */
    public delegate void ICE_IPCSDK_OnPastPlate(
        IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32CapTime,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcNumber,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcColor,
        IntPtr pcPicData,
        uint u32PicLen,
        IntPtr pcCloseUpPicData,
        uint u32CloseUpPicLen,
        short s16PlatePosLeft,
        short s16PlatePosTop,
        short s16PlatePosRight,
        short s16PlatePosBottom,
        float fPlateConfidence,
        uint u32VehicleColor,
        uint u32PlateType,
        uint u32VehicleDir,
        uint u32AlarmType,
        uint u32Reserved1,
        uint u32Reserved2,
        uint u32Reserved3,
        uint u32Reserved4);

    /**
     *  @brief  通过该回调函数获得RS485数据
     *  @param  [OUT] pvParam   用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetSerialPortCallBack传入的最后一个参数）
     *  @param  [OUT] pcIP      相机ip
     *  @param  [OUT] pcData    串口数据首地址
     *  @param  [OUT] u32Len    串口数据长度
     *  @return void
     */
    public delegate void ICE_IPCSDK_OnSerialPort(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        IntPtr pcData, uint u32Len);

    /**
     *  @brief  通过该回调函数获得RS232数据
     *  @param  [OUT] pvParam   用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetSerialPortCallBack_RS232传入的最后一个参数）
     *  @param  [OUT] pcIP      相机ip
     *  @param  [OUT] pcData    串口数据首地址
     *  @param  [OUT] u32Len    串口数据长度
     *  @return void
     */
    public delegate void ICE_IPCSDK_OnSerialPort_RS232(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        IntPtr pcData, uint u32Len);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pvParam"></param>
    /// <param name="pcIP"></param>
    /// <param name="u32EventType"></param>
    /// <param name="u32EventData1"></param>
    /// <param name="u32EventData2"></param>
    /// <param name="u32EventData3"></param>
    /// <param name="u32EventData4"></param>
    public delegate void ICE_IPCSDK_OnDeviceEvent(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32EventType, uint u32EventData1, uint u32EventData2, uint u32EventData3, uint u32EventData4);

    /**
    *  @brief  通过该回调函数获取相机的对讲状态变化
    *  @param  [OUT] pvParam             相机连接回调参数, 用于区分不同相机对讲事件(ICE_IPCSDK_SetTalkEventCallBack传入的最后一个参数)
    *  @param  [OUT] pcIP                相机ip
    *  @param  [OUT] u32EventType        事件类型 0：普通非对讲状态 1：触发对讲 2：正在对讲 3:相机端发起对讲后，被某个管理端拒绝通话 4:通话中断
    *  @param  [OUT] pcTalkIp			 事件类型为2时，表示与相机端接通的管理端ip；事件类型为3时，表示拒绝与相机通话的管理端ip
    *  @param  [OUT] u32Reserve1		预留1 
    *  @param  [OUT] u32Reserve2        预留2 
    *  @param  [OUT] u32Reserve3        预留3 
    *  @param  [OUT] u32Reserve4        预留4 
    */
    [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
    public delegate void ICE_IPCSDK_OnTalkEvent(IntPtr pvParam, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32EventType, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcTalkIp,
        uint u32Reserve1, uint u32Reserve2, uint u32Reserve3, uint u32Reserve4);

    /**
     *  @brief  通过该回调函数获得解码出的一帧图像
     *  @param  [OUT] pvParam       用户自定义参数，用来区分不同的sdk使用者，类似于线程入口函数的参数（即ICE_IPCSDK_SetFrameCallback传入的最后一个参数）
     *  @param  [OUT] u32Timestamp  时间戳
     *  @param  [OUT] pu8DataY      y帧数据地址
     *  @param  [OUT] pu8DataU      U帧数据地址
     *  @param  [OUT] pu8DataV      V帧数据地址
     *  @param  [OUT] s32LinesizeY  y帧数据每扫描行长度
     *  @param  [OUT] s32LinesizeU  U帧数据每扫描行长度
     *  @param  [OUT] s32LinesizeV  V帧数据每扫描行长度
     *  @param  [OUT] s32Width      图像宽度
     *  @param  [OUT] s32Height     图像高度
     *  @return void
     */
    public delegate void ICE_IPCSDK_OnFrame_Planar(IntPtr pvParam, uint u32Timestamp,
                                                    IntPtr pu8DataY, IntPtr pu8DataU,
                                                    IntPtr pu8DataV, int s32LinesizeY,
                                                    int s32LinesizeU, int s32LinesizeV, int s32Width, int s32Height);

    /**
    *  @brief  通过该回调函数获取相机的IO状态变化
    *  @param  [OUT] pvParam             相机连接回调参数, 用于区分不同相机IO事件(ICE_IPCSDK_SetIOEventCallBack传入的最后一个参数)
    *  @param  [OUT] pcIP                相机ip
    *  @param  [OUT] u32EventType        事件类型 0：IO变化
    *  @param  [OUT] u32IOData1       事件数据1 事件类型为0时，代表IO1的状态;）
    *  @param  [OUT] u32IOData2       事件数据2 （事件类型为0时，代表IO2的状态）
    *  @param  [OUT] u32IOData3       事件数据3 （事件类型为0时，代表IO3的状态）
    *  @param  [OUT] u32IOData4       事件数据4 （事件类型为0时，代表IO4的状态）
    */
    public delegate void ICE_IPCSDK_OnIOEvent(IntPtr pvParam,
        [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
        uint u32EventType, uint u32IOData1, uint u32IOData2, uint u32IOData3, uint u32IOData4);

    #endregion
    /// <summary>
    /// 代理
    /// </summary>
    public interface IIceIpcSdkProxy
    {
        /**
         *  @brief  设置获得实时识别数据的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPlate  实时识别数据，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        void ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam);

        /**
         *  @brief  设置获得断网识别数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPastPlate      断网识别数据，通过该回调获得
         *  @param  [IN] pvPastPlateParam   回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        void ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate,
                                                                 IntPtr pvPastPlateParam);

        /**
         *  @brief  设置获得RS485数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS485数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         */
        void ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort,
                                                                  IntPtr pvSerialPortParam);

        /**
         *  @brief  设置获得RS232数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS232数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        void ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort,
                                                                        IntPtr pvSerialPortParam);

        void ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam);

        void ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam);

        /**
         *  @brief  设置获得解码出的一帧图像的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnFrame  解码出的一帧图像，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        void ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam);

        /**
         *  @brief  全局初始化
         *  @return void
         */
        void ICE_IPCSDK_Init();

        /**
         *  @brief  全局释放
         *  @return void
         */
        void ICE_IPCSDK_Fini();

        /**
         *  @brief  连接相机并接入视频（推荐使用）
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        IntPtr ICE_IPCSDK_OpenPreview(
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
           byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  使用密码连接相机并接入视频
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        IntPtr ICE_IPCSDK_OpenPreview_Passwd(
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
           [MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
           byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  连接相机，不带视频流
         *  @param  [IN] pcIP   相机ip
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        IntPtr ICE_IPCSDK_OpenDevice([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);

        /**
         *  @brief  使用密码连接相机，不带视频流
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        IntPtr ICE_IPCSDK_OpenDevice_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd);

        /**
         *  @brief  连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        IntPtr ICE_IPCSDK_Open(
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
           byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort,
           ushort u16OnvifPort, byte u8MainStream, uint pfOnStream,
           IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  使用密码连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        IntPtr ICE_IPCSDK_Open_Passwd(
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
           byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream,
           uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  断开连接
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        void ICE_IPCSDK_Close(IntPtr hSDK);

        /**
         *  @brief  连接视频
         *  @param  [IN] hSDK           连接相机时返回的句柄值
         *  @param  [IN] u8MainStream   是否请求主码流（1：主码流 0：子码流）
         *  @param  [IN] hWnd           预览视频的窗口句柄
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd);

        /**
         *  @brief  断开视频
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        void ICE_IPCSDK_StopStream(IntPtr hSDK);

        /**
         *  @brief   打开道闸
         *  @param   [IN] hSDK 由连接相机接口获得的句柄
         *  @return  1表示成功，0表示失败
         */
        uint ICE_IPCSDK_OpenGate(IntPtr hSDK);

        /**
         *  @brief   控制开关量输出
         *  @param   [IN] hSDK      由连接相机接口获得的句柄
         *  @param   [IN] u32Index  控制的IO口(0:表示IO1 1:表示IO2)
         *  @return  1表示成功，0表示失败
         */
        uint ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  获取开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [OUT] pu32IdleState   常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [OUT] pu32DelayTime   切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [OUT] pu32Reserve     预留参数
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState,
                                                               ref uint pu32DelayTime, ref uint pu32Reserve);

        /**
         *  @brief  设置开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [IN] pu32IdleState    常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [IN] pu32DelayTime    切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [IN] pu32Reserve      预留参数
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState,
                                                               uint u32DelayTime, uint u32Reserve);
        /**
         *  @brief  开始对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_BeginTalk(IntPtr hSDK);

        /**
         *  @brief  结束对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        void ICE_IPCSDK_EndTalk(IntPtr hSDK);

        /**
         *  @brief  软触发
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcNumber      车牌号
         *  @param  [OUT] pcColor       车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor,
                                                   byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  软触发扩展接口
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_TriggerExt(IntPtr hSDK);

        /**
         *  @brief  手动抓拍，不做识别，直接抓拍一张码流的图片
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  获取相机连接状态
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示在线，0表示离线
         */
        uint ICE_IPCSDK_GetStatus(IntPtr hSDK);

        /**
         *  @brief  重启相机
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_Reboot(IntPtr hSDK);

        /**
         *  @brief  时间同步
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @param  [IN] u16Year    年
         *  @param  [IN] u8Month    月
         *  @param  [IN] u8Day      日
         *  @param  [IN] u8Hour     时
         *  @param  [IN] u8Min      分
         *  @param  [IN] u8Sec      秒
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day,
                                                       byte u8Hour, byte u8Min, byte u8Sec);

        /**
         *  @brief  发送RS485串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS485串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  发送RS232串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS232串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  获取相机mac地址
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [OUT] szDevID  相机mac地址
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID);

        /**
         *  @brief  开始录像
         *  @param  [IN] hSDK        由连接相机接口获得的句柄
         *  @param  [IN] pcFileName  保存录像的文件名
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_StartRecord(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcFileName);

        /**
         *  @brief  结束录像
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return void
         */
        void ICE_IPCSDK_StopRecord(IntPtr hSDK);

        /**
         *  @brief  设置OSD参数
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pstOSDAttr OSD参数结构体地址，详见ICE_OSDAttr_S
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr);

        /**
         *  @brief  写入用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_WriteUserData(IntPtr hSDK,
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData);

        /**
         *  @brief  读取用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize);

        /**
         *  @brief  写入二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @parame [IN] nOffset    偏移量
         *  @parame [IN] nLen       写入数据的长度
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK,
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData,
           uint nOffset, uint nLen);

        /**
         *  @brief  读取二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @param  [IN] nOffset    读数据的偏移量
         *  @param  [IN] nLen       需要读出的数据的大小
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData,
                                                                uint nSize, uint nOffset, uint nLen);
        /**
         *  @brief  获取相机网络参数
         *  @param  [IN] hSDK          由连接相机接口获得的句柄
         *  @parame [OUT] pu32IP       相机ip
         *  @param  [OUT] pu32Mask     相机掩码
         *  @param  [OUT] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway);

        /**
         *  @brief  设置相机网络参数
         *  @param  [IN] hSDK         由连接相机接口获得的句柄
         *  @parame [IN] pu32IP       相机ip
         *  @param  [IN] pu32Mask     相机掩码
         *  @param  [IN] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway);

        /**
         *  @brief  搜索区域网内相机
         *  @param  [OUT] szDevs   设备mac地址和ip地址的字符串
         *                         设备mac地址和ip地址的字符串，格式为：mac地址 ip地址 例如：00-00-00-00-00-00 192.168.55.150\r\n
         *  @return void
         */
        void ICE_IPCSDK_SearchDev(StringBuilder szDevs);

        /**
         *  @brief  记录日志配置
         *  @param  [IN] openLog    是否开启日志，0：不开启 1：开启
         *  @parame [IN] logPath    日志路径，默认为D:\
         *  @return void
         */
        void ICE_IPCSDK_LogConfig(int openLog, string logPath);

        /**
         *  @brief  语音播放，单条语音
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex);

        /**
         *  @brief  语音组播
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    包含语音序号的字符串  注：中间可以用, ; \t \n或者空格分开；如：1 2 3 4或者1,2,3,4
         *                         语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_BroadcastGroup(IntPtr hSDK,
           [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIndex);

        /**
         *  @brief  设置优先城市
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] u32Index  优先城市的索引号
         *  优先城市列表：（0  全国；1  北京；2  上海；3  天津；4  重庆；5  黑龙江；6  吉林；7  辽宁；8  内蒙古；9  河北；10 山东
                         11 山西；12 安徽；13 江苏；14 浙江；15 福建；16 广东；17 河南；18 江西；19 湖南；20 湖北；21 广西
                         22 海南；23 云南；24 贵州；25 四川；26 陕西；27 甘肃；28 宁夏；29 青海；30 西藏；31 新疆）

         *  @return 1表示成功，0表示失败
         */
        uint ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  特征码比较
         *  @param  [IN] _pfResFeat1    需要比较的特征码1
         *  @param  [IN] _iFeat1Len     特征码1的长度，目前需输入20
         *  @param  [IN] _pfReaFeat2    需要比较的特征码2
         *  @param  [IN] _iFeat2Len     特征码2的长度，目前需输入20
         *  @return  匹配度，范围：0-1，值越大越匹配
         */
        float ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len,
                                                             float[] _pfReaFeat2, uint _iFeat2Len);

        /**
        *  @brief  设置识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [IN] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [IN] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [IN] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [IN] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [IN] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，高为720）
        *  @rerun 设置状态 1 设置成功 0 设置失败
        */
        uint ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  获取识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [OUT] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [OUT] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [OUT] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [OUT] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [OUT] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，宽为720）
        *  @rerun 设置状态 1 获取成功 0 获取失败
        */
        uint ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  设置触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        uint ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode);

        /**
        *  @brief  获取触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        uint ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode);

        /**
        *  @brief  获取系统版本
        *  @param  [IN] hSDK        连接相机时返回的sdk句柄
        *  @param  [IN] pstSysVersion       系统版本信息
        *  @return 0 失败 1 成功
        */
        uint ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo);

        /**
        *  @brief  获取串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数结构体(ICE_UART_PARAM)
        *  @return 0 失败 1 成功
        */
        uint ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  设置串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数
        *  @return 0 失败 1 成功
        */
        uint ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  获取IO状态
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [IN]  u32Index         IO序列号（0: IO1 1:IO2 2:IO3 3:IO4）
        *  @param  [OUT] pu32IOState      IO状态 （0：有数据 1：无数据）
        *  @param  [OUT] pu32Reserve1     预留参数1
        *  @param  [OUT] pu32Reserve2     预留参数2
        *  @return 0 失败 1 成功
        */
        uint ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       车辆在场信息缓冲区地址 
        *  @param  [IN] u32PicSize			 车辆在场信息缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         车辆在场信息实际长度
        */
        uint ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       脱机计费数据缓冲区地址 
        *  @param  [IN] u32PicSize			 脱机计费数据缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         脱机计费数据实际长度
        */
        uint ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /**
        *  @brief  设置相机连接状态回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              IO事件回调
        *  @param  [IN] pvIOEventParam           IO事件回调参数,用于区分不同IO变化事件
        */
        void ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam);

        /**
        *  @brief  设置无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [IN] s32FilterByPlate				是否输出无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        uint ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand);

        /**
        *  @brief  获取无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [OUT] s32FilterByPlate				是否过滤无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        uint ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand);

        uint ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        uint ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        uint ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics);

        uint ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license);

        uint ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd);

        uint ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd);

        uint ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd);

        uint ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len);

        uint ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, String szFilePath, int s32Type);

        uint ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);

        uint ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
    }
    internal partial class IceIpcDller : IIceIpcSdkProxy
    {
        /// <summary>
        /// 由于这是本地目录中加载,所以加载一次就够用了
        /// </summary>
        public static IIceIpcSdkProxy Instance { get; } = new IceIpcDller();
        private IceIpcDller() { }
        public const String DllFileName = "ice_ipcsdk.dll";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(".");
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.GetFullPath(DllFileName);
        /**
         *  @brief  设置获得实时识别数据的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPlate  实时识别数据，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetPlateCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam);

        /**
         *  @brief  设置获得断网识别数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnPastPlate      断网识别数据，通过该回调获得
         *  @param  [IN] pvPastPlateParam   回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetPastPlateCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate,
                                                                  IntPtr pvPastPlateParam);

        /**
         *  @brief  设置获得RS485数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS485数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetSerialPortCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort,
                                                                   IntPtr pvSerialPortParam);

        /**
         *  @brief  设置获得RS232数据的相关回调函数
         *  @param  [IN] hSDK               连接相机时返回的sdk句柄
         *  @param  [IN] pfOnSerialPort     相机发送的RS232数据，通过该回调获得
         *  @param  [IN] pvSerialPortParam  回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetSerialPortCallBack_RS232", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort,
                                                                         IntPtr pvSerialPortParam);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetDeviceEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam);

        /**
        *  @brief  设置相机对讲状态变化回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              对讲事件回调
        *  @param  [IN] pvIOEventParam           对讲事件回调参数,用于区分不同对讲变化事件
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetTalkEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam);

        /**
         *  @brief  设置获得解码出的一帧图像的相关回调函数
         *  @param  [IN] hSDK       连接相机时返回的sdk句柄
         *  @param  [IN] pfOnFrame  解码出的一帧图像，通过该回调获得
         *  @param  [IN] pvParam    回调函数中的参数，能区分开不同的使用者即可
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetFrameCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam);

        /**
         *  @brief  全局初始化
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Init();

        /**
         *  @brief  全局释放
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Fini", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Fini();

        /**
         *  @brief  连接相机并接入视频（推荐使用）
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_OpenPreview", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenPreview(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  使用密码连接相机并接入视频
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）    
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] hWnd          预览视频的窗口句柄
         *  @param  [IN] pfOnPlate     车牌识别数据通过该回调获得
         *  @param  [IN] pvPlateParam  车牌回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_OpenPreview_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenPreview_Passwd(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
            byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);

        /**
         *  @brief  连接相机，不带视频流
         *  @param  [IN] pcIP   相机ip
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_OpenDevice", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenDevice([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);

        /**
         *  @brief  使用密码连接相机，不带视频流
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_OpenDevice_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_OpenDevice_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd);

        /**
         *  @brief  连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_Open(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort,
            ushort u16OnvifPort, byte u8MainStream, uint pfOnStream,
            IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  使用密码连接相机
         *  @param  [IN] pcIP          相机ip
         *  @param  [IN] pcPasswd      连接密码
         *  @param  [IN] u8OverTCP     是否使用tcp模式（1：使用tcp 0：不使用tcp，使用udp）
         *  @param  [IN] u16RTSPPort   rtsp端口（554）
         *  @param  [IN] u16ICEPort    私有协议对应的端口（8117）
         *  @param  [IN] u16OnvifPort  onvif端口（8080）
         *  @param  [IN] u8MainStream  是否请求主码流（1：主码流 0：子码流） 
         *  @param  [IN] pfOnStream    网络流回调地址，可以为NULL(demo中没有使用)
         *  @param  [IN] pvStreamParam 网络流回调参数，能区分开不同的使用者即可
         *  @param  [IN] pfOnFrame     图像帧回调地址，可以为NULL，只有当u8ReqType包含了REQ_TYPE_H264时才有意义(demo中没有使用)
         *  @param  [IN] pvFrameParam  图像帧回调参数，能区分开不同的使用者即可
         *  @return sdk句柄(连接不成功时，返回值为null）
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Open_Passwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ICE_IPCSDK_Open_Passwd(
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd,
            byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream,
            uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);

        /**
         *  @brief  断开连接
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_Close(IntPtr hSDK);

        /**
         *  @brief  连接视频
         *  @param  [IN] hSDK           连接相机时返回的句柄值
         *  @param  [IN] u8MainStream   是否请求主码流（1：主码流 0：子码流）
         *  @param  [IN] hWnd           预览视频的窗口句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_StartStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd);

        /**
         *  @brief  断开视频
         *  @param  [IN] hSDK   连接相机时返回的句柄值
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_StopStream", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_StopStream(IntPtr hSDK);

        /**
         *  @brief   打开道闸
         *  @param   [IN] hSDK 由连接相机接口获得的句柄
         *  @return  1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_OpenGate", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_OpenGate(IntPtr hSDK);

        /**
         *  @brief   控制开关量输出
         *  @param   [IN] hSDK      由连接相机接口获得的句柄
         *  @param   [IN] u32Index  控制的IO口(0:表示IO1 1:表示IO2)
         *  @return  1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_ControlAlarmOut", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  获取开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [OUT] pu32IdleState   常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [OUT] pu32DelayTime   切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [OUT] pu32Reserve     预留参数
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetAlarmOutConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState,
                                                                ref uint pu32DelayTime, ref uint pu32Reserve);

        /**
         *  @brief  设置开关量输出配置
         *  @param  [IN] hSDK             由连接相机接口获得的句柄
         *  @parame [IN] u32Index         IO口（0：IO1 1：IO2）
         *  @param  [IN] pu32IdleState    常开常闭状态的配置（0 是常开，1是常闭）
         *  @param  [IN] pu32DelayTime    切换状态的时间（-1表示不恢复 单位：s）
         *  @param  [IN] pu32Reserve      预留参数
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetAlarmOutConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState,
                                                                uint u32DelayTime, uint u32Reserve);
        /**
         *  @brief  开始对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_BeginTalk", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BeginTalk(IntPtr hSDK);

        /**
         *  @brief  结束对讲
         *  @param  [IN] hSDK 由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_EndTalk", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_EndTalk(IntPtr hSDK);

        /**
         *  @brief  软触发
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcNumber      车牌号
         *  @param  [OUT] pcColor       车牌颜色（"蓝色","黄色","白色","黑色",“绿色”）
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Trigger", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor,
                                                    byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  软触发扩展接口
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_TriggerExt", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_TriggerExt(IntPtr hSDK);

        /**
         *  @brief  手动抓拍，不做识别，直接抓拍一张码流的图片
         *  @param  [IN]  hSDK          由连接相机接口获得的句柄
         *  @param  [OUT] pcPicData     抓拍图片数据
         *  @param  [OUT] u32PicSize    抓拍图片缓冲区大小
         *  @param  [OUT] pu32PicLen    抓拍图片实际长度
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Capture", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);

        /**
         *  @brief  获取相机连接状态
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示在线，0表示离线
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetStatus", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetStatus(IntPtr hSDK);

        /**
         *  @brief  重启相机
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Reboot", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Reboot(IntPtr hSDK);

        /**
         *  @brief  时间同步
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @param  [IN] u16Year    年
         *  @param  [IN] u8Month    月
         *  @param  [IN] u8Day      日
         *  @param  [IN] u8Hour     时
         *  @param  [IN] u8Min      分
         *  @param  [IN] u8Sec      秒
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SyncTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day,
                                                        byte u8Hour, byte u8Min, byte u8Sec);

        /**
         *  @brief  发送RS485串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS485串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_TransSerialPort", CallingConvention = CallingConvention.Cdecl)]
        //public static extern uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, String pcData, uint u32Len);
        public static extern uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  发送RS232串口数据
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [IN] pcData    RS232串口数据
         *  @param  [IN] u32Len    串口数据长度
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_TransSerialPort_RS232", CallingConvention = CallingConvention.Cdecl)]
        //public static extern uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, string pcData, uint u32Len);
        public static extern uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len);

        /**
         *  @brief  获取相机mac地址
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @param  [OUT] szDevID  相机mac地址
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetDevID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID);

        /**
         *  @brief  开始录像
         *  @param  [IN] hSDK        由连接相机接口获得的句柄
         *  @param  [IN] pcFileName  保存录像的文件名
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_StartRecord", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_StartRecord(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcFileName);

        /**
         *  @brief  结束录像
         *  @param  [IN] hSDK   由连接相机接口获得的句柄
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_StopRecord", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_StopRecord(IntPtr hSDK);

        /**
         *  @brief  设置OSD参数
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pstOSDAttr OSD参数结构体地址，详见ICE_OSDAttr_S
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetOSDCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr);

        /**
         *  @brief  写入用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_WriteUserData", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_WriteUserData(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData);

        /**
         *  @brief  读取用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_ReadUserData", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize);

        /**
         *  @brief  写入二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [IN] pcData     需要写入的用户数据
         *  @parame [IN] nOffset    偏移量
         *  @parame [IN] nLen       写入数据的长度
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_WriteUserData_Binary", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData,
            uint nOffset, uint nLen);

        /**
         *  @brief  读取二进制用户数据
         *  @param  [IN] hSDK       由连接相机接口获得的句柄
         *  @parame [OUT] pcData    读取的用户数据
         *  @param  [IN] nSize      读出的数据的最大长度，即缓冲区大小
         *  @param  [IN] nOffset    读数据的偏移量
         *  @param  [IN] nLen       需要读出的数据的大小
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_ReadUserData_Binary", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData,
                                                                 uint nSize, uint nOffset, uint nLen);
        /**
         *  @brief  获取相机网络参数
         *  @param  [IN] hSDK          由连接相机接口获得的句柄
         *  @parame [OUT] pu32IP       相机ip
         *  @param  [OUT] pu32Mask     相机掩码
         *  @param  [OUT] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetIPAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway);

        /**
         *  @brief  设置相机网络参数
         *  @param  [IN] hSDK         由连接相机接口获得的句柄
         *  @parame [IN] pu32IP       相机ip
         *  @param  [IN] pu32Mask     相机掩码
         *  @param  [IN] u32Gateway   相机网关
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetIPAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway);

        /**
         *  @brief  搜索区域网内相机
         *  @param  [OUT] szDevs   设备mac地址和ip地址的字符串
         *                         设备mac地址和ip地址的字符串，格式为：mac地址 ip地址 例如：00-00-00-00-00-00 192.168.55.150\r\n
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SearchDev", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SearchDev(StringBuilder szDevs);

        /**
         *  @brief  记录日志配置
         *  @param  [IN] openLog    是否开启日志，0：不开启 1：开启
         *  @parame [IN] logPath    日志路径，默认为D:\
         *  @return void
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_LogConfig", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_LogConfig(int openLog, string logPath);

        /**
         *  @brief  语音播放，单条语音
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_Broadcast", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex);

        /**
         *  @brief  语音组播
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] nIndex    包含语音序号的字符串  注：中间可以用, ; \t \n或者空格分开；如：1 2 3 4或者1,2,3,4
         *                         语音文件索引号，详见《语音列表.txt》
         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_BroadcastGroup", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BroadcastGroup(IntPtr hSDK,
            [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIndex);

        /**
         *  @brief  设置优先城市
         *  @param  [IN] hSDK      由连接相机接口获得的句柄
         *  @parame [IN] u32Index  优先城市的索引号
         *  优先城市列表：（0  全国；1  北京；2  上海；3  天津；4  重庆；5  黑龙江；6  吉林；7  辽宁；8  内蒙古；9  河北；10 山东
                         11 山西；12 安徽；13 江苏；14 浙江；15 福建；16 广东；17 河南；18 江西；19 湖南；20 湖北；21 广西
                         22 海南；23 云南；24 贵州；25 四川；26 陕西；27 甘肃；28 宁夏；29 青海；30 西藏；31 新疆）

         *  @return 1表示成功，0表示失败
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetCity", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index);

        /**
         *  @brief  特征码比较
         *  @param  [IN] _pfResFeat1    需要比较的特征码1
         *  @param  [IN] _iFeat1Len     特征码1的长度，目前需输入20
         *  @param  [IN] _pfReaFeat2    需要比较的特征码2
         *  @param  [IN] _iFeat2Len     特征码2的长度，目前需输入20
         *  @return  匹配度，范围：0-1，值越大越匹配
         */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_VBR_CompareFeat", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len,
                                                              float[] _pfReaFeat2, uint _iFeat2Len);

        /**
        *  @brief  设置识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [IN] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [IN] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [IN] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [IN] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [IN] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，高为720）
        *  @rerun 设置状态 1 设置成功 0 设置失败
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  获取识别区域        注意：绘制时以左下、右上为坐标基点来绘制识别矩形框。
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] nLeft          识别区域左坐标点（以左上角为坐标原点）
        *  @param  [OUT] nBottom        识别区域下坐标点（以左上角为坐标原点）
        *  @param  [OUT] nRight         识别区域右坐标点（以左上角为坐标原点）
        *  @param  [OUT] nTop           识别区域上坐标点（以左上角为坐标原点）
        *  @param  [OUT] nWidth         坐标是在什么分辨率下取得的，表示宽（如在1280*720下取得的，宽为1280）
        *  @param  [OUT] nHeight        坐标是在什么分辨率下取得的，表示高（如在1280*720下取得的，宽为720）
        *  @rerun 设置状态 1 获取成功 0 获取失败
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetLoop", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight);

        /**
        *  @brief  设置触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [IN] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetTriggerMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode);

        /**
        *  @brief  获取触发模式
        *  @param  [IN] hSDK           sdk句柄
        *  @param  [OUT] u32TriggerMode 触发模式（0：线圈触发 1：视频触发）
        *  @rerun  设置状态 1 设置成功 0 设置失败
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetTriggerMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode);

        /**
        *  @brief  获取系统版本
        *  @param  [IN] hSDK        连接相机时返回的sdk句柄
        *  @param  [IN] pstSysVersion       系统版本信息
        *  @return 0 失败 1 成功
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetCameraInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo);

        /**
        *  @brief  获取串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数结构体(ICE_UART_PARAM)
        *  @return 0 失败 1 成功
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetUARTCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  设置串口配置
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [OUT] pstUARTCfg       串口配置参数
        *  @return 0 失败 1 成功
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetUARTCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);

        /**
        *  @brief  获取IO状态
        *  @param  [IN]  hSDK             连接相机时返回的sdk句柄
        *  @param  [IN]  u32Index         IO序列号（0: IO1 1:IO2 2:IO3 3:IO4）
        *  @param  [OUT] pu32IOState      IO状态 （0：有数据 1：无数据）
        *  @param  [OUT] pu32Reserve1     预留参数1
        *  @param  [OUT] pu32Reserve2     预留参数2
        *  @return 0 失败 1 成功
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetIOState", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       车辆在场信息缓冲区地址 
        *  @param  [IN] u32PicSize			 车辆在场信息缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         车辆在场信息实际长度
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_getOfflineVehicleInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /*
        *  @brief  获取脱机计费数据
        *  @param  [IN] hSDK				 sdk句柄
        *  @param  [OUT] pcVehicleInfo       脱机计费数据缓冲区地址 
        *  @param  [IN] u32PicSize			 脱机计费数据缓冲区地址大小
        *  @param  [OUT] pu32PicLen	         脱机计费数据实际长度
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_getPayInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen);

        /**
        *  @brief  设置相机连接状态回调事件
        *  @param  [IN] hSDK                     连接相机时返回的sdk句柄
        *  @param  [IN] pfOnIOEvent              IO事件回调
        *  @param  [IN] pvIOEventParam           IO事件回调参数,用于区分不同IO变化事件
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetIOEventCallBack", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam);

        /**
        *  @brief  设置无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [IN] s32FilterByPlate				是否输出无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [IN] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetVehicleBrand", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand);

        /**
        *  @brief  获取无牌车输出，是否支持车款识别
        *  @param  [IN] hSDK							连接相机时返回的sdk句柄
        *  @param  [OUT] s32FilterByPlate				是否过滤无牌车（1：过滤，不输出无牌车，0：不过滤，输出无牌车）
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持无牌车的车款识别(1:输出，0：不输出，当不输出无牌车时，此项强制为0)
        *  @param  [OUT] s32EnableNoPlateVehicleBrand    是否支持有牌车的车款识别（1：输出，0：不输出）
        *  @return  获取状态 1 成功 0 失败
        */
        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetVehicleBrand", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetLedCreen_Config", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetLedCreen_Config", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetLicense", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_CheckLicense", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_EnableEnc", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_ModifyEncPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetDecPwd", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_BroadcastWav", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_UpdateWhiteListBatch", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, String szFilePath, int s32Type);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_GetSnapOsdCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);

        [DllImportAttribute(DllFileName, EntryPoint = "ICE_IPCSDK_SetSnapOsdCfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
        #region // 显示实现接口
        uint IIceIpcSdkProxy.ICE_IPCSDK_BeginTalk(IntPtr hSDK) => ICE_IPCSDK_BeginTalk(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex) => ICE_IPCSDK_Broadcast(hSDK, nIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastGroup(IntPtr hSDK, string pcIndex) => ICE_IPCSDK_BroadcastGroup(hSDK, pcIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_BroadcastWav(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => ICE_IPCSDK_Capture(hSDK, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license) => ICE_IPCSDK_CheckLicense(hSDK, license);
        void IIceIpcSdkProxy.ICE_IPCSDK_Close(IntPtr hSDK) => ICE_IPCSDK_Close(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index) => ICE_IPCSDK_ControlAlarmOut(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd) => ICE_IPCSDK_EnableEnc(hSDK, u32EncId, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_EndTalk(IntPtr hSDK) => ICE_IPCSDK_EndTalk(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_Fini() => ICE_IPCSDK_Fini();
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState, ref uint pu32DelayTime, ref uint pu32Reserve) => ICE_IPCSDK_GetAlarmOutConfig(hSDK, u32Index, ref pu32IdleState, ref pu32DelayTime, ref pu32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo) => ICE_IPCSDK_GetCameraInfo(hSDK, ref pstCameraInfo);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID) => ICE_IPCSDK_GetDevID(hSDK, szDevID);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2) => ICE_IPCSDK_GetIOState(hSDK, u32Index, ref pu32IOState, ref pu32Reserve1, ref pu32Reserve2);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway) => ICE_IPCSDK_GetIPAddr(hSDK, ref pu32IP, ref pu32Mask, ref pu32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => ICE_IPCSDK_GetLedCreen_Config(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight) => ICE_IPCSDK_GetLoop(hSDK, ref nLeft, ref nBottom, ref nRight, ref nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen) => ICE_IPCSDK_getOfflineVehicleInfo(hSDK, pcVehicleInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen) => ICE_IPCSDK_getPayInfo(hSDK, pcPayInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => ICE_IPCSDK_GetSnapOsdCfg(hSDK, ref pstParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetStatus(IntPtr hSDK) => ICE_IPCSDK_GetStatus(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode) => ICE_IPCSDK_GetTriggerMode(hSDK, ref pu32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => ICE_IPCSDK_GetUARTCfg(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand) => ICE_IPCSDK_GetVehicleBrand(hSDK, ref s32FilterByPlate, ref s32EnableNoPlateVehicleBrand, ref s32EnableVehicleBrand);
        void IIceIpcSdkProxy.ICE_IPCSDK_Init() => ICE_IPCSDK_Init();
        void IIceIpcSdkProxy.ICE_IPCSDK_LogConfig(int openLog, string logPath) => ICE_IPCSDK_LogConfig(openLog, logPath);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd) => ICE_IPCSDK_ModifyEncPwd(hSDK, szOldPwd, szNewPwd);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open(string pcIP, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => ICE_IPCSDK_Open(pcIP, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice(string pcIP) => ICE_IPCSDK_OpenDevice(pcIP);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice_Passwd(string pcIP, string pcPasswd) => ICE_IPCSDK_OpenDevice_Passwd(pcIP, pcPasswd);
        uint IIceIpcSdkProxy.ICE_IPCSDK_OpenGate(IntPtr hSDK) => ICE_IPCSDK_OpenGate(hSDK);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview(string pcIP, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => ICE_IPCSDK_OpenPreview(pcIP, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => ICE_IPCSDK_OpenPreview_Passwd(pcIP, pcPasswd, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => ICE_IPCSDK_Open_Passwd(pcIP, pcPasswd, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize) => ICE_IPCSDK_ReadUserData(hSDK, pcData, nSize);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData, uint nSize, uint nOffset, uint nLen) => ICE_IPCSDK_ReadUserData_Binary(hSDK, pcData, nSize, nOffset, nLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Reboot(IntPtr hSDK) => ICE_IPCSDK_Reboot(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_SearchDev(StringBuilder szDevs) => ICE_IPCSDK_SearchDev(szDevs);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState, uint u32DelayTime, uint u32Reserve) => ICE_IPCSDK_SetAlarmOutConfig(hSDK, u32Index, u32IdleState, u32DelayTime, u32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index) => ICE_IPCSDK_SetCity(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd) => ICE_IPCSDK_SetDecPwd(hSDK, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam) => ICE_IPCSDK_SetDeviceEventCallBack(hSDK, pfOnDeviceEvent, pvDeviceEventParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam) => ICE_IPCSDK_SetFrameCallback(hSDK, pfOnFrame, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam) => ICE_IPCSDK_SetIOEventCallBack(hSDK, pfOnIOEvent, pvIOEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway) => ICE_IPCSDK_SetIPAddr(hSDK, u32IP, u32Mask, u32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => ICE_IPCSDK_SetLedCreen_Config(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics) => ICE_IPCSDK_SetLicense(hSDK, old_lics, new_lics);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight) => ICE_IPCSDK_SetLoop(hSDK, nLeft, nBottom, nRight, nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr) => ICE_IPCSDK_SetOSDCfg(hSDK, ref pstOSDAttr);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate, IntPtr pvPastPlateParam) => ICE_IPCSDK_SetPastPlateCallBack(hSDK, pfOnPastPlate, pvPastPlateParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam) => ICE_IPCSDK_SetPlateCallback(hSDK, pfOnPlate, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort, IntPtr pvSerialPortParam) => ICE_IPCSDK_SetSerialPortCallBack(hSDK, pfOnSerialPort, pvSerialPortParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort, IntPtr pvSerialPortParam) => ICE_IPCSDK_SetSerialPortCallBack_RS232(hSDK, pfOnSerialPort, pvSerialPortParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => ICE_IPCSDK_SetSnapOsdCfg(hSDK, ref pstParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam) => ICE_IPCSDK_SetTalkEventCallBack(hSDK, pfOnTalkEvent, pvTalkEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode) => ICE_IPCSDK_SetTriggerMode(hSDK, u32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => ICE_IPCSDK_SetUARTCfg(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand) => ICE_IPCSDK_SetVehicleBrand(hSDK, s32FilterByPlate, s32EnableNoPlateVehicleBrand, s32EnableVehicleBrand);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartRecord(IntPtr hSDK, string pcFileName) => ICE_IPCSDK_StartRecord(hSDK, pcFileName);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd) => ICE_IPCSDK_StartStream(hSDK, u8MainStream, hWnd);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopRecord(IntPtr hSDK) => ICE_IPCSDK_StopRecord(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopStream(IntPtr hSDK) => ICE_IPCSDK_StopStream(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day, byte u8Hour, byte u8Min, byte u8Sec) => ICE_IPCSDK_SyncTime(hSDK, u16Year, u8Month, u8Day, u8Hour, u8Min, u8Sec);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_TransSerialPort(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len) => ICE_IPCSDK_TransSerialPort_RS232(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => ICE_IPCSDK_Trigger(hSDK, pcNumber, pcColor, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TriggerExt(IntPtr hSDK) => ICE_IPCSDK_TriggerExt(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, string szFilePath, int s32Type) => ICE_IPCSDK_UpdateWhiteListBatch(hSDK, szFilePath, s32Type);
        float IIceIpcSdkProxy.ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len, float[] _pfReaFeat2, uint _iFeat2Len) => ICE_IPCSDK_VBR_CompareFeat(_pfResFeat1, _iFeat1Len, _pfReaFeat2, _iFeat2Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData(IntPtr hSDK, string pcData) => ICE_IPCSDK_WriteUserData(hSDK, pcData);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK, string pcData, uint nOffset, uint nLen) => ICE_IPCSDK_WriteUserData_Binary(hSDK, pcData, nOffset, nLen);
        #endregion
    }
    internal partial class IceIpcSdkLoader : IIceIpcSdkProxy, IDisposable
    {
        /// <summary>
        /// 相对路径
        /// </summary>
        public const string DllPath = @"plugins\iceipcsdk";
        /// <summary>
        /// 全路径
        /// </summary>
        public static string DllFullPath { get; } = Path.GetFullPath(DllPath);
        /// <summary>
        /// 文件全路径
        /// </summary>
        public static String DllFullName { get; } = Path.Combine(Path.GetFullPath(DllPath), IceIpcDller.DllFileName);
        #region // 委托变量
        private DCreater.ICE_IPCSDK_Init _ICE_IPCSDK_Init;
        private DCreater.ICE_IPCSDK_Fini _ICE_IPCSDK_Fini;
        private DCreater.ICE_IPCSDK_SetPlateCallback _ICE_IPCSDK_SetPlateCallback;
        private DCreater.ICE_IPCSDK_SetPastPlateCallBack _ICE_IPCSDK_SetPastPlateCallBack;
        private DCreater.ICE_IPCSDK_SetSerialPortCallBack _ICE_IPCSDK_SetSerialPortCallBack;
        private DCreater.ICE_IPCSDK_SetSerialPortCallBack_RS232 _ICE_IPCSDK_SetSerialPortCallBack_RS232;
        private DCreater.ICE_IPCSDK_SetDeviceEventCallBack _ICE_IPCSDK_SetDeviceEventCallBack;
        private DCreater.ICE_IPCSDK_SetTalkEventCallBack _ICE_IPCSDK_SetTalkEventCallBack;
        private DCreater.ICE_IPCSDK_SetFrameCallback _ICE_IPCSDK_SetFrameCallback;
        private DCreater.ICE_IPCSDK_OpenPreview _ICE_IPCSDK_OpenPreview;
        private DCreater.ICE_IPCSDK_OpenPreview_Passwd _ICE_IPCSDK_OpenPreview_Passwd;
        private DCreater.ICE_IPCSDK_OpenDevice _ICE_IPCSDK_OpenDevice;
        private DCreater.ICE_IPCSDK_OpenDevice_Passwd _ICE_IPCSDK_OpenDevice_Passwd;
        private DCreater.ICE_IPCSDK_Open _ICE_IPCSDK_Open;
        private DCreater.ICE_IPCSDK_Open_Passwd _ICE_IPCSDK_Open_Passwd;
        private DCreater.ICE_IPCSDK_Close _ICE_IPCSDK_Close;
        private DCreater.ICE_IPCSDK_StartStream _ICE_IPCSDK_StartStream;
        private DCreater.ICE_IPCSDK_StopStream _ICE_IPCSDK_StopStream;
        private DCreater.ICE_IPCSDK_OpenGate _ICE_IPCSDK_OpenGate;
        private DCreater.ICE_IPCSDK_ControlAlarmOut _ICE_IPCSDK_ControlAlarmOut;
        private DCreater.ICE_IPCSDK_GetAlarmOutConfig _ICE_IPCSDK_GetAlarmOutConfig;
        private DCreater.ICE_IPCSDK_SetAlarmOutConfig _ICE_IPCSDK_SetAlarmOutConfig;
        private DCreater.ICE_IPCSDK_BeginTalk _ICE_IPCSDK_BeginTalk;
        private DCreater.ICE_IPCSDK_EndTalk _ICE_IPCSDK_EndTalk;
        private DCreater.ICE_IPCSDK_Trigger _ICE_IPCSDK_Trigger;
        private DCreater.ICE_IPCSDK_TriggerExt _ICE_IPCSDK_TriggerExt;
        private DCreater.ICE_IPCSDK_Capture _ICE_IPCSDK_Capture;
        private DCreater.ICE_IPCSDK_GetStatus _ICE_IPCSDK_GetStatus;
        private DCreater.ICE_IPCSDK_Reboot _ICE_IPCSDK_Reboot;
        private DCreater.ICE_IPCSDK_SyncTime _ICE_IPCSDK_SyncTime;
        private DCreater.ICE_IPCSDK_TransSerialPort _ICE_IPCSDK_TransSerialPort;
        private DCreater.ICE_IPCSDK_TransSerialPort_RS232 _ICE_IPCSDK_TransSerialPort_RS232;
        private DCreater.ICE_IPCSDK_GetDevID _ICE_IPCSDK_GetDevID;
        private DCreater.ICE_IPCSDK_StartRecord _ICE_IPCSDK_StartRecord;
        private DCreater.ICE_IPCSDK_StopRecord _ICE_IPCSDK_StopRecord;
        private DCreater.ICE_IPCSDK_SetOSDCfg _ICE_IPCSDK_SetOSDCfg;
        private DCreater.ICE_IPCSDK_WriteUserData _ICE_IPCSDK_WriteUserData;
        private DCreater.ICE_IPCSDK_ReadUserData _ICE_IPCSDK_ReadUserData;
        private DCreater.ICE_IPCSDK_WriteUserData_Binary _ICE_IPCSDK_WriteUserData_Binary;
        private DCreater.ICE_IPCSDK_ReadUserData_Binary _ICE_IPCSDK_ReadUserData_Binary;
        private DCreater.ICE_IPCSDK_GetIPAddr _ICE_IPCSDK_GetIPAddr;
        private DCreater.ICE_IPCSDK_SetIPAddr _ICE_IPCSDK_SetIPAddr;
        private DCreater.ICE_IPCSDK_SearchDev _ICE_IPCSDK_SearchDev;
        private DCreater.ICE_IPCSDK_LogConfig _ICE_IPCSDK_LogConfig;
        private DCreater.ICE_IPCSDK_Broadcast _ICE_IPCSDK_Broadcast;
        private DCreater.ICE_IPCSDK_BroadcastGroup _ICE_IPCSDK_BroadcastGroup;
        private DCreater.ICE_IPCSDK_SetCity _ICE_IPCSDK_SetCity;
        private DCreater.ICE_IPCSDK_VBR_CompareFeat _ICE_IPCSDK_VBR_CompareFeat;
        private DCreater.ICE_IPCSDK_SetLoop _ICE_IPCSDK_SetLoop;
        private DCreater.ICE_IPCSDK_GetLoop _ICE_IPCSDK_GetLoop;
        private DCreater.ICE_IPCSDK_SetTriggerMode _ICE_IPCSDK_SetTriggerMode;
        private DCreater.ICE_IPCSDK_GetTriggerMode _ICE_IPCSDK_GetTriggerMode;
        private DCreater.ICE_IPCSDK_GetCameraInfo _ICE_IPCSDK_GetCameraInfo;
        private DCreater.ICE_IPCSDK_GetUARTCfg _ICE_IPCSDK_GetUARTCfg;
        private DCreater.ICE_IPCSDK_SetUARTCfg _ICE_IPCSDK_SetUARTCfg;
        private DCreater.ICE_IPCSDK_GetIOState _ICE_IPCSDK_GetIOState;
        private DCreater.ICE_IPCSDK_getOfflineVehicleInfo _ICE_IPCSDK_getOfflineVehicleInfo;
        private DCreater.ICE_IPCSDK_getPayInfo _ICE_IPCSDK_getPayInfo;
        private DCreater.ICE_IPCSDK_SetIOEventCallBack _ICE_IPCSDK_SetIOEventCallBack;
        private DCreater.ICE_IPCSDK_SetVehicleBrand _ICE_IPCSDK_SetVehicleBrand;
        private DCreater.ICE_IPCSDK_GetVehicleBrand _ICE_IPCSDK_GetVehicleBrand;
        private DCreater.ICE_IPCSDK_SetLedCreen_Config _ICE_IPCSDK_SetLedCreen_Config;
        private DCreater.ICE_IPCSDK_GetLedCreen_Config _ICE_IPCSDK_GetLedCreen_Config;
        private DCreater.ICE_IPCSDK_SetLicense _ICE_IPCSDK_SetLicense;
        private DCreater.ICE_IPCSDK_CheckLicense _ICE_IPCSDK_CheckLicense;
        private DCreater.ICE_IPCSDK_EnableEnc _ICE_IPCSDK_EnableEnc;
        private DCreater.ICE_IPCSDK_ModifyEncPwd _ICE_IPCSDK_ModifyEncPwd;
        private DCreater.ICE_IPCSDK_SetDecPwd _ICE_IPCSDK_SetDecPwd;
        private DCreater.ICE_IPCSDK_BroadcastWav _ICE_IPCSDK_BroadcastWav;
        private DCreater.ICE_IPCSDK_UpdateWhiteListBatch _ICE_IPCSDK_UpdateWhiteListBatch;
        private DCreater.ICE_IPCSDK_GetSnapOsdCfg _ICE_IPCSDK_GetSnapOsdCfg;
        private DCreater.ICE_IPCSDK_SetSnapOsdCfg _ICE_IPCSDK_SetSnapOsdCfg;
        #endregion
        /// <summary>
        /// 构造
        /// </summary>
        public IceIpcSdkLoader()
        {
            hModule = LoadLibraryEx(DllFullName, IntPtr.Zero, LoadLibraryFlags.LOAD_WITH_ALTERED_SEARCH_PATH);
            _ICE_IPCSDK_Init = GetDelegate<DCreater.ICE_IPCSDK_Init>(nameof(DCreater.ICE_IPCSDK_Init));
            _ICE_IPCSDK_Fini = GetDelegate<DCreater.ICE_IPCSDK_Fini>(nameof(DCreater.ICE_IPCSDK_Fini));

            _ICE_IPCSDK_SetPlateCallback = GetDelegate<DCreater.ICE_IPCSDK_SetPlateCallback>(nameof(DCreater.ICE_IPCSDK_SetPlateCallback));
            _ICE_IPCSDK_SetPastPlateCallBack = GetDelegate<DCreater.ICE_IPCSDK_SetPastPlateCallBack>(nameof(DCreater.ICE_IPCSDK_SetPastPlateCallBack));
            _ICE_IPCSDK_SetSerialPortCallBack = GetDelegate<DCreater.ICE_IPCSDK_SetSerialPortCallBack>(nameof(DCreater.ICE_IPCSDK_SetSerialPortCallBack));
            _ICE_IPCSDK_SetSerialPortCallBack_RS232 = GetDelegate<DCreater.ICE_IPCSDK_SetSerialPortCallBack_RS232>(nameof(DCreater.ICE_IPCSDK_SetSerialPortCallBack_RS232));
            _ICE_IPCSDK_SetDeviceEventCallBack = GetDelegate<DCreater.ICE_IPCSDK_SetDeviceEventCallBack>(nameof(DCreater.ICE_IPCSDK_SetDeviceEventCallBack));
            _ICE_IPCSDK_SetTalkEventCallBack = GetDelegate<DCreater.ICE_IPCSDK_SetTalkEventCallBack>(nameof(DCreater.ICE_IPCSDK_SetTalkEventCallBack));
            _ICE_IPCSDK_SetFrameCallback = GetDelegate<DCreater.ICE_IPCSDK_SetFrameCallback>(nameof(DCreater.ICE_IPCSDK_SetFrameCallback));
            _ICE_IPCSDK_OpenPreview = GetDelegate<DCreater.ICE_IPCSDK_OpenPreview>(nameof(DCreater.ICE_IPCSDK_OpenPreview));
            _ICE_IPCSDK_OpenPreview_Passwd = GetDelegate<DCreater.ICE_IPCSDK_OpenPreview_Passwd>(nameof(DCreater.ICE_IPCSDK_OpenPreview_Passwd));
            _ICE_IPCSDK_OpenDevice = GetDelegate<DCreater.ICE_IPCSDK_OpenDevice>(nameof(DCreater.ICE_IPCSDK_OpenDevice));
            _ICE_IPCSDK_OpenDevice_Passwd = GetDelegate<DCreater.ICE_IPCSDK_OpenDevice_Passwd>(nameof(DCreater.ICE_IPCSDK_OpenDevice_Passwd));
            _ICE_IPCSDK_Open = GetDelegate<DCreater.ICE_IPCSDK_Open>(nameof(DCreater.ICE_IPCSDK_Open));
            _ICE_IPCSDK_Open_Passwd = GetDelegate<DCreater.ICE_IPCSDK_Open_Passwd>(nameof(DCreater.ICE_IPCSDK_Open_Passwd));
            _ICE_IPCSDK_Close = GetDelegate<DCreater.ICE_IPCSDK_Close>(nameof(DCreater.ICE_IPCSDK_Close));
            _ICE_IPCSDK_StartStream = GetDelegate<DCreater.ICE_IPCSDK_StartStream>(nameof(DCreater.ICE_IPCSDK_StartStream));
            _ICE_IPCSDK_StopStream = GetDelegate<DCreater.ICE_IPCSDK_StopStream>(nameof(DCreater.ICE_IPCSDK_StopStream));
            _ICE_IPCSDK_OpenGate = GetDelegate<DCreater.ICE_IPCSDK_OpenGate>(nameof(DCreater.ICE_IPCSDK_OpenGate));
            _ICE_IPCSDK_ControlAlarmOut = GetDelegate<DCreater.ICE_IPCSDK_ControlAlarmOut>(nameof(DCreater.ICE_IPCSDK_ControlAlarmOut));
            _ICE_IPCSDK_GetAlarmOutConfig = GetDelegate<DCreater.ICE_IPCSDK_GetAlarmOutConfig>(nameof(DCreater.ICE_IPCSDK_GetAlarmOutConfig));
            _ICE_IPCSDK_SetAlarmOutConfig = GetDelegate<DCreater.ICE_IPCSDK_SetAlarmOutConfig>(nameof(DCreater.ICE_IPCSDK_SetAlarmOutConfig));
            _ICE_IPCSDK_BeginTalk = GetDelegate<DCreater.ICE_IPCSDK_BeginTalk>(nameof(DCreater.ICE_IPCSDK_BeginTalk));
            _ICE_IPCSDK_EndTalk = GetDelegate<DCreater.ICE_IPCSDK_EndTalk>(nameof(DCreater.ICE_IPCSDK_EndTalk));
            _ICE_IPCSDK_Trigger = GetDelegate<DCreater.ICE_IPCSDK_Trigger>(nameof(DCreater.ICE_IPCSDK_Trigger));
            _ICE_IPCSDK_TriggerExt = GetDelegate<DCreater.ICE_IPCSDK_TriggerExt>(nameof(DCreater.ICE_IPCSDK_TriggerExt));
            _ICE_IPCSDK_Capture = GetDelegate<DCreater.ICE_IPCSDK_Capture>(nameof(DCreater.ICE_IPCSDK_Capture));
            _ICE_IPCSDK_GetStatus = GetDelegate<DCreater.ICE_IPCSDK_GetStatus>(nameof(DCreater.ICE_IPCSDK_GetStatus));
            _ICE_IPCSDK_Reboot = GetDelegate<DCreater.ICE_IPCSDK_Reboot>(nameof(DCreater.ICE_IPCSDK_Reboot));
            _ICE_IPCSDK_SyncTime = GetDelegate<DCreater.ICE_IPCSDK_SyncTime>(nameof(DCreater.ICE_IPCSDK_SyncTime));
            _ICE_IPCSDK_TransSerialPort = GetDelegate<DCreater.ICE_IPCSDK_TransSerialPort>(nameof(DCreater.ICE_IPCSDK_TransSerialPort));
            _ICE_IPCSDK_TransSerialPort_RS232 = GetDelegate<DCreater.ICE_IPCSDK_TransSerialPort_RS232>(nameof(DCreater.ICE_IPCSDK_TransSerialPort_RS232));
            _ICE_IPCSDK_GetDevID = GetDelegate<DCreater.ICE_IPCSDK_GetDevID>(nameof(DCreater.ICE_IPCSDK_GetDevID));
            _ICE_IPCSDK_StartRecord = GetDelegate<DCreater.ICE_IPCSDK_StartRecord>(nameof(DCreater.ICE_IPCSDK_StartRecord));
            _ICE_IPCSDK_StopRecord = GetDelegate<DCreater.ICE_IPCSDK_StopRecord>(nameof(DCreater.ICE_IPCSDK_StopRecord));
            _ICE_IPCSDK_SetOSDCfg = GetDelegate<DCreater.ICE_IPCSDK_SetOSDCfg>(nameof(DCreater.ICE_IPCSDK_SetOSDCfg));
            _ICE_IPCSDK_WriteUserData = GetDelegate<DCreater.ICE_IPCSDK_WriteUserData>(nameof(DCreater.ICE_IPCSDK_WriteUserData));
            _ICE_IPCSDK_ReadUserData = GetDelegate<DCreater.ICE_IPCSDK_ReadUserData>(nameof(DCreater.ICE_IPCSDK_ReadUserData));
            _ICE_IPCSDK_WriteUserData_Binary = GetDelegate<DCreater.ICE_IPCSDK_WriteUserData_Binary>(nameof(DCreater.ICE_IPCSDK_WriteUserData_Binary));
            _ICE_IPCSDK_ReadUserData_Binary = GetDelegate<DCreater.ICE_IPCSDK_ReadUserData_Binary>(nameof(DCreater.ICE_IPCSDK_ReadUserData_Binary));
            _ICE_IPCSDK_GetIPAddr = GetDelegate<DCreater.ICE_IPCSDK_GetIPAddr>(nameof(DCreater.ICE_IPCSDK_GetIPAddr));
            _ICE_IPCSDK_SetIPAddr = GetDelegate<DCreater.ICE_IPCSDK_SetIPAddr>(nameof(DCreater.ICE_IPCSDK_SetIPAddr));
            _ICE_IPCSDK_SearchDev = GetDelegate<DCreater.ICE_IPCSDK_SearchDev>(nameof(DCreater.ICE_IPCSDK_SearchDev));
            _ICE_IPCSDK_LogConfig = GetDelegate<DCreater.ICE_IPCSDK_LogConfig>(nameof(DCreater.ICE_IPCSDK_LogConfig));
            _ICE_IPCSDK_Broadcast = GetDelegate<DCreater.ICE_IPCSDK_Broadcast>(nameof(DCreater.ICE_IPCSDK_Broadcast));
            _ICE_IPCSDK_BroadcastGroup = GetDelegate<DCreater.ICE_IPCSDK_BroadcastGroup>(nameof(DCreater.ICE_IPCSDK_BroadcastGroup));
            _ICE_IPCSDK_SetCity = GetDelegate<DCreater.ICE_IPCSDK_SetCity>(nameof(DCreater.ICE_IPCSDK_SetCity));
            _ICE_IPCSDK_VBR_CompareFeat = GetDelegate<DCreater.ICE_IPCSDK_VBR_CompareFeat>(nameof(DCreater.ICE_IPCSDK_VBR_CompareFeat));
            _ICE_IPCSDK_SetLoop = GetDelegate<DCreater.ICE_IPCSDK_SetLoop>(nameof(DCreater.ICE_IPCSDK_SetLoop));
            _ICE_IPCSDK_GetLoop = GetDelegate<DCreater.ICE_IPCSDK_GetLoop>(nameof(DCreater.ICE_IPCSDK_GetLoop));
            _ICE_IPCSDK_SetTriggerMode = GetDelegate<DCreater.ICE_IPCSDK_SetTriggerMode>(nameof(DCreater.ICE_IPCSDK_SetTriggerMode));
            _ICE_IPCSDK_GetTriggerMode = GetDelegate<DCreater.ICE_IPCSDK_GetTriggerMode>(nameof(DCreater.ICE_IPCSDK_GetTriggerMode));
            _ICE_IPCSDK_GetCameraInfo = GetDelegate<DCreater.ICE_IPCSDK_GetCameraInfo>(nameof(DCreater.ICE_IPCSDK_GetCameraInfo));
            _ICE_IPCSDK_GetUARTCfg = GetDelegate<DCreater.ICE_IPCSDK_GetUARTCfg>(nameof(DCreater.ICE_IPCSDK_GetUARTCfg));
            _ICE_IPCSDK_SetUARTCfg = GetDelegate<DCreater.ICE_IPCSDK_SetUARTCfg>(nameof(DCreater.ICE_IPCSDK_SetUARTCfg));
            _ICE_IPCSDK_GetIOState = GetDelegate<DCreater.ICE_IPCSDK_GetIOState>(nameof(DCreater.ICE_IPCSDK_GetIOState));
            _ICE_IPCSDK_getOfflineVehicleInfo = GetDelegate<DCreater.ICE_IPCSDK_getOfflineVehicleInfo>(nameof(DCreater.ICE_IPCSDK_getOfflineVehicleInfo));
            _ICE_IPCSDK_getPayInfo = GetDelegate<DCreater.ICE_IPCSDK_getPayInfo>(nameof(DCreater.ICE_IPCSDK_getPayInfo));
            _ICE_IPCSDK_SetIOEventCallBack = GetDelegate<DCreater.ICE_IPCSDK_SetIOEventCallBack>(nameof(DCreater.ICE_IPCSDK_SetIOEventCallBack));
            _ICE_IPCSDK_SetVehicleBrand = GetDelegate<DCreater.ICE_IPCSDK_SetVehicleBrand>(nameof(DCreater.ICE_IPCSDK_SetVehicleBrand));
            _ICE_IPCSDK_GetVehicleBrand = GetDelegate<DCreater.ICE_IPCSDK_GetVehicleBrand>(nameof(DCreater.ICE_IPCSDK_GetVehicleBrand));
            _ICE_IPCSDK_SetLedCreen_Config = GetDelegate<DCreater.ICE_IPCSDK_SetLedCreen_Config>(nameof(DCreater.ICE_IPCSDK_SetLedCreen_Config));
            _ICE_IPCSDK_GetLedCreen_Config = GetDelegate<DCreater.ICE_IPCSDK_GetLedCreen_Config>(nameof(DCreater.ICE_IPCSDK_GetLedCreen_Config));
            _ICE_IPCSDK_SetLicense = GetDelegate<DCreater.ICE_IPCSDK_SetLicense>(nameof(DCreater.ICE_IPCSDK_SetLicense));
            _ICE_IPCSDK_CheckLicense = GetDelegate<DCreater.ICE_IPCSDK_CheckLicense>(nameof(DCreater.ICE_IPCSDK_CheckLicense));
            _ICE_IPCSDK_EnableEnc = GetDelegate<DCreater.ICE_IPCSDK_EnableEnc>(nameof(DCreater.ICE_IPCSDK_EnableEnc));
            _ICE_IPCSDK_ModifyEncPwd = GetDelegate<DCreater.ICE_IPCSDK_ModifyEncPwd>(nameof(DCreater.ICE_IPCSDK_ModifyEncPwd));
            _ICE_IPCSDK_SetDecPwd = GetDelegate<DCreater.ICE_IPCSDK_SetDecPwd>(nameof(DCreater.ICE_IPCSDK_SetDecPwd));
            _ICE_IPCSDK_BroadcastWav = GetDelegate<DCreater.ICE_IPCSDK_BroadcastWav>(nameof(DCreater.ICE_IPCSDK_BroadcastWav));
            _ICE_IPCSDK_UpdateWhiteListBatch = GetDelegate<DCreater.ICE_IPCSDK_UpdateWhiteListBatch>(nameof(DCreater.ICE_IPCSDK_UpdateWhiteListBatch));
            _ICE_IPCSDK_GetSnapOsdCfg = GetDelegate<DCreater.ICE_IPCSDK_GetSnapOsdCfg>(nameof(DCreater.ICE_IPCSDK_GetSnapOsdCfg));
            _ICE_IPCSDK_SetSnapOsdCfg = GetDelegate<DCreater.ICE_IPCSDK_SetSnapOsdCfg>(nameof(DCreater.ICE_IPCSDK_SetSnapOsdCfg));
        }
        #region // 动态内容
        [DllImport("kernel32.dll")]
        private static extern uint GetLastError();
        /// <summary>
        /// API LoadLibraryEx
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="hReservedNull"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryEx", SetLastError = true)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr LoadLibrary(string lpFileName, int h, int flags);
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lProcName);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool FreeLibrary(IntPtr hModule);
        IntPtr hModule;
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            FreeLibrary(hModule);
        }
        public Delegate GetMethod(string procName, Type type)
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(func, type);
        }
        public T GetDelegate<T>(string procName) where T : Delegate
        {
            IntPtr func = GetProcAddress(hModule, procName);
            return (T)Marshal.GetDelegateForFunctionPointer(func, typeof(T));
        }
        /// <summary>
        /// LoadLibraryFlags
        /// </summary>
        public enum LoadLibraryFlags : uint
        {
            /// <summary>
            /// DONT_RESOLVE_DLL_REFERENCES
            /// </summary>
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,

            /// <summary>
            /// LOAD_IGNORE_CODE_AUTHZ_LEVEL
            /// </summary>
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,

            /// <summary>
            /// LOAD_LIBRARY_AS_DATAFILE
            /// </summary>
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,

            /// <summary>
            /// LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE
            /// </summary>
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,

            /// <summary>
            /// LOAD_LIBRARY_AS_IMAGE_RESOURCE
            /// </summary>
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_APPLICATION_DIR
            /// </summary>
            LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_DEFAULT_DIRS
            /// </summary>
            LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR
            /// </summary>
            LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_SYSTEM32
            /// </summary>
            LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,

            /// <summary>
            /// LOAD_LIBRARY_SEARCH_USER_DIRS
            /// </summary>
            LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,

            /// <summary>
            /// LOAD_WITH_ALTERED_SEARCH_PATH
            /// </summary>
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
        }
        #endregion
        #region // 显示实现接口
        uint IIceIpcSdkProxy.ICE_IPCSDK_BeginTalk(IntPtr hSDK) => _ICE_IPCSDK_BeginTalk.Invoke(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex) => _ICE_IPCSDK_Broadcast.Invoke(hSDK, nIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastGroup(IntPtr hSDK, string pcIndex) => _ICE_IPCSDK_BroadcastGroup.Invoke(hSDK, pcIndex);
        uint IIceIpcSdkProxy.ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len) => _ICE_IPCSDK_BroadcastWav.Invoke(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => _ICE_IPCSDK_Capture.Invoke(hSDK, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license) => _ICE_IPCSDK_CheckLicense.Invoke(hSDK, license);
        void IIceIpcSdkProxy.ICE_IPCSDK_Close(IntPtr hSDK) => _ICE_IPCSDK_Close.Invoke(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index) => _ICE_IPCSDK_ControlAlarmOut.Invoke(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd) => _ICE_IPCSDK_EnableEnc.Invoke(hSDK, u32EncId, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_EndTalk(IntPtr hSDK) => _ICE_IPCSDK_EndTalk.Invoke(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_Fini() => _ICE_IPCSDK_Fini.Invoke();
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState, ref uint pu32DelayTime, ref uint pu32Reserve) => _ICE_IPCSDK_GetAlarmOutConfig.Invoke(hSDK, u32Index, ref pu32IdleState, ref pu32DelayTime, ref pu32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo) => _ICE_IPCSDK_GetCameraInfo.Invoke(hSDK, ref pstCameraInfo);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID) => _ICE_IPCSDK_GetDevID.Invoke(hSDK, szDevID);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2) => _ICE_IPCSDK_GetIOState.Invoke(hSDK, u32Index, ref pu32IOState, ref pu32Reserve1, ref pu32Reserve2);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway) => _ICE_IPCSDK_GetIPAddr.Invoke(hSDK, ref pu32IP, ref pu32Mask, ref pu32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => _ICE_IPCSDK_GetLedCreen_Config.Invoke(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight) => _ICE_IPCSDK_GetLoop.Invoke(hSDK, ref nLeft, ref nBottom, ref nRight, ref nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen) => _ICE_IPCSDK_getOfflineVehicleInfo.Invoke(hSDK, pcVehicleInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen) => _ICE_IPCSDK_getPayInfo.Invoke(hSDK, pcPayInfo, u32InfoSize, ref pu32InfoLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => _ICE_IPCSDK_GetSnapOsdCfg.Invoke(hSDK, ref pstParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetStatus(IntPtr hSDK) => _ICE_IPCSDK_GetStatus.Invoke(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode) => _ICE_IPCSDK_GetTriggerMode.Invoke(hSDK, ref pu32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => _ICE_IPCSDK_GetUARTCfg.Invoke(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand) => _ICE_IPCSDK_GetVehicleBrand.Invoke(hSDK, ref s32FilterByPlate, ref s32EnableNoPlateVehicleBrand, ref s32EnableVehicleBrand);
        void IIceIpcSdkProxy.ICE_IPCSDK_Init() => _ICE_IPCSDK_Init.Invoke();
        void IIceIpcSdkProxy.ICE_IPCSDK_LogConfig(int openLog, string logPath) => _ICE_IPCSDK_LogConfig.Invoke(openLog, logPath);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd) => _ICE_IPCSDK_ModifyEncPwd.Invoke(hSDK, szOldPwd, szNewPwd);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open(string pcIP, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => _ICE_IPCSDK_Open.Invoke(pcIP, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice(string pcIP) => _ICE_IPCSDK_OpenDevice.Invoke(pcIP);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenDevice_Passwd(string pcIP, string pcPasswd) => _ICE_IPCSDK_OpenDevice_Passwd.Invoke(pcIP, pcPasswd);
        uint IIceIpcSdkProxy.ICE_IPCSDK_OpenGate(IntPtr hSDK) => _ICE_IPCSDK_OpenGate.Invoke(hSDK);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview(string pcIP, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => _ICE_IPCSDK_OpenPreview.Invoke(pcIP, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_OpenPreview_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam) => _ICE_IPCSDK_OpenPreview_Passwd.Invoke(pcIP, pcPasswd, u8OverTCP, u8MainStream, hWnd, pfOnPlate, pvPlateParam);
        IntPtr IIceIpcSdkProxy.ICE_IPCSDK_Open_Passwd(string pcIP, string pcPasswd, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam) => _ICE_IPCSDK_Open_Passwd.Invoke(pcIP, pcPasswd, u8OverTCP, u16RTSPPort, u16ICEPort, u16OnvifPort, u8MainStream, pfOnStream, pvStreamParam, pfOnFrame, pvFrameParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize) => _ICE_IPCSDK_ReadUserData.Invoke(hSDK, pcData, nSize);
        uint IIceIpcSdkProxy.ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData, uint nSize, uint nOffset, uint nLen) => _ICE_IPCSDK_ReadUserData_Binary.Invoke(hSDK, pcData, nSize, nOffset, nLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Reboot(IntPtr hSDK) => _ICE_IPCSDK_Reboot.Invoke(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_SearchDev(StringBuilder szDevs) => _ICE_IPCSDK_SearchDev.Invoke(szDevs);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState, uint u32DelayTime, uint u32Reserve) => _ICE_IPCSDK_SetAlarmOutConfig.Invoke(hSDK, u32Index, u32IdleState, u32DelayTime, u32Reserve);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index) => _ICE_IPCSDK_SetCity.Invoke(hSDK, u32Index);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd) => _ICE_IPCSDK_SetDecPwd.Invoke(hSDK, szPwd);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam) => _ICE_IPCSDK_SetDeviceEventCallBack.Invoke(hSDK, pfOnDeviceEvent, pvDeviceEventParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam) => _ICE_IPCSDK_SetFrameCallback.Invoke(hSDK, pfOnFrame, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam) => _ICE_IPCSDK_SetIOEventCallBack.Invoke(hSDK, pfOnIOEvent, pvIOEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway) => _ICE_IPCSDK_SetIPAddr.Invoke(hSDK, u32IP, u32Mask, u32Gateway);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig) => _ICE_IPCSDK_SetLedCreen_Config.Invoke(hSDK, ref ledConfig);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics) => _ICE_IPCSDK_SetLicense.Invoke(hSDK, old_lics, new_lics);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight) => _ICE_IPCSDK_SetLoop.Invoke(hSDK, nLeft, nBottom, nRight, nTop, nWidth, nHeight);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr) => _ICE_IPCSDK_SetOSDCfg.Invoke(hSDK, ref pstOSDAttr);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate, IntPtr pvPastPlateParam) => _ICE_IPCSDK_SetPastPlateCallBack.Invoke(hSDK, pfOnPastPlate, pvPastPlateParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam) => _ICE_IPCSDK_SetPlateCallback.Invoke(hSDK, pfOnPlate, pvParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort, IntPtr pvSerialPortParam) => _ICE_IPCSDK_SetSerialPortCallBack.Invoke(hSDK, pfOnSerialPort, pvSerialPortParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort, IntPtr pvSerialPortParam) => _ICE_IPCSDK_SetSerialPortCallBack_RS232.Invoke(hSDK, pfOnSerialPort, pvSerialPortParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam) => _ICE_IPCSDK_SetSnapOsdCfg.Invoke(hSDK, ref pstParam);
        void IIceIpcSdkProxy.ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam) => _ICE_IPCSDK_SetTalkEventCallBack.Invoke(hSDK, pfOnTalkEvent, pvTalkEventParam);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode) => _ICE_IPCSDK_SetTriggerMode.Invoke(hSDK, u32TriggerMode);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg) => _ICE_IPCSDK_SetUARTCfg.Invoke(hSDK, ref pstUARTCfg);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand) => _ICE_IPCSDK_SetVehicleBrand.Invoke(hSDK, s32FilterByPlate, s32EnableNoPlateVehicleBrand, s32EnableVehicleBrand);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartRecord(IntPtr hSDK, string pcFileName) => _ICE_IPCSDK_StartRecord.Invoke(hSDK, pcFileName);
        uint IIceIpcSdkProxy.ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd) => _ICE_IPCSDK_StartStream.Invoke(hSDK, u8MainStream, hWnd);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopRecord(IntPtr hSDK) => _ICE_IPCSDK_StopRecord.Invoke(hSDK);
        void IIceIpcSdkProxy.ICE_IPCSDK_StopStream(IntPtr hSDK) => _ICE_IPCSDK_StopStream.Invoke(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day, byte u8Hour, byte u8Min, byte u8Sec) => _ICE_IPCSDK_SyncTime.Invoke(hSDK, u16Year, u8Month, u8Day, u8Hour, u8Min, u8Sec);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len) => _ICE_IPCSDK_TransSerialPort.Invoke(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len) => _ICE_IPCSDK_TransSerialPort_RS232.Invoke(hSDK, pcData, u32Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen) => _ICE_IPCSDK_Trigger.Invoke(hSDK, pcNumber, pcColor, pcPicData, u32PicSize, ref pu32PicLen);
        uint IIceIpcSdkProxy.ICE_IPCSDK_TriggerExt(IntPtr hSDK) => _ICE_IPCSDK_TriggerExt.Invoke(hSDK);
        uint IIceIpcSdkProxy.ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, string szFilePath, int s32Type) => _ICE_IPCSDK_UpdateWhiteListBatch.Invoke(hSDK, szFilePath, s32Type);
        float IIceIpcSdkProxy.ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len, float[] _pfReaFeat2, uint _iFeat2Len) => _ICE_IPCSDK_VBR_CompareFeat.Invoke(_pfResFeat1, _iFeat1Len, _pfReaFeat2, _iFeat2Len);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData(IntPtr hSDK, string pcData) => _ICE_IPCSDK_WriteUserData.Invoke(hSDK, pcData);
        uint IIceIpcSdkProxy.ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK, string pcData, uint nOffset, uint nLen) => _ICE_IPCSDK_WriteUserData_Binary.Invoke(hSDK, pcData, nOffset, nLen);
        #endregion
        #region // 创建者
        public class DCreater
        {
            internal delegate void ICE_IPCSDK_SetPlateCallback(IntPtr hSDK, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvParam);
            internal delegate void ICE_IPCSDK_SetPastPlateCallBack(IntPtr hSDK, ICE_IPCSDK_OnPastPlate pfOnPastPlate, IntPtr pvPastPlateParam);
            internal delegate void ICE_IPCSDK_SetSerialPortCallBack(IntPtr hSDK, ICE_IPCSDK_OnSerialPort pfOnSerialPort, IntPtr pvSerialPortParam);
            internal delegate void ICE_IPCSDK_SetSerialPortCallBack_RS232(IntPtr hSDK, ICE_IPCSDK_OnSerialPort_RS232 pfOnSerialPort, IntPtr pvSerialPortParam);
            internal delegate void ICE_IPCSDK_SetDeviceEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnDeviceEvent pfOnDeviceEvent, IntPtr pvDeviceEventParam);
            internal delegate void ICE_IPCSDK_SetTalkEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnTalkEvent pfOnTalkEvent, IntPtr pvTalkEventParam);
            internal delegate void ICE_IPCSDK_SetFrameCallback(IntPtr hSDK, ICE_IPCSDK_OnFrame_Planar pfOnFrame, IntPtr pvParam);
            internal delegate void ICE_IPCSDK_Init();
            internal delegate void ICE_IPCSDK_Fini();
            internal delegate IntPtr ICE_IPCSDK_OpenPreview([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);
            internal delegate IntPtr ICE_IPCSDK_OpenPreview_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, [MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd, byte u8OverTCP, byte u8MainStream, uint hWnd, ICE_IPCSDK_OnPlate pfOnPlate, IntPtr pvPlateParam);
            internal delegate IntPtr ICE_IPCSDK_OpenDevice([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP);
            internal delegate IntPtr ICE_IPCSDK_OpenDevice_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd);
            internal delegate IntPtr ICE_IPCSDK_Open([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);
            internal delegate IntPtr ICE_IPCSDK_Open_Passwd([InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIP, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcPasswd, byte u8OverTCP, ushort u16RTSPPort, ushort u16ICEPort, ushort u16OnvifPort, byte u8MainStream, uint pfOnStream, IntPtr pvStreamParam, uint pfOnFrame, IntPtr pvFrameParam);
            internal delegate void ICE_IPCSDK_Close(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_StartStream(IntPtr hSDK, byte u8MainStream, uint hWnd);
            internal delegate void ICE_IPCSDK_StopStream(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_OpenGate(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_ControlAlarmOut(IntPtr hSDK, uint u32Index);
            internal delegate uint ICE_IPCSDK_GetAlarmOutConfig(IntPtr hSDK, uint u32Index, ref uint pu32IdleState, ref uint pu32DelayTime, ref uint pu32Reserve);
            internal delegate uint ICE_IPCSDK_SetAlarmOutConfig(IntPtr hSDK, uint u32Index, uint u32IdleState, uint u32DelayTime, uint u32Reserve);
            internal delegate uint ICE_IPCSDK_BeginTalk(IntPtr hSDK);
            internal delegate void ICE_IPCSDK_EndTalk(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_Trigger(IntPtr hSDK, StringBuilder pcNumber, StringBuilder pcColor, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);
            internal delegate uint ICE_IPCSDK_TriggerExt(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_Capture(IntPtr hSDK, byte[] pcPicData, uint u32PicSize, ref uint pu32PicLen);
            internal delegate uint ICE_IPCSDK_GetStatus(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_Reboot(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_SyncTime(IntPtr hSDK, ushort u16Year, byte u8Month, byte u8Day, byte u8Hour, byte u8Min, byte u8Sec);
            internal delegate uint ICE_IPCSDK_TransSerialPort(IntPtr hSDK, byte[] pcData, uint u32Len);
            internal delegate uint ICE_IPCSDK_TransSerialPort_RS232(IntPtr hSDK, byte[] pcData, uint u32Len);
            internal delegate uint ICE_IPCSDK_GetDevID(IntPtr hSDK, StringBuilder szDevID);
            internal delegate uint ICE_IPCSDK_StartRecord(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcFileName);
            internal delegate void ICE_IPCSDK_StopRecord(IntPtr hSDK);
            internal delegate uint ICE_IPCSDK_SetOSDCfg(IntPtr hSDK, ref ICE_OSDAttr_S pstOSDAttr);
            internal delegate uint ICE_IPCSDK_WriteUserData(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData);
            internal delegate uint ICE_IPCSDK_ReadUserData(IntPtr hSDK, byte[] pcData, int nSize);
            internal delegate uint ICE_IPCSDK_WriteUserData_Binary(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcData, uint nOffset, uint nLen);
            internal delegate uint ICE_IPCSDK_ReadUserData_Binary(IntPtr hSDK, byte[] pcData, uint nSize, uint nOffset, uint nLen);
            internal delegate uint ICE_IPCSDK_GetIPAddr(IntPtr hSDK, ref uint pu32IP, ref uint pu32Mask, ref uint pu32Gateway);
            internal delegate uint ICE_IPCSDK_SetIPAddr(IntPtr hSDK, uint u32IP, uint u32Mask, uint u32Gateway);
            internal delegate void ICE_IPCSDK_SearchDev(StringBuilder szDevs);
            internal delegate void ICE_IPCSDK_LogConfig(int openLog, string logPath);
            internal delegate uint ICE_IPCSDK_Broadcast(IntPtr hSDK, ushort nIndex);
            internal delegate uint ICE_IPCSDK_BroadcastGroup(IntPtr hSDK, [InAttribute()][MarshalAsAttribute(UnmanagedType.LPStr)] string pcIndex);
            internal delegate uint ICE_IPCSDK_SetCity(IntPtr hSDK, uint u32Index);
            internal delegate float ICE_IPCSDK_VBR_CompareFeat(float[] _pfResFeat1, uint _iFeat1Len, float[] _pfReaFeat2, uint _iFeat2Len);
            internal delegate uint ICE_IPCSDK_SetLoop(IntPtr hSDK, uint nLeft, uint nBottom, uint nRight, uint nTop, uint nWidth, uint nHeight);
            internal delegate uint ICE_IPCSDK_GetLoop(IntPtr hSDK, ref uint nLeft, ref uint nBottom, ref uint nRight, ref uint nTop, uint nWidth, uint nHeight);
            internal delegate uint ICE_IPCSDK_SetTriggerMode(IntPtr hSDK, uint u32TriggerMode);
            internal delegate uint ICE_IPCSDK_GetTriggerMode(IntPtr hSDK, ref uint pu32TriggerMode);
            internal delegate uint ICE_IPCSDK_GetCameraInfo(IntPtr hSDK, ref ICE_CameraInfo pstCameraInfo);
            internal delegate uint ICE_IPCSDK_GetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);
            internal delegate uint ICE_IPCSDK_SetUARTCfg(IntPtr hSDK, ref ICE_UART_PARAM pstUARTCfg);
            internal delegate uint ICE_IPCSDK_GetIOState(IntPtr hSDK, uint u32Index, ref uint pu32IOState, ref uint pu32Reserve1, ref uint pu32Reserve2);
            internal delegate uint ICE_IPCSDK_getOfflineVehicleInfo(IntPtr hSDK, byte[] pcVehicleInfo, uint u32InfoSize, ref uint pu32InfoLen);
            internal delegate uint ICE_IPCSDK_getPayInfo(IntPtr hSDK, byte[] pcPayInfo, uint u32InfoSize, ref uint pu32InfoLen);
            internal delegate void ICE_IPCSDK_SetIOEventCallBack(IntPtr hSDK, ICE_IPCSDK_OnIOEvent pfOnIOEvent, IntPtr pvIOEventParam);
            internal delegate uint ICE_IPCSDK_SetVehicleBrand(IntPtr hSDK, int s32FilterByPlate, int s32EnableNoPlateVehicleBrand, int s32EnableVehicleBrand);
            internal delegate uint ICE_IPCSDK_GetVehicleBrand(IntPtr hSDK, ref int s32FilterByPlate, ref int s32EnableNoPlateVehicleBrand, ref int s32EnableVehicleBrand);
            internal delegate uint ICE_IPCSDK_SetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);
            internal delegate uint ICE_IPCSDK_GetLedCreen_Config(IntPtr hSDK, ref ICE_OFFLINE_LED_CONFIG ledConfig);
            internal delegate uint ICE_IPCSDK_SetLicense(IntPtr hSDK, byte[] old_lics, byte[] new_lics);
            internal delegate uint ICE_IPCSDK_CheckLicense(IntPtr hSDK, byte[] license);
            internal delegate uint ICE_IPCSDK_EnableEnc(IntPtr hSDK, uint u32EncId, byte[] szPwd);
            internal delegate uint ICE_IPCSDK_ModifyEncPwd(IntPtr hSDK, byte[] szOldPwd, byte[] szNewPwd);
            internal delegate uint ICE_IPCSDK_SetDecPwd(IntPtr hSDK, byte[] szPwd);
            internal delegate uint ICE_IPCSDK_BroadcastWav(IntPtr hSDK, byte[] pcData, uint u32Len);
            internal delegate uint ICE_IPCSDK_UpdateWhiteListBatch(IntPtr hSDK, String szFilePath, int s32Type);
            internal delegate uint ICE_IPCSDK_GetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
            internal delegate uint ICE_IPCSDK_SetSnapOsdCfg(IntPtr hSDK, ref T_SnapOsdCfg pstParam);
        }
        #endregion
    }
    /// <summary>
    /// SDK调用
    /// </summary>
    public static class IceIpcSdk
    {
        static Lazy<IIceIpcSdkProxy> _iceIpcSdk = new Lazy<IIceIpcSdkProxy>(() => new IceIpcSdkLoader(), true);
        /// <summary>
        /// 静态构造
        /// </summary>
        static IceIpcSdk()
        {
            Directory.CreateDirectory(IceIpcSdkLoader.DllFullPath);
            if (Environment.Is64BitProcess)
            {
                bool isExists = CompareFile(IceIpcSdkLoader.DllFullName, Properties.Resources.X64_IceIpcSdk);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X64_IceIpcSdk, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_ipcsdk.dll"));
                    WriteFile(Properties.Resources.X64_Avutil52, Path.Combine(IceIpcSdkLoader.DllFullPath, "avutil-52.dll"));
                    WriteFile(Properties.Resources.X64_Draw, Path.Combine(IceIpcSdkLoader.DllFullPath, "draw.dll"));
                    WriteFile(Properties.Resources.X64_HiH264decW64, Path.Combine(IceIpcSdkLoader.DllFullPath, "hi_h264dec_w64.dll"));
                    WriteFile(Properties.Resources.X64_IceP2p, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_p2p.dll"));
                    WriteFile(Properties.Resources.X64_Packet, Path.Combine(IceIpcSdkLoader.DllFullPath, "Packet.dll"));
                    WriteFile(Properties.Resources.X64_Swscale2, Path.Combine(IceIpcSdkLoader.DllFullPath, "swscale-2.dll"));
                    WriteFile(Properties.Resources.X64_Wpcap, Path.Combine(IceIpcSdkLoader.DllFullPath, "wpcap.dll"));
                    WriteFile(Properties.Resources.X64_Zlibwapi, Path.Combine(IceIpcSdkLoader.DllFullPath, "zlibwapi.dll"));
                }
            }
            else
            {
                bool isExists = CompareFile(IceIpcSdkLoader.DllFullName, Properties.Resources.X86_IceIpcSdk);
                if (!isExists)
                {
                    WriteFile(Properties.Resources.X86_IceIpcSdk, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_ipcsdk.dll"));
                    WriteFile(Properties.Resources.X86_Avutil52, Path.Combine(IceIpcSdkLoader.DllFullPath, "avutil-52.dll"));
                    WriteFile(Properties.Resources.X86_Draw, Path.Combine(IceIpcSdkLoader.DllFullPath, "draw.dll"));
                    WriteFile(Properties.Resources.X86_HiH264decW, Path.Combine(IceIpcSdkLoader.DllFullPath, "hi_h264dec_w.dll"));
                    WriteFile(Properties.Resources.X86_IceP2p, Path.Combine(IceIpcSdkLoader.DllFullPath, "ice_p2p.dll"));
                    WriteFile(Properties.Resources.X86_Packet, Path.Combine(IceIpcSdkLoader.DllFullPath, "Packet.dll"));
                    WriteFile(Properties.Resources.X86_Swscale2, Path.Combine(IceIpcSdkLoader.DllFullPath, "swscale-2.dll"));
                    WriteFile(Properties.Resources.X86_Wpcap, Path.Combine(IceIpcSdkLoader.DllFullPath, "wpcap.dll"));
                    WriteFile(Properties.Resources.X86_Zlibwapi, Path.Combine(IceIpcSdkLoader.DllFullPath, "zlibwapi.dll"));
                }
            }
        }

        private static void WriteFile(byte[] dllFile, string fullName)
        {
            try
            {
                if (File.Exists(fullName)) { File.Delete(fullName); }
                File.WriteAllBytes(fullName, dllFile);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        private static bool CompareFile(string file, byte[] res)
        {
            if (!File.Exists(file)) { return false; }
            using (var hash = HashAlgorithm.Create())
            {
                using (var distFile = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var resHash = hash.ComputeHash(res);
                    var distHash = hash.ComputeHash(distFile);
                    if (resHash.Length != distHash.Length) { return false; }
                    for (int i = 0; i < resHash.Length; i++)
                    {
                        if (resHash[i] != distHash[i]) { return false; }
                    }
                    return true;
                }
            }
        }
        /// <summary>
        /// 创建SDK代理
        /// </summary>
        /// <param name="isBase"></param>
        /// <returns></returns>
        public static IIceIpcSdkProxy Create(bool isBase = false)
        {
            var currentDir = IceIpcDller.DllFullPath;
            var pluginDir = IceIpcSdkLoader.DllFullPath;
            if (isBase)
            {
                if (!File.Exists(IceIpcDller.DllFullName))
                {
                    if (Directory.Exists(pluginDir))
                    {
                        try
                        {
                            CopyDirectory(pluginDir, currentDir);
                        }
                        catch { }
                    }
                }
                return IceIpcDller.Instance;
            }
            if (!Directory.Exists(pluginDir)) { return IceIpcDller.Instance; }
            return _iceIpcSdk.Value;
        }
        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="src"></param>
        /// <param name="tag"></param>
        public static void CopyDirectory(string src, string tag)
        {
            foreach (var item in new DirectoryInfo(src).GetFileSystemInfos())
            {
                if (item is DirectoryInfo dir)
                {
                    var tagDir = Path.Combine(tag, dir.Name);
                    if (!Directory.Exists(tagDir)) { Directory.CreateDirectory(tagDir); }
                    CopyDirectory(dir.FullName, tagDir);
                    continue;
                }
                File.Copy(item.FullName, Path.Combine(tag, item.Name), false);
            }
        }
    }
}
