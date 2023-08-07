using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.OnbonLedBxSDK
{
    #region // Enums 枚举
    /// <summary>
    /// 
    /// </summary>
    public enum E_arrMode : int
    {
        /// <summary>
        /// 单行
        /// </summary>
        eSINGLELINE,
        /// <summary>
        /// 多行
        /// </summary>
        eMULTILINE,
    }
    /// <summary>
    /// 表盘样式
    /// </summary>
    public enum E_ClockStyle
    {
        /// <summary>
        /// 线形
        /// </summary>
        eLINE,
        /// <summary>
        /// 方形
        /// </summary>
        eSQUARE,
        /// <summary>
        /// 圆形
        /// </summary>
        eCIRCLE,
    }
    /// <summary>
    /// 5代时间区只支持四种颜色
    /// </summary>
    public enum E_Color_G56
    {
        /// <summary>
        /// 黑色
        /// </summary>
        eBLACK,
        /// <summary>
        /// 红色
        /// </summary>
        eRED,
        /// <summary>
        /// 绿色
        /// </summary>
        eGREEN,
        /// <summary>
        /// 黄色
        /// </summary>
        eYELLOW,
        /// <summary>
        /// 蓝色
        /// </summary>
        eBLUE,
        /// <summary>
        /// 品红/洋红
        /// </summary>
        eMAGENTA,
        /// <summary>
        /// 青色
        /// </summary>
        eCYAN,
        /// <summary>
        /// 白色
        /// </summary>
        eWHITE,
    }
    /// <summary>
    /// 日期样式
    /// </summary>
    public enum E_DateStyle : int
    {
        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        eYYYY_MM_DD_MINUS,
        /// <summary>
        /// YYYY/MM/DD
        /// </summary>
        eYYYY_MM_DD_VIRGURE,
        /// <summary>
        /// DD-MM-YYYY
        /// </summary>
        eDD_MM_YYYY_MINUS,
        /// <summary>
        /// DD/MM/YYYY
        /// </summary>
        eDD_MM_YYYY_VIRGURE,
        /// <summary>
        /// MM-DD
        /// </summary>
        eMM_DD_MINUS,
        /// <summary>
        /// MM/DD
        /// </summary>
        eMM_DD_VIRGURE,
        /// <summary>
        /// MM月DD日
        /// </summary>
        eMM_DD_CHS,
        /// <summary>
        /// YYYY年MM月DD日
        /// </summary>
        eYYYY_MM_DD_CHS,
    }
    /// <summary>
    /// 双基色类型
    /// </summary>
    public enum E_DoubleColorPixel_G56 : int
    {
        /// <summary>
        /// 双基色1：G+R
        /// </summary>
        eDOUBLE_COLOR_PIXTYPE_1 = 1,
        /// <summary>
        /// 双基色2：R+G
        /// </summary>
        eDOUBLE_COLOR_PIXTYPE_2,
    }
    /// <summary>
    /// 显示颜色
    /// </summary>
    public enum E_ScreenColor_G56
    {
        /// <summary>
        /// 单基色
        /// </summary>
        eSCREEN_COLOR_SINGLE = 1,
        /// <summary>
        /// 双基色
        /// </summary>
        eSCREEN_COLOR_DOUBLE,
        /// <summary>
        /// 七彩色
        /// </summary>
        eSCREEN_COLOR_THREE,
        /// <summary>
        /// 全彩色
        /// </summary>
        eSCREEN_COLOR_FULLCOLOR,
    }
    /// <summary>
    /// 时间样式
    /// </summary>
    public enum E_TimeStyle : int
    {
        /// <summary>
        /// HH:MM:SS
        /// </summary>
        eHH_MM_SS_COLON,
        /// <summary>
        /// HH时MM分SS秒
        /// </summary>
        eHH_MM_SS_CHS,
        /// <summary>
        /// HH:MM
        /// </summary>
        eHH_MM_COLON,
        /// <summary>
        /// HH时MM分
        /// </summary>
        eHH_MM_CHS,
        /// <summary>
        /// AM HH:MM
        /// </summary>
        eAM_HH_MM,
        /// <summary>
        /// HH:MM AM
        /// </summary>
        eHH_MM_AM,
    }
    /// <summary>
    /// 图文区文字方向---暂不支持
    /// </summary>
    public enum E_txtDirection
    {
        /// <summary>
        /// 正常
        /// </summary>
        pNORMAL,
        /// <summary>
        /// 向右旋转
        /// </summary>
        pROTATERIGHT,
        /// <summary>
        /// 镜像
        /// </summary>
        pMIRROR,
        /// <summary>
        /// 向左旋转
        /// </summary>
        pROTATELEFT,
    }
    /// <summary>
    /// 星期样式
    /// </summary>
    public enum E_WeekStyle : int
    {
        /// <summary>
        /// Monday
        /// </summary>
        eMonday = 1,
        /// <summary>
        /// Mon.
        /// </summary>
        eMon,
        /// <summary>
        /// 星期一
        /// </summary>
        eMonday_CHS,
    }
    /// <summary>
    /// 显示方式
    /// </summary>
    public enum E_DisplayMode
    {
        /// <summary>
        /// 随机显示
        /// </summary>
        Unknown = 0x00,
        /// <summary>
        /// 静止显示
        /// </summary>
        Static = 0x01,
        /// <summary>
        /// 快速打出
        /// </summary>
        Fast = 0x02,
        /// <summary>
        /// 向左移动
        /// </summary>
        MoveLeft = 0x03,
        /// <summary>
        /// 向左连移
        /// </summary>
        MoveLefts = 0x04,
        /// <summary>
        /// 向上移动
        /// </summary>
        MoveUp = 0x05,
        /// <summary>
        /// 向上连移
        /// </summary>
        MoveUps = 0x06,
        /// <summary>
        /// 闪烁
        /// </summary>
        Blink = 0x07,
        /// <summary>
        /// 飘雪
        /// </summary>
        Snowing = 0x08,
        /// <summary>
        /// 冒泡
        /// </summary>
        Bubbling = 0x09,
        /// <summary>
        /// 中间移出
        /// </summary>
        CenterOut = 0x0a,
        /// <summary>
        /// 左右移入
        /// </summary>
        SideIn = 0x0b,
        /// <summary>
        /// 左右交叉移入
        /// </summary>
        SideMixIn = 0x0c,
        /// <summary>
        /// 上下交叉移入
        /// </summary>
        UpDownMixIn = 0x0d,
        /// <summary>
        /// 画卷闭合
        /// </summary>
        PaintClose = 0x0e,
        /// <summary>
        /// 画卷打开
        /// </summary>
        PaintOpen = 0x0f,
        /// <summary>
        /// 向左拉伸
        /// </summary>
        StrechLeft = 0x10,
        /// <summary>
        /// 向右拉伸
        /// </summary>
        StrechRight = 0x11,
        /// <summary>
        /// 向上拉伸
        /// </summary>
        StrechUp = 0x12,
        /// <summary>
        /// 向下拉伸
        /// </summary>
        StrechDown = 0x13,
        /// <summary>
        /// 向左镭射
        /// </summary>
        LaserLeft = 0x14,
        /// <summary>
        /// 向右镭射
        /// </summary>
        LaserRight = 0x15,
        /// <summary>
        /// 向上镭射
        /// </summary>
        LaserUp = 0x16,
        /// <summary>
        /// 向下镭射
        /// </summary>
        LaserDown = 0x17,
        /// <summary>
        /// 左右交叉拉幕
        /// </summary>
        SideMixCurtain = 0x18,
        /// <summary>
        /// 上下交叉拉幕
        /// </summary>
        UpDownMixCurtain = 0x19,
        /// <summary>
        /// 分散左拉
        /// </summary>
        SplitLeft = 0x1a,
        /// <summary>
        /// 水平百页
        /// </summary>
        LouverHorizontal = 0x1b,
        /// <summary>
        /// 垂直百页
        /// </summary>
        LouverVertical = 0x1c,
        /// <summary>
        /// 向左拉幕
        /// </summary>
        GoLeftCurtain = 0x1d,
        /// <summary>
        /// 向右拉幕
        /// </summary>
        GoRightCurtain = 0x1e,
        /// <summary>
        /// 向上拉幕
        /// </summary>
        GoUpCurtain = 0x1f,
        /// <summary>
        /// 向下拉幕
        /// </summary>
        GoDownCurtain = 0x20,
        /// <summary>
        /// 左右闭合
        /// </summary>
        SideClose = 0x21,
        /// <summary>
        /// 左右对开
        /// </summary>
        SideOpen = 0x22,
        /// <summary>
        /// 上下闭合
        /// </summary>
        UpDownClose = 0x23,
        /// <summary>
        /// 上下对开
        /// </summary>
        UpDownOpen = 0x24,
        /// <summary>
        /// 向右移动
        /// </summary>
        MoveRight = 0x25,
        /// <summary>
        /// 向右连移
        /// </summary>
        MoveRights = 0x26,
        /// <summary>
        /// 向下移动
        /// </summary>
        MoveDown = 0x27,
        /// <summary>
        /// 向下连移
        /// </summary>
        MoveDowns = 0x28,
        /// <summary>
        /// 45 度左旋
        /// </summary>
        Left45 = 0x29,
        /// <summary>
        /// 180 度左旋
        /// </summary>
        Left180 = 0x2a,
        /// <summary>
        /// 90 度左旋
        /// </summary>
        Left90 = 0x2b,
        /// <summary>
        /// 45 度右旋
        /// </summary>
        Right45 = 0x2c,
        /// <summary>
        /// 180 度右旋
        /// </summary>
        Right180 = 0x2d,
        /// <summary>
        /// 90 度右旋
        /// </summary>
        Right90 = 0x2e,
        /// <summary>
        /// 菱形打开
        /// </summary>
        RhombOpen = 0x2f,
        /// <summary>
        /// 菱形闭合
        /// </summary>
        RhombClose = 0x30,
    }
    /// <summary>
    /// 边框显示方式
    /// </summary>
    public enum E_FrameDisplayMode
    {
        /// <summary>
        /// 闪烁
        /// </summary>
        Blink = 0x00,
        /// <summary>
        /// 顺时针转动
        /// </summary>
        Clockwise = 0x01,
        /// <summary>
        /// 逆时针转动
        /// </summary>
        Anticlockwise = 0x02,
        /// <summary>
        /// 闪烁加顺时针转动
        /// </summary>
        BlinkClockwise = 0x03,
        /// <summary>
        /// 闪烁加逆时针转动
        /// </summary>
        BlinkAnticlockwise = 0x04,
        /// <summary>
        /// 红绿交替闪烁
        /// </summary>
        BlinkRedGreen = 0x05,
        /// <summary>
        /// 红绿交替转动
        /// </summary>
        MixRedGreen = 0x06,
        /// <summary>
        /// 静止打出
        /// </summary>
        Static = 0x07,
    }
    /// <summary>
    /// 区域类型
    /// </summary>
    public enum E_AreaType
    {
        /// <summary>
        /// 图文字幕
        /// </summary>
        PicTxt = 0x00,
        /// <summary>
        /// 字库区域
        /// </summary>
        Font = 0x01,
        /// <summary>
        /// 时间区
        /// </summary>
        Time = 0x02,
        /// <summary>
        /// 温度区
        /// </summary>
        Temperature = 0x03,
        /// <summary>
        /// 湿度区
        /// </summary>
        Humidity = 0x04,
        /// <summary>
        /// 噪声区
        /// </summary>
        Noise = 0x05,
        /// <summary>
        /// 透明文本
        /// </summary>
        TransTxt = 0x06,
        /// <summary>
        /// 霓虹区
        /// </summary>
        Neon = 0x08,
        /// <summary>
        /// 战斗时间
        /// </summary>
        ActTime = 0x09,
    }
    /// <summary>
    /// 文字对齐方式
    /// </summary>
    public enum E_TextAlignType
    {
        /// <summary>
        /// 0系统自适应
        /// </summary>
        Auto = 0,
        /// <summary>
        /// 1左对齐
        /// </summary>
        Left = 1,
        /// <summary>
        /// 2居中
        /// </summary>
        Center = 2,
        /// <summary>
        /// 3右对齐
        /// </summary>
        Right = 3,
    }
    #endregion Enums 枚举
    /// <summary>
    /// 战斗时间
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BattleTime
    {
        /// <summary>
        /// 年
        /// </summary>
        public short BattleRTCYear;
        /// <summary>
        /// 月
        /// </summary>
        public byte BattleRTCMonth;
        /// <summary>
        /// 日
        /// </summary>
        public byte BattleRTCDate;
        /// <summary>
        /// 时
        /// </summary>
        public byte BattleRTCHour;
        /// <summary>
        /// 分
        /// </summary>
        public byte BattleRTCMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public byte BattleRTCSecond;
        /// <summary>
        /// 星期
        /// </summary>
        public byte BattleRTCWeek;
    }
    /// <summary>
    /// 亮度
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Brightness
    {
        /// <summary>
        /// 0x00 –手动调亮
        /// 0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制器
        /// 0x00 –手动调亮
        /// 0x01 –定时调亮 注:以下的亮度值表，在定时调亮和手 动调亮时控制器才需处理。但在协议上 不论什么模式，此表都需要发送给控制器
        /// </summary>
        public byte BrightnessMode;
        /// <summary>
        /// 00:00 – 00:29 的亮度值， 0x00 – 0x0f
        /// </summary>
        public byte HalfHourValue0;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue1;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue2;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue3;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue4;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue5;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue6;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue7;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue8;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue9;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue10;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue11;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue12;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue13;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue14;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue15;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue16;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue17;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue18;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue19;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue20;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue21;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue22;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue23;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue24;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue25;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue26;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue27;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue28;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue29;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue30;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue31;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue32;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue33;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue34;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue35;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue36;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue37;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue38;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue39;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue40;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue41;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue42;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue43;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue44;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue45;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue46;
        /// <summary>
        /// 
        /// </summary>
        public byte HalfHourValue47;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BxAreaFrmae_Dynamic_G6
    {
        /// <summary>
        /// 1 0x00 区域边框标志位;
        /// </summary>
        public byte AreaFFlag;
        /// <summary>
        /// 
        /// </summary>
        public EQscreenframeHeader_G6 oAreaFrame;
        /// <summary>
        /// 
        /// </summary>
        public byte[] pStrFramePathFile;
    }
    /// <summary>
    /// 控制器类型
    /// </summary>
    public class BxDualControlType
    {
        /// <summary>
        /// 控制器类型
        /// </summary>
        public const ushort BX_5AT = 0x0051;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A0 = 0x0151;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A1 = 0x0251;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A2 = 0x0351;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A3 = 0x0451;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A4 = 0x0551;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A1_WIFI = 0x0651;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A2_WIFI = 0x0751;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A4_WIFI = 0x0851;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A = 0x0951;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A2_RF = 0x1351;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5A4_RF = 0x1551;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5AT_WIFI = 0x1651;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5AL = 0x1851;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_AT = 0x2051;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_A0 = 0x2151;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5MT = 0x0552;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5M1 = 0x0052;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5M1X = 0x0152;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5M2 = 0x0252;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5M3 = 0x0352;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5M4 = 0x0452;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5E1 = 0x0154;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5E2 = 0x0254;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5E3 = 0x0354;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5UT = 0x0055;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U0 = 0x0155;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U1 = 0x0255;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U2 = 0x0355;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U3 = 0x0455;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U4 = 0x0555;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U5 = 0x0655;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5U = 0x0755;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5UL = 0x0855;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_UL = 0x2055;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_UT = 0x2155;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_U0 = 0x2255;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_U1 = 0x2355;
        /// <summary>
        /// 
        /// </summary>
        public const ushort AX_U2 = 0x2455;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5Q0 = 0x0056;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5Q1 = 0x0156;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5Q2 = 0x0256;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5Q0P = 0x1056;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5Q1P = 0x1156;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5Q2P = 0x1256;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QL = 0x1356;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QS1 = 0x0157;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QS2 = 0x0257;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QS = 0x0357;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QS1P = 0x1157;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QS2P = 0x1257;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_5QSP = 0x1357;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M0 = 0x0062;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M1 = 0x0162;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M2 = 0x0262;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M3 = 0x0362;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M = 0x0462;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6MT = 0x0562;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M2JT = 0x3262;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M0P = 0x0062;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M1P = 0x0162;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M2P = 0x4262;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M3P = 0x4362;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M4P = 0x4462;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M0_YY = 0x1062;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M1_YY = 0x1162;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M2_YY = 0x1262;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M3_YY = 0x1362;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6M_YY = 0x1462;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6X1 = 0x2162;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6X2 = 0x2262;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6X3 = 0x2362;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U0 = 0x0063;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U1 = 0x0163;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U2 = 0x0263;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U3 = 0x0363;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U = 0x0463;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6UT = 0x0563;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U0_YY = 0x1063;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U1_YY = 0x1163;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U2_YY = 0x1263;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U3_YY = 0x1363;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6U_YY = 0x1463;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A0 = 0x2063;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A1 = 0x2163;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A2 = 0x2263;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A3 = 0x2363;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A = 0x2463;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A0_YY = 0x3063;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A1_YY = 0x3163;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A2_YY = 0x3263;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A3_YY = 0x3363;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A_YY = 0x3463;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A0_G = 0x4063;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A1_G = 0x4163;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A2_G = 0x4263;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6A3_G = 0x4363;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6AT_G = 0x4463;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6S1 = 0x5163;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6S2 = 0x5263;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6S3 = 0x5363;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6W0 = 0x0064;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6W1 = 0x0164;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6W2 = 0x0264;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6W3 = 0x0364;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6W = 0x0464;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6WT = 0x0564;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E1 = 0x0174;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E2 = 0x0274;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E3 = 0x0374;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E1X = 0x0474;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E2X = 0x0574;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E1XP = 0x0674;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E2XP = 0x0774;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6E3P = 0x0974;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6Q0 = 0x0066;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6Q1 = 0x0166;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6Q2 = 0x0266;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6Q2L = 0x0466;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6Q3 = 0x0366;
        /// <summary>
        /// 
        /// </summary>
        public const ushort BX_6Q3L = 0x0566;
        /// <summary>
        /// 控制器类型列表
        /// </summary>
        public static ushort[] ControlTypes = new ushort[111] { BX_5AT, BX_5A0, BX_5A1, BX_5A2, BX_5A3, BX_5A4, BX_5A1_WIFI, BX_5A2_WIFI,BX_5A4_WIFI,BX_5A,
                                        BX_5A2_RF,BX_5A4_RF,BX_5AT_WIFI,BX_5AL,AX_AT,AX_A0,BX_5MT,BX_5M1,BX_5M1X,BX_5M2,BX_5M3,BX_5M4,
                                        BX_5E1,BX_5E2,BX_5E3,BX_5UT,BX_5U0,BX_5U1,BX_5U2,BX_5U3,BX_5U4,BX_5U5,BX_5U,BX_5UL,
                                        AX_UL,AX_UT,AX_U0,AX_U1,AX_U2,BX_5Q0,BX_5Q1,BX_5Q2,BX_5Q0P,BX_5Q1P,BX_5Q2P,BX_5QL,BX_5QS1,
                                        BX_5QS2,BX_5QS,BX_5QS1P,BX_5QS2P,BX_5QSP,
                                        BX_6M0,BX_6M1,BX_6M2,BX_6M3,BX_6M,BX_6MT,BX_6M0_YY,BX_6M1_YY,BX_6M2_YY,BX_6M3_YY,BX_6M_YY,BX_6X1,BX_6X2,BX_6X3,
                                        BX_6U0,BX_6U1,BX_6U2,BX_6U3,BX_6U,BX_6UT,BX_6U0_YY,BX_6U1_YY,BX_6U2_YY,BX_6U3_YY,BX_6U_YY,
                                        BX_6A0,BX_6A1,BX_6A2,BX_6A3,BX_6A,BX_6A0_YY,BX_6A1_YY,BX_6A2_YY,BX_6A3_YY,BX_6A_YY,BX_6A0_G,BX_6A1_G,BX_6A2_G,BX_6A3_G,BX_6AT_G,
                                        BX_6S1,BX_6S2,BX_6S3,BX_6W0,BX_6W1,BX_6W2,BX_6W3,BX_6W,BX_6WT,
                                        BX_6E1,BX_6E2,BX_6E3,BX_6E1X,BX_6E2X,BX_6Q1,BX_6Q2,BX_6Q2L,BX_6Q3,BX_6Q3L};
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BXG6_Time_Counter
    {
        /// <summary>
        /// 长度为1或4；有灰度时是4； 颜色属性；
        /// </summary>
        public byte UnitColor;
        /// <summary>
        /// 1 0x00 计时模式：0x00 –正计时累加 0x01 –倒计时累加 0x02 –正计时不累加 0x03 –倒计时不累加
        /// </summary>
        public byte UnitMode;
        /// <summary>
        /// 2 目标年
        /// </summary>
        public ushort DestYear;
        /// <summary>
        /// 1 目标月
        /// </summary>
        public byte DestMonth;
        /// <summary>
        /// 1 目标日
        /// </summary>
        public byte DestDate;
        /// <summary>
        /// 1 目标时
        /// </summary>
        public byte DestHour;
        /// <summary>
        /// 1 目标分
        /// </summary>
        public byte DestMinute;
        /// <summary>
        /// 1 目标秒
        /// </summary>
        public byte DestSecond;
        /// <summary>
        /// 1 Bit0–天， 1 表示显示， 0表示不显示； Bit1–时； Bit2–分； Bit3–秒； Bit4–天单位，1表示显示，0不显示；Bit5–时 Bit6–分 Bit7–秒
        /// </summary>
        public byte TimerFormat;
        /// <summary>
        /// 1 0x00 单元长度 0x00 –长度由控制器自动计算其它–固定长度
        /// </summary>
        public byte DayLen;
        /// <summary>
        /// 1 0x00 同上
        /// </summary>
        public byte HourLen;
        /// <summary>
        /// 1 0x00 同上
        /// </summary>
        public byte MinuteLen;
        /// <summary>
        /// 1 0x00 同上
        /// </summary>
        public byte SecondLen;
        //Ouint32 Dataoffset;	//4 在数据文件中的偏移量，下面的字模数据放入数据文件中
        //Ouint32 DataLen;	//4 该字模数据长度
        //Ouint8* FontData;	//N 字模数据，具体的字模格式，请参考附录 1字模个数为 14，其顺序依次为： 0, …, 9, 天，时，分，秒
    }
    /// <summary>
    /// 这个语音结构体BXSound_6G仅在动态区时使用；图文分区播放语音请使用：EQPicAreaSoundHeader_G6;
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct BXSound_6G
    {
        /// <summary>
        /// 1 0x00 是否使能语音播放;0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
        /// </summary>
        public byte SoundFlag;
        //SoundData 部分内容---------------------------
        /// <summary>
        /// 1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        /// </summary>
        public byte SoundPerson;
        /// <summary>
        /// 1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        /// </summary>
        public byte SoundVolum;
        /// <summary>
        /// 1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        /// </summary>
        public byte SoundSpeed;
        /// <summary>
        /// 1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0x01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        /// </summary>
        public byte SoundDataMode;
        /// <summary>
        /// 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
        /// 该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
        /// </summary>
        public int SoundReplayTimes;
        /// <summary>
        /// 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        /// </summary>
        public int SoundReplayDelay;
        /// <summary>
        /// 1 0x03 语音参数保留参数长度
        /// </summary>
        public byte SoundReservedParaLen;
        /// <summary>
        /// 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        /// </summary>
        public byte Soundnumdeal;
        /// <summary>
        /// 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
        /// </summary>
        public byte Soundlanguages;
        /// <summary>
        /// 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        /// </summary>
        public byte Soundwordstyle;
        /// <summary>
        /// 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        /// </summary>
        public int SoundDataLen;
        /// <summary>
        /// N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        /// </summary>
        public IntPtr SoundData;
    }
    /// <summary>
    /// 表盘颜色
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ClockColor_G56
    {
        /// <summary>
        /// 369点颜色
        /// </summary>
        public uint Color369;
        /// <summary>
        /// 点颜色
        /// </summary>
        public uint ColorDot;
        /// <summary>
        /// 表盘外圈颜色 模式没有圈泽此颜色无效
        /// </summary>
        public uint ColorBG;
    }
    /// <summary>
    /// 配置文件
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ConfigFile
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 控制器名称
        /// </summary>
        public byte[] ControllerName;
        /// <summary>
        /// 控制器地址
        /// </summary>
        public ushort Address;
        /// <summary>
        /// 串口波特率 
        /// 0x00 –保持原有波特率不变
        /// 0x01 –强制设置为 9600
        /// 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 显示屏宽度
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 显示屏高度
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮
        /// </summary>
        public byte Color;
        /// <summary>
        /// 0x00 –无镜向 0x01 –镜向
        /// </summary>
        public byte MirrorMode;
        /// <summary>
        /// OE 极性，0x00 – OE 低有效   0x01 – OE 高有效
        /// </summary>
        public byte OEPol;
        /// <summary>
        /// 数据极性， 0x00 –数据低有效， 0x01 –数据高有效
        /// </summary>
        public byte DAPol;
        /// <summary>
        /// 行序模式， 该值范围为 0-31
        /// 0-15 代表正序
        /// 0 代表从第 0 行开始顺序扫描
        /// 1 代表从第 1 行开始顺序扫描
        /// .....
        /// 16-31 代表逆序
        /// 0 代表从第 0 行开始逆序扫描
        /// 1 代表从第 1 行开始逆序扫描
        /// </summary>
        public byte RowOrder;
        /// <summary>
        /// CLK 分频倍数
        /// 注意： 针对于 AX 系列， 为后级分频数值为 0~15， 共 16 个等级。
        /// </summary>
        public byte FreqPar;
        /// <summary>
        /// OE 宽度
        /// </summary>
        public byte OEWidth;
        /// <summary>
        /// OE 提前角
        /// </summary>
        public byte OEAngle;
        /// <summary>
        /// 控制器的错误处理模式
        /// 0x00 –自动处理
        /// 0x01 –手动处理(此模式仅供调试人员使用)
        /// </summary>
        public byte FaultProcessMode;
        /// <summary>
        /// 通讯超时设置（单位秒）
        /// 建议值：
        /// 串口– 2S
        /// TCP/IP – 6S
        /// GPRS – 30S
        /// </summary>
        public byte CommTimeoutValue;
        /// <summary>
        /// 控制器运行模式， 具体定义如下：
		/// 0x00 –正常模式
		/// 0x01 –调试模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 日志记录模式
        /// 0x00 –无日志
        /// 0x01 –只对控制器错误及对错误进行的错误进行记录
        /// 0x02 –对控制器的所有操作进行记录， 包括： 控制器接收的各条指令、发生的错误及错误处理
        /// </summary>
        public byte LoggingMode;
        /// <summary>
        /// 灰度标志(仅 5Q 卡时有该字节)
        /// 0x00–无灰度
        /// 0x01–灰度
        /// </summary>
        public byte GrayFlag;
        /// <summary>
        /// 级联模式： (仅 5Q 卡时有该字节)
        /// 0x00–非级联模式
        /// 0x01–级联模式
        /// </summary>
        public byte CascadeMode;
        /// <summary>
        /// AX 系列控制器专用， 表示上电时， 默认的亮度等级值。 
        /// 根据不同的屏幕类型有所不同。
        /// </summary>
        public byte Default_brightness;
        /// <summary>
        /// HUB 板设置(仅 6E 控制器支持)
        /// 0x00–HUB512 默认项
        /// 0x01–HUB256
        /// </summary>
        public byte HUBConfig;
        /// <summary>
        /// 控制器多语言显示区。
        /// 0x00 ----简体中文显示。
        /// 0x01 ----非中文显示， 控制器显示图形加英文字符。
        /// 其他值保留。
        /// </summary>
        public byte Language;
        /// <summary>
        /// 备用字节
        /// </summary>
        public byte Backup;
        /// <summary>
        /// 整个文件的 CRC16 校验
        /// </summary>
        public ushort CRC16;
    }
    /// <summary>
    /// 配置文件
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ConfigFile_G6
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 控制器名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ControllerName;
        /// <summary>
        /// 屏幕安装地址限制为 24个字节长度
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        byte[] ScreenAddress;
        /// <summary>
        /// 控制器地址
        /// </summary>
        ushort Address;
        /// <summary>
        /// 串口波特率 
        /// 0x00 –保持原有波特率不变
        /// 0x01 –强制设置为 9600
        /// 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 显示屏宽度
        /// </summary>
        ushort ScreenWidth;
        /// <summary>
        /// 显示屏高度
        /// </summary>
        ushort ScreenHeight;
        /// <summary>
        /// 显示屏颜色定义 Bit0 表示红， bit1 表示绿， bit2 表示蓝， 对于每一个 Bit， 0 表示灭， 1 表示亮
        /// </summary>
        public byte Color;
        /// <summary>
        /// 6Q 系列显示模式： 0为888, 1为565，对其余控制卡该字节为0
        /// </summary>
        public byte modeofdisp;
        /// <summary>
        /// 0 表示上位机软件是中文版，底层固件在显示提示信息时需调用内置的中文提示信息
        /// 1 表示上位机软件是英文版，底层固件在显示提示信息时需调用内置的英文提示信息
        /// 255 表示上位机软件是其他语言版，底层固件在显示提示信息时需调用自定义提示信息
        /// </summary>
        public byte TipLanguage;
        /// <summary>
        /// 5个备用字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Reserved;
        /// <summary>
        /// 控制器的错误处理模式
        /// 0x00 –自动处理
        /// 0x01 –手动处理(此模式仅供调试人员使用)
        /// </summary>
        public byte FaultProcessMode;
        /// <summary>
        /// 通讯超时设置（单位秒）
        /// 建议值：
        /// 串口– 2S
        /// TCP/IP – 6S
        /// GPRS – 30S
        /// </summary>
        public byte CommTimeoutValue;
        /// <summary>
        /// 控制器运行模式，具体定义如下：
        /// 0x00 –正常模式
        /// 0x01 –调试模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 日志记录模式
        /// 0x00 –无日志
        /// 0x01 –只对控制器错误及对错误进行的错误进行记录
        /// 0x02 –对控制器的所有操作进行记录， 包括： 控制器接收的各条指令、发生的错误及错误处理
        /// </summary>
        public byte LoggingMode;
        /// <summary>
        /// 针对 6Q2 卡的分屏模式
        /// 对其余的卡为保留字节0
        /// </summary>
        public byte DevideScreenMode;
        /// <summary>
        /// 备用字节
        /// </summary>
        public byte Reserved2;
        /// <summary>
        /// AX 系列控制器专用，表示上电时，默认的亮度等级值。其余的控制卡该字节为保留字 0
        /// </summary>
        public byte Default_brightness;
        /// <summary>
        /// 备用值字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] Backup;
        /// <summary>
        /// 整个文件的 CRC16 校验
        /// </summary>
        public ushort CRC16;
    };
    /// <summary>
    /// 控制器状态
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ControllerStatus_G56
    {
        /// <summary>
        /// 开关机状态 Bit 0 –开机/关机， 0 表示关机， 1 表示开机
        /// </summary>
        public byte onoffStatus;
        /// <summary>
        /// 定时开关机状态 0 表示无定时开关机， 1 表示有定时开关机
        /// </summary>
        public byte timingOnOff;
        /// <summary>
        /// 亮度模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
        /// </summary>
        public byte brightnessAdjMode;
        /// <summary>
        /// 当前亮度值
        /// </summary>
        public byte brightness;
        /// <summary>
        /// 控制器上已有节目个数
        /// </summary>
        public short programeNumber;
        /// <summary>
        /// 当前节目名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] currentProgram;
        /// <summary>
        /// 是否屏幕锁定，0 –无屏幕锁定， 1 –屏幕锁定
        /// </summary>
        public byte screenLockStatus;
        /// <summary>
        /// 是否节目锁定， 0 –无节目锁定，1 –节目锁定
        /// </summary>
        public byte programLockStatus;
        /// <summary>
        /// 控制器运行模式
        /// </summary>
        public byte runningMode;
        /// <summary>
        /// RTC 状态0x00 – RTC 异常 0x01 – RTC 正常
        /// </summary>
        public byte RTCStatus;
        /// <summary>
        /// 年
        /// </summary>
        public short RTCYear;
        /// <summary>
        /// 月
        /// </summary>
        public byte RTCMonth;
        /// <summary>
        /// 日
        /// </summary>
        public byte RTCDate;
        /// <summary>
        /// 时
        /// </summary>
        public byte RTCHour;
        /// <summary>
        /// 分
        /// </summary>
        public byte RTCMinute;
        /// <summary>
        /// 秒
        /// </summary>
        public byte RTCSecond;
        /// <summary>
        /// 星期 1--7
        /// </summary>
        public byte RTCWeek;
        /// <summary>
        /// 温度1传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] temperature1;
        /// <summary>
        /// 温度2传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] temperature2;
        /// <summary>
        /// 湿度传感器当前值
        /// </summary>
        public short humidity;
        /// <summary>
        /// 噪声传感器当前值
        /// </summary>
        public short noise;
        /// <summary>
        /// 测试按钮状态 0 –打开 1 –闭合
        /// </summary>
        public byte switchStatus;
        /// <summary>
        /// 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] CustomID;
        /// <summary>
        /// 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BarCode;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DynamicAreaBaseInfo_5G
    {
        /// <summary>
        /// nType=1:文本； nType=2:图片；
        /// </summary>
        public byte nType;
        //PageStyle begin---------------
        /// <summary>
        /// 
        /// </summary>
        public byte DisplayMode;
        /// <summary>
        /// 
        /// </summary>
        public byte ClearMode;
        /// <summary>
        /// 
        /// </summary>
        public byte Speed;
        /// <summary>
        /// 
        /// </summary>
        public ushort StayTime;
        /// <summary>
        /// 
        /// </summary>
        public byte RepeatTime;
        //PageStyle End.
        //文本显示内容和字体格式 begin---------
        /// <summary>
        /// 
        /// </summary>
        public EQfontData oFont;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr fontName;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr strAreaTxtContent;
        //end.
        /// <summary>
        /// 图片路径
        /// </summary>
        public IntPtr filePath;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DynamicAreaParams
    {
        /// <summary>
        /// 
        /// </summary>
        public byte uAreaId;
        /// <summary>
        /// 
        /// </summary>
        public EQareaHeader_G6 oAreaHeader_G6;
        /// <summary>
        /// 
        /// </summary>
        public EQpageHeader_G6 stPageHeader;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr fontName;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr strAreaTxtContent;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQAnalogClockHeader_G56
    {
        /// <summary>
        /// 原点横坐标
        /// </summary>
        public ushort OrignPointX;
        /// <summary>
        /// 原点纵坐标
        /// </summary>
        public ushort OrignPointY;
        /// <summary>
        /// 表针模式
        /// </summary>
        public byte UnitMode;
        /// <summary>
        /// 时针宽度
        /// </summary>
        public byte HourHandWidth;
        /// <summary>
        /// 时针长度
        /// </summary>
        public byte HourHandLen;
        /// <summary>
        /// 时针颜色
        /// </summary>
        public uint HourHandColor;
        /// <summary>
        /// 分针宽度
        /// </summary>
        public byte MinHandWidth;
        /// <summary>
        /// 分针长度
        /// </summary>
        public byte MinHandLen;
        /// <summary>
        /// 分针颜色
        /// </summary>
        public uint MinHandColor;
        /// <summary>
        /// 秒针宽度
        /// </summary>
        public byte SecHandWidth;
        /// <summary>
        /// 秒针长度
        /// </summary>
        public byte SecHandLen;
        /// <summary>
        /// 秒针颜色
        /// </summary>
        public uint SecHandColor;
    }
    /// <summary>
    /// 区域边框
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaframeHeader
    {
        /// <summary>
        /// 区域边框标志位
        /// 注：如果此字段为 0x00，则以下区域边框属性不发送
        /// </summary>
        public byte AreaFFlag;
        /// <summary>
        /// 边框显示方式：
        /// 0x00 –闪烁
        /// 0x01 –顺时针转动
        /// 0x02 –逆时针转动
        /// 0x03 –闪烁加顺时针转动
        /// 0x04 –闪烁加逆时针转动
        /// 0x05 –红绿交替闪烁
        /// 0x06 –红绿交替转动
        /// 0x07 –静止打出
        /// <see cref="E_FrameDisplayMode"/>
        /// </summary>
        public byte AreaFDispStyle;
        /// <summary>
        /// 边框显示速度
        /// </summary>
        public byte AreaFDispSpeed;
        /// <summary>
        /// 边框移动步长，单位为点，此参数范围为 1~16
        /// </summary>
        public byte AreaFMoveStep;
        /// <summary>
        /// 边框组元宽度，此参数范围为 1~8 注：边框组元的长度固定为 16
        /// </summary>
        public byte AreaFWidth;
        /// <summary>
        /// 备用字
        /// </summary>
        public ushort AreaFBackup;
    }
    /// <summary>
    /// 区域头边框
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaframeHeader_6G
    {
        /// <summary>
        /// 区域边框标志位
        /// 注：如果此字段为 0x00，则以下区域边框属性不发送
        /// </summary>
        public byte AreaFFlag;
        /// <summary>
        /// 边框显示方式：
        /// 0x00 –闪烁
        /// 0x01 –顺时针转动
        /// 0x02 –逆时针转动
        /// 0x03 –闪烁加顺时针转动
        /// 0x04 –闪烁加逆时针转动
        /// 0x05 –红绿交替闪烁
        /// 0x06 –红绿交替转动
        /// 0x07 –静止打出
        /// <see cref="E_FrameDisplayMode"/>
        /// </summary>
        public byte AreaFDispStyle;
        /// <summary>
        /// 边框显示速度
        /// </summary>
        public byte AreaFDispSpeed;
        /// <summary>
        /// 边框移动步长，单位为点，此参数范围为 1~16
        /// </summary>
        public byte AreaFMoveStep;
        /// <summary>
        /// 边框组员长度
        /// </summary>
        public byte AreaDLength;
        /// <summary>
        /// 边框组元宽度，此参数范围为 1~8 注：边框组元的长度固定为 16
        /// </summary>
        public byte AreaFWidth;
        /// <summary>
        /// 备用字
        /// </summary>
        public ushort AreaFBackup;
        /// <summary>
        /// 边框组员数据，格式同图文区
        /// </summary>
        public byte[] AreaFUnitData;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaHeader
    {
        /// <summary>
        /// 区域类型
        /// 字库区域:0x01
        /// 透明文本：0x06
        /// 时间区:0x02
        /// 图文字幕:0x00
        /// 战斗时间：0x09
        /// 噪声区：0x05
        /// 温度区：0x03
        /// 霓虹区：0x08
        /// 湿度区：0x04
        /// </summary>
        public byte AreaType;
        /// <summary>
        /// 区域X坐标
        /// </summary>
        public ushort AreaX;
        /// <summary>
        /// 区域Y坐标
        /// </summary>
        public ushort AreaY;
        /// <summary>
        /// 区域宽
        /// </summary>
        public ushort AreaWidth;
        /// <summary>
        /// 区域高
        /// </summary>
        public ushort AreaHeight;
    }
    /// <summary>
    /// 6代区域头
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQareaHeader_G6
    {
        /// <summary>
        /// 区域类型
        /// 图文字幕:0x00
        /// 字库区域:0x01
        /// 时间区:0x02
        /// 温度区：0x03
        /// 湿度区：0x04
        /// 噪声区：0x05
        /// 透明文本：0x06
        /// 霓虹区：0x08
        /// 战斗时间：0x09
        /// <see cref="E_AreaType"/>
        /// </summary>
        public byte AreaType;
        /// <summary>
        /// 区域左上角横坐标(Top Left)，单 位 Pixel
        /// </summary>
        public ushort AreaX;
        /// <summary>
        /// 区域左上角纵坐标(Top Left)，单 位 Pixel
        /// </summary>
        public ushort AreaY;
        /// <summary>
        /// 区域宽度，单位 Pixel
        /// </summary>
        public ushort AreaWidth;
        /// <summary>
        /// 区域高度，单位 Pixel
        /// </summary>
        public ushort AreaHeight;
        /// <summary>
        /// 是否有背景，目前不支持，固定给0
        /// </summary>
        public byte BackGroundFlag;
        /// <summary>
        /// 透明度，目前不支持，固定给101
        /// </summary>
        public byte Transparency;
        /// <summary>
        /// 前景、背景区域大小是否相同，目前不支持，固定给0
        /// </summary>
        public byte AreaEqual;
        /// <summary>
        /// 语音内容
        /// 使用语音功能时：部分卡需要配置串口为语音模式！！！
        /// </summary>
        public EQSound_6G stSoundData;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQdynamicHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public byte RunMode;
        /// <summary>
        /// 
        /// </summary>
        ushort Timeout;
        /// <summary>
        /// 
        /// </summary>
        public byte ImmePlay;
        /// <summary>
        /// 
        /// </summary>
        public byte AreaType;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaX;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaY;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaWidth;
        /// <summary>
        /// 
        /// </summary>
        public ushort AreaHeight;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQfontData
    {
        /// <summary>
        /// 排列方式--单行多行  E_arrMode::	eSINGLELINE,   //单行 eMULTILINE,    //多行
        /// </summary>
        public E_arrMode arrMode;
        /// <summary>
        /// 字体大小
        /// </summary>
        public ushort fontSize;
        /// <summary>
        /// 字体颜色 E_Color_G56 此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        /// </summary>
        public uint color;
        /// <summary>
        /// 是否为粗体
        /// </summary>
        public byte fontBold;
        /// <summary>
        /// 是否为斜体
        /// </summary>
        public byte fontItalic;
        /// <summary>
        /// 文字方向
        /// </summary>
        public E_txtDirection tdirection;
        /// <summary>
        /// 文字间隔
        /// </summary>
        public ushort txtSpace;
        /// <summary>
        /// 横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
        /// </summary>
        public byte Halign;
        /// <summary>
        /// 纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
        /// </summary>
        public byte Valign;
    }
    /// <summary>
    /// 请参考协议 图文字幕区数据格式
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQpageHeader
    {
        /// <summary>
        /// 数据页类型
        /// </summary>
        public byte PageStyle;
        /// <summary>
        /// 显示方式 （特效）
        /// </summary>
        public byte DisplayMode;
        /// <summary>
        /// 退出方式/清屏方式
        /// </summary>
        public byte ClearMode;
        /// <summary>
        /// 速度等级/背景速度等级
        /// </summary>
        public byte Speed;
        /// <summary>
        /// 停留时间， 单位为 10ms
        /// </summary>
        public ushort StayTime;
        /// <summary>
        /// 重复次数/背景拼接步长(左右拼接下为宽度， 上下拼接为高度)
        /// </summary>
        public byte RepeatTime;
        /// <summary>
        /// 用法比较复杂请参考协议
        /// </summary>
        public ushort ValidLen;
        /// <summary>
        /// 排列方式--单行多行
        /// </summary>
        public E_arrMode arrMode;
        /// <summary>
        /// 字体大小
        /// </summary>
        public ushort fontSize;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public uint color;
        /// <summary>
        /// 是否为粗体
        /// </summary>
        public byte fontBold;
        /// <summary>
        /// 是否为斜体
        /// </summary>
        public byte fontItalic;
        /// <summary>
        /// 文字方向
        /// </summary>
        public E_txtDirection tdirection;
        /// <summary>
        /// 文字间隔  
        /// </summary>
        public ushort txtSpace;
        /// <summary>
        /// 
        /// </summary>
        public byte Valign;
        /// <summary>
        /// 
        /// </summary>
        public byte Halign;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQpageHeader_G6
    {
        /// <summary>
        /// 数据页类型
        /// </summary>
        public byte PageStyle;
        /// <summary>
        /// 显示方式
        /// 0x00 –随机显示
        /// 0x01 –静止显示
        /// 0x02 –快速打出
        /// 0x03 –向左移动
        /// 0x04 –向左连移
        /// 0x05 –向上移动
        /// 0x06 –向上连移
        /// 0x07 –闪烁
        /// 0x08 –飘雪
        /// 0x09 –冒泡
        /// 0x0a –中间移出
        /// 0x0b –左右移入
        /// 0x0c –左右交叉移入
        /// 0x0d –上下交叉移入
        /// 0x0e –画卷闭合
        /// 0x0f –画卷打开
        /// 0x10 –向左拉伸
        /// 0x11 –向右拉伸
        /// 0x12 –向上拉伸
        /// 0x13 –向下拉伸
        /// 0x14 –向左镭射
        /// 0x15 –向右镭射
        /// 0x16 –向上镭射
        /// 0x17 –向下镭射
        /// 0x18 –左右交叉拉幕
        /// 0x19 –上下交叉拉幕
        /// 0x1a –分散左拉
        /// 0x1b –水平百页
        /// 0x1c –垂直百页
        /// 0x1d –向左拉幕
        /// 0x1e –向右拉幕
        /// 0x1f –向上拉幕
        /// 0x20 –向下拉幕
        /// 0x21 –左右闭合
        /// 0x22 –左右对开
        /// 0x23 –上下闭合
        /// 0x24 –上下对开
        /// 0x25 –向右移动
        /// 0x26 –向右连移
        /// 0x27 –向下移动
        /// 0x28 –向下连移
        /// 0x29 –45 度左旋
        /// 0x2a–180 度左旋
        /// 0x2b–90 度左旋
        /// 0x2c–45 度右旋
        /// 0x2d–180 度右旋
        /// 0x2e–90 度右旋
        /// 0x2f –菱形打开
        /// 0x30–菱形闭合
        /// <see cref="E_DisplayMode"/>
        /// </summary>
        public byte DisplayMode;
        /// <summary>
        /// 退出方式/清屏方式
        /// </summary>
        public byte ClearMode;
        /// <summary>
        /// 速度等级
        /// </summary>
        public byte Speed;
        /// <summary>
        /// 停留时间
        /// </summary>
        public ushort StayTime;
        /// <summary>
        /// 重复次数
        /// </summary>
        public byte RepeatTime;
        /// <summary>
        /// 此字段只在左移右移方式下有效
        /// </summary>
        public ushort ValidLen;
        /// <summary>
        /// 特技为动画方式时，该值代表其帧率
        /// </summary>
        public byte CartoonFrameRate;
        /// <summary>
        /// 背景无效标志
        /// </summary>
        public byte BackNotValidFlag;
        /// <summary>
        /// 排列方式--单行多行
        /// </summary>
        public E_arrMode arrMode;
        /// <summary>
        /// 字体大小
        /// </summary>
        public ushort fontSize;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public uint color;
        /// <summary>
        /// 是否为粗体 0:false 1:true
        /// </summary>
        public byte fontBold;
        /// <summary>
        /// 是否为斜体
        /// </summary>
        public byte fontItalic;
        /// <summary>
        /// 文字方向
        /// </summary>
        public E_txtDirection tdirection;
        /// <summary>
        /// 文字间隔  
        /// </summary>
        public ushort txtSpace;
        /// <summary>
        /// 0系统自适应、1左对齐、2居中、3右对齐
        /// <see cref="E_TextAlignType"/>
        /// </summary>
        public byte Valign;
        /// <summary>
        /// 0系统自适应、1上对齐、2居中、3下对齐
        /// <see cref="E_TextAlignType"/>
        /// </summary>
        public byte Halign;
    }
    /// <summary>
    /// 图文分区播放语音
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQPicAreaSoundHeader_G6
    {
        /// <summary>
        /// 发音人，范围0～5，共6种选择
        /// </summary>
        public byte SoundPerson;
        /// <summary>
        /// 音量，范围0～10
        /// </summary>
        public byte SoundVolum;
        /// <summary>
        /// 语速，范围0～10
        /// </summary>
        public byte SoundSpeed;
        /// <summary>
        /// 语音数据的编码格式
        /// </summary>
        public byte SoundDataMode;
        /// <summary>
        /// 重播次数
        /// </summary>
        public uint SoundReplayTimes;
        /// <summary>
        /// 重播时间间隔
        /// </summary>
        public uint SoundReplayDelay;
        /// <summary>
        /// 语音参数保留参数长度，默认0x03
        /// </summary>
        public byte SoundReservedParaLen;
        /// <summary>
        /// 详情见协议
        /// </summary>
        public byte Soundnumdeal;
        /// <summary>
        /// 详情见协议
        /// </summary>
        public byte Soundlanguages;
        /// <summary>
        /// 详情见协议
        /// </summary>
        public byte Soundwordstyle;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogram
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName;
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 文件长度
        /// </summary>
        public uint fileLen;
        /// <summary>
        /// 文件所在的缓存地址
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 文件CRC32校验码
        /// </summary>
        public uint fileCRC32;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogram_G6
    {
        /// <summary>
        /// 节目参数文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName;
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 参数文件长度
        /// </summary>
        public uint fileLen;
        /// <summary>
        /// 文件所在的缓存地址
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 节目数据文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] dfileName;
        /// <summary>
        /// 节目数据文件类型
        /// </summary>
        public byte dfileType;
        /// <summary>
        /// 数据文件长度
        /// </summary>
        public uint dfileLen;
        /// <summary>
        /// 数据文件缓存地址
        /// </summary>
        public IntPtr dfileAddre;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramHeader
    {
        /// <summary>
        /// 文件类型
        /// 默认：0x00
        /// LOGO文件:0x08
        /// 扫描配置文件:0x02
        /// 日志文件:0x06
        /// 字库文件:0x05
        /// 提示信息库文件: 0x07
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 节目ID
        /// </summary>
        public uint ProgramID;
        /// <summary>
        /// 节目类型
        /// Bit0 –全局节目标志位
        /// Bit1 –动态节目标志位
        /// Bit2 –屏保节目标志位
        /// </summary>
        public byte ProgramStyle;

        /// <summary>
        /// 节目等级
        /// 注:带播放时段的节目优先级为 1，不 带播放时段的节目优先级为 0
        /// </summary>
        public byte ProgramPriority;
        /// <summary>
        /// 节目重播放次数
        /// </summary>
        public byte ProgramPlayTimes;
        /// <summary>
        /// 播放的方式
        /// </summary>
        public ushort ProgramTimeSpan;
        /// <summary>
        /// 节目星期属性
        /// </summary>
        public byte ProgramWeek;
        /// <summary>
        /// 年
        /// </summary>
        public ushort ProgramLifeSpan_sy;
        /// <summary>
        /// 月
        /// </summary>
        public byte ProgramLifeSpan_sm;
        /// <summary>
        /// 日
        /// </summary>
        public byte ProgramLifeSpan_sd;
        /// <summary>
        /// 结束年
        /// </summary>
        public ushort ProgramLifeSpan_ey;
        /// <summary>
        /// 结束日
        /// </summary>
        public byte ProgramLifeSpan_em;
        /// <summary>
        /// 结束天
        /// </summary>
        public byte ProgramLifeSpan_ed;
        ///// <summary>
        ///// 播放时段的组数
        ///// </summary>
        //public byte PlayPeriodGrpNum;
    }
    /// <summary>
    /// 6代节目头模型
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramHeader_G6
    {
        /// <summary>
        /// 文件类型
        /// 默认：0x00
        /// LOGO文件:0x08
        /// 扫描配置文件:0x02
        /// 日志文件:0x06
        /// 字库文件:0x05
        /// 提示信息库文件: 0x07
        /// </summary>
        public byte FileType;
        /// <summary>
        /// 节目ID
        /// </summary>
        public uint ProgramID;
        /// <summary>
        /// 节目类型
        /// Bit0 –全局节目标志位
        /// Bit1 –动态节目标志位
        /// Bit2 –屏保节目标志位
        /// </summary>
        public byte ProgramStyle;
        /// <summary>
        /// 节目等级
        /// 注:带播放时段的节目优先级为 1，不带播放时段的节目优先级为 0
        /// </summary>
        public byte ProgramPriority;
        /// <summary>
        /// 节目重播放次数
        /// </summary>
        public byte ProgramPlayTimes;
        /// <summary>
        /// 播放的方式
        /// </summary>
        public ushort ProgramTimeSpan;
        /// <summary>
        /// 特殊节目标
        /// </summary>
        public byte SpecialFlag;
        /// <summary>
        /// 扩展参数长度，默认为0x00
        /// </summary>
        public byte CommExtendParaLen;
        /// <summary>
        /// 节目调度  
        /// </summary>
        public ushort ScheduNum;
        /// <summary>
        /// 调度规则循环次数
        /// </summary>
        public ushort LoopValue;
        /// <summary>
        /// 调度相关
        /// </summary>
        public byte Intergrate;
        /// <summary>
        /// 时间属性组数
        /// </summary>
        public byte TimeAttributeNum;
        /// <summary>
        /// 第一组时间属性偏移量--目前只支持一组
        /// </summary>
        public ushort TimeAttribute0Offset;
        /// <summary>
        /// 节目星期属性
        /// </summary>
        public byte ProgramWeek;
        /// <summary>
        /// 年
        /// </summary>
        public ushort ProgramLifeSpan_sy;
        /// <summary>
        /// 月
        /// </summary>
        public byte ProgramLifeSpan_sm;
        /// <summary>
        /// 日
        /// </summary>
        public byte ProgramLifeSpan_sd;
        /// <summary>
        /// 结束年
        /// </summary>
        public ushort ProgramLifeSpan_ey;
        /// <summary>
        /// 结束日
        /// </summary>
        public byte ProgramLifeSpan_em;
        /// <summary>
        /// 结束天
        /// </summary>
        public byte ProgramLifeSpan_ed;
        /// <summary>
        /// 播放时段的组数
        /// </summary>
        public byte PlayPeriodGrpNum;
    }
    /// <summary>
    /// 播放时段共有8组
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogramppGrp_G56
    {
        /// <summary>
        /// 播放时间有效组数 0 没有播放时段全天播放 最大值8 
        /// </summary>
        public byte playTimeGrpNum;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp0;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp1;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp2;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp3;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp4;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp5;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp6;
        /// <summary>
        /// 
        /// </summary>
        public EQprogrampTime_G56 timeGrp7;
    }
    /// <summary>
    /// 节目的播放时段
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQprogrampTime_G56
    {
        /// <summary>
        /// 
        /// </summary>
        public byte StartHour;
        /// <summary>
        /// 
        /// </summary>
        public byte StartMinute;
        /// <summary>
        /// 
        /// </summary>
        public byte StartSecond;
        /// <summary>
        /// 
        /// </summary>
        public byte EndHour;
        /// <summary>
        /// 
        /// </summary>
        public byte EndMinute;
        /// <summary>
        /// 
        /// </summary>
        public byte EndSecond;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public byte FrameDispFlag;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameDispStyle;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameDispSpeed;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameMoveStep;
        /// <summary>
        /// 
        /// </summary>
        public byte FrameWidth;
        /// <summary>
        /// 
        /// </summary>
        public ushort FrameBackup;
    }
    /// <summary>
    /// 6代屏幕边框帧头
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQscreenframeHeader_G6
    {
        /// <summary>
        /// 边框显示方式
        /// 0x00 –闪烁 
        /// 0x01 –顺时针转动 
        /// 0x02 –逆时针转动 
        /// 0x03 –闪烁加顺时针转动 
        /// 0x04 –闪烁加逆时针转动 
        /// 0x05 –红绿交替闪烁 
        /// 0x06 –红绿交替转动 
        /// 0x07 –静止打出
        /// <see cref="E_FrameDisplayMode"/>
        /// </summary>
        public byte FrameDispStype;
        /// <summary>
        /// 边框显示速度
        /// </summary>
        public byte FrameDispSpeed;
        /// <summary>
        /// 边框移动步长
        /// </summary>
        public byte FrameMoveStep;
        /// <summary>
        /// 边框组元长度
        /// </summary>
        public byte FrameUnitLength;
        /// <summary>
        /// 边框组元宽度
        /// </summary>
        public byte FrameUnitWidth;
        /// <summary>
        /// 上下左右边框显示标志位，目前只支持6QX-M卡
        /// </summary>
        public byte FrameDirectDispBit;
    }
    /// <summary>
    /// 第六代语音
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQSound_6G
    {
        /// <summary>
        /// 1 0x00 是否使能语音播放;
        /// 0 表示不使能语音; 1 表示播放下文中 SoundData 部分内容;
        /// </summary>
        public byte SoundFlag;
        /// <summary>
        /// 1 0x00 发音人 该值范围是 0 - 5，共 6 种选择只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        /// </summary>
        public byte SoundPerson;
        /// <summary>
        /// 1 0x05 音量该值范围是 0~10，共 11 种，0表示静音只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        /// </summary>
        public byte SoundVolum;
        /// <summary>
        /// 1 0x05 语速该值范围是 0~10，共 11 种只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 5
        /// </summary>
        public byte SoundSpeed;
        /// <summary>
        /// 1 0x00 SoundData 的编码格式：该值意义如下：0x00 GB2312; 0Longx01 GBK; 0x02 BIG5; 0x03 UNICODE只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        /// </summary>
        public byte SoundDataMode;
        /// <summary>
        /// 4 0x00000000 重播次数该值为 0，表示播放 1 次该值为 1，表示播放 2 次
        /// 该值为 0xffffffff，表示播放无限次只有 SoundFlag（是否使能语播放）为 1 时才发送该字节，否则不发送该值默认为 0
        /// </summary>
        public int SoundReplayTimes;
        /// <summary>
        /// 4 0x00000000 重播时间间隔该值表示两次播放语音的时间间隔，单位为 10ms只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送该值默认为 0
        /// </summary>
        public int SoundReplayDelay;
        /// <summary>
        /// 1 0x03 语音参数保留参数长度
        /// </summary>
        public byte SoundReservedParaLen;
        /// <summary>
        /// 1 0 0：自动判断1：数字作号码处理 2：数字作数值处理只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        /// </summary>
        public byte Soundnumdeal;
        /// <summary>
        /// 1 0 0：自动判断语种1：阿拉伯数字、度量单位、特殊符号等合成为中文2：阿拉伯数字、度量单位、特殊符号等合成为英文只有当 SoundFlag 为 1 且 SoundReservedParaLen不为 0才发送此参数（目前只支持中英文）
        /// </summary>
        public byte Soundlanguages;
        /// <summary>
        /// 1 0 0：自动判断发音方式1：字母发音方式2：单词发音方式；只有当 SoundFlag 为 1 且SoundReservedParaLen不为 0才发送此参数
        /// </summary>
        public byte Soundwordstyle;
        /// <summary>
        /// 4 语音数据长度; 只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        /// </summary>
        public int SoundDataLen;
        /// <summary>
        /// N 语音数据只有 SoundFlag（是否使能语音播放）为 1 时才发送该字节，否则不发送
        /// </summary>
        public IntPtr SoundData;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQSoundDepend_6G
    {
        /// <summary>
        /// 1 1 语音队列中每个语音的 ID，从 0 开始
        /// </summary>
        public byte VoiceID;
        /// <summary>
        /// 
        /// </summary>
        public EQSound_6G stSound;
    }
    /// <summary>
    /// 时间分区战斗时间
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQTimeAreaBattle_G6
    {
        /// <summary>
        /// 起始年份（BCD格式，下同）
        /// </summary>
        public ushort BattleStartYear;
        /// <summary>
        /// 起始月份
        /// </summary>
        public byte BattleStartMonth;
        /// <summary>
        /// 起始日期
        /// </summary>
        public byte BattleStartDate;
        /// <summary>
        /// 起始小时
        /// </summary>
        public byte BattleStartHour;
        /// <summary>
        /// 起始分钟
        /// </summary>
        public byte BattleStartMinute;
        /// <summary>
        /// 起始秒钟
        /// </summary>
        public byte BattleStartSecond;
        /// <summary>
        /// 起始星期值
        /// </summary>
        public byte BattleStartWeek;
        /// <summary>
        /// 启动模式
        /// </summary>
        public byte StartUpMode;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQtimeAreaData_G56
    {
        /// <summary>
        /// 排列方式，单行还是多行
        /// </summary>
        public E_arrMode linestyle;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public uint color;
        /// <summary>
        /// 字体名字
        /// </summary>
        public string fontName;
        /// <summary>
        /// 字体大小
        /// </summary>
        public ushort fontSize;
        /// <summary>
        /// 字体加粗
        /// </summary>
        public byte fontBold;
        /// <summary>
        /// 斜体
        /// </summary>
        public byte fontItalic;
        /// <summary>
        /// 字体加下划线
        /// </summary>
        public byte fontUnderline;
        /// <summary>
        /// 对齐方式--多行有效
        /// </summary>
        public byte fontAlign;
        /// <summary>
        /// 是否添加日期
        /// </summary>
        public byte date_enable;
        /// <summary>
        /// 日期格式
        /// </summary>
        public E_DateStyle datestyle;
        /// <summary>
        /// 是否添加时间---默认添加
        /// </summary>
        public byte time_enable;
        /// <summary>
        /// 时间格式
        /// </summary>
        public E_TimeStyle timestyle;
        /// <summary>
        /// 是否添加星期
        /// </summary>
        public byte week_enable;
        /// <summary>
        /// 星期格式
        /// </summary>
        public E_WeekStyle weekstyle;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQunitHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort UnitX;
        /// <summary>
        /// 
        /// </summary>
        public ushort UnitY;
        /// <summary>
        /// 
        /// </summary>
        public byte UnitType;
        /// <summary>
        /// 
        /// </summary>
        public byte Align;
        /// <summary>
        /// 
        /// </summary>
        public byte UnitColor;
        /// <summary>
        /// 
        /// </summary>
        public byte UnitMode;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileAttribute_G56
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] fileName;
        /// <summary>
        /// 文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 文件长度
        /// </summary>
        public int fileLen;
        /// <summary>
        /// 文件CRC校验
        /// </summary>
        public int fileCRC;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileCRC16_G56
    {
        /// <summary>
        /// 文件地址指針
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 文件长度
        /// </summary>
        public ushort fileLen;
        /// <summary>
        /// 文件CRC16校验
        /// </summary>
        public ushort fileCRC16;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FileCRC32_G56
    {
        /// <summary>
        /// 文件地址指針
        /// </summary>
        public IntPtr fileAddre;
        /// <summary>
        /// 文件长度
        /// </summary>
        public ushort fileLen;
        /// <summary>
        /// 文件CRC32校验
        /// </summary>
        public ushort fileCRC32;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GetDirBlock_G56
    {
        /// <summary>
        /// 要获取的文件类型
        /// </summary>
        public byte fileType;
        /// <summary>
        /// 返回有多少个文件
        /// </summary>
        public ushort fileNumber;
        /// <summary>
        /// 返回文件列表地址
        /// </summary>
        public IntPtr dataAddre;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct GetPageData
    {
        /// <summary>
        /// 
        /// </summary>
        public ushort allPageNub;
        /// <summary>
        /// 
        /// </summary>
        public uint pageLen;
        /// <summary>
        /// 
        /// </summary>
        public byte[] fileAddre;
    }
    /// <summary>
    /// 心跳数据
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HeartbeatData
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string password;
        /// <summary>
        /// 控制器IP地址
        /// </summary>
        public string ip;
        /// <summary>
        /// 子网掩码
        /// </summary>
        public string subNetMask;
        /// <summary>
        /// 网关
        /// </summary>
        public string gate;
        /// <summary>
        /// 端口
        /// </summary>
        public short port;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string mac;
        /// <summary>
        /// 控制器网络ID
        /// </summary>
        public string netID;
    }
    /// <summary>
    /// 搜索命令结果
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct NetSearchCmdRet
    {
        ///// <summary>
        ///// 1 0xA4 命令组
        ///// </summary>
        //public byte CmdGroup;
        ///// <summary>
        ///// 1 0x83 命令编号
        ///// </summary>
        //public byte Cmd;
        ///// <summary>
        ///// 2 控制器状态
        ///// </summary>
        //public ushort Status;
        ///// <summary>
        ///// 2 错误状态寄存器
        ///// </summary>
        //public ushort Error;
        ///// <summary>
        ///// 2 0xA4 数据长度
        ///// </summary>
        //public ushort DataLen;	
        /// <summary>
        /// 6 Mac 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Mac;
        /// <summary>
        /// 4 控制器 IP 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] IP;
        /// <summary>
        /// 4 子网掩码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SubNetMask;
        /// <summary>
        /// 4 网关
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Gate;
        /// <summary>
        /// 2 端口
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public ushort Port;
        /// <summary>
        /// 1 1 表示 DHCP 2 表示手动设置
        /// </summary>
        public byte IPMode;
        /// <summary>
        /// 1 0 表示 IP 设置失败 1 表示 IP 设置成功
        /// </summary>
        public byte IPStatus;
        /// <summary>
        /// 1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
        /// </summary>
        public byte ServerMode;
        /// <summary>
        /// 4 服务器 IP 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ServerIPAddress;
        /// <summary>
        /// 2 服务器端口号
        /// </summary>
        public ushort ServerPort;
        /// <summary>
        /// 8 服务器访问密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] ServerAccessPassword;
        /// <summary>
        /// 2 20S 心跳时间间隔（单位：秒）
        /// </summary>
        public ushort HeartBeatInterval;
        /// <summary>
        /// 12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] CustomID;
        ////Web 模式下参见下面的数据结构：NetSearchCmdRet_Web   返回下述 5 项的实际值，否则不上传下述 5 项
        ///// <summary>
        ///// 128 0 WEB 平台用户 id
        ///// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        //public byte[] WebUserID;
        ///// <summary>
        ///// 4 0 屏幕组号
        ///// </summary>
        //public uint GroupNum;
        ///// <summary>
        ///// 1 0 域名标志 0 - 无域名，1—域名
        ///// </summary>
        //public byte DomainFlag;
        ///// <summary>
        ///// 128 域名名称 当 DomainFlag 为 1 时下发
        ///// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        //public byte[] DomainName;
        ///// <summary>
        ///// 128 LED00001 WEB 平台控制器名称
        ///// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        //public byte[] WebControllerName[];
        ////Web 模式下返回结束 ==================================================
        /// <summary>
        /// 16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BarCode;
        /// <summary>
        /// 2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] ControllerType;
        /// <summary>
        /// 8 Firmware 版本号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareVersion;
        /// <summary>
        /// 1 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
        /// </summary>
        public byte ScreenParaStatus;
        /// <summary>
        /// 2 0x0001 控制器地址控制器出厂默认地址为 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
        /// </summary>
        public ushort Address;
        /// <summary>
        /// 1 0x00 波特率 0x00 –保持原有波特率不变 0x01 –强制设置为 9600 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 2 192 显示屏宽度
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 2 96 显示屏高度
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 1 0x01 对于无灰度系统，单色时返回 1，双色时返回 3，三色时返回 7；对于有灰度系统，返回 255
        /// </summary>
        public byte Color;
        /// <summary>
        /// 1 调亮模式 0x00 –手动调亮 0x01 –定时调亮 0x02 –自动调亮
        /// </summary>
        public byte BrightnessAdjMode;
        /// <summary>
        /// 1 当前亮度值
        /// </summary>
        public byte CurrentBrigtness;
        /// <summary>
        /// 1 Bit0 –定时开关机状态，0 表示无定时开关机，1 表示有定时开关机
        /// </summary>
        public byte TimingOnOff;
        /// <summary>
        /// 1 开关机状态
        /// </summary>
        public byte CurrentOnOffStatus;
        /// <summary>
        /// 2 扫描配置编号
        /// </summary>
        public ushort ScanConfNumber;
        /// <summary>
        /// 1 一路数据带几行
        /// </summary>
        public byte RowsPerChanel;
        /// <summary>
        /// 1 对于无灰度系统，返回 0；对于有灰度系
        /// </summary>
        public byte GrayFlag;
        /// <summary>
        /// 2 最小单元宽度
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] UnitWidth;
        /// <summary>
        /// 1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
        /// </summary>
        public byte modeofdisp;
        /// <summary>
        /// 1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
        /// </summary>
        public byte NetTranMode;
        /// <summary>
        /// 1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
        /// </summary>
        public byte PackageMode;
        /// <summary>
        /// 1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
        /// </summary>
        public byte BarcodeFlag;
        /// <summary>
        /// 2 控制器上已有节目个数
        /// </summary>
        public ushort ProgramNumber;
        /// <summary>
        /// 4 当前节目名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] CurrentProgram;
        /// <summary>
        /// 1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
        /// </summary>
        public byte ScreenLockStatus;
        /// <summary>
        /// 1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
        /// </summary>
        public byte ProgramLockStatus;
        /// <summary>
        /// 1 控制器运行模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
        /// </summary>
        public byte RTCStatus;
        /// <summary>
        /// 2 年
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] RTCYear;
        /// <summary>
        /// 1 月
        /// </summary>
        public byte RTCMonth;
        /// <summary>
        /// 1 日
        /// </summary>
        public byte RTCDate;
        /// <summary>
        /// 1 小时
        /// </summary>
        public byte RTCHour;
        /// <summary>
        /// 1 分钟
        /// </summary>
        public byte RTCMinute;
        /// <summary>
        /// 1 秒
        /// </summary>
        public byte RTCSecond;
        /// <summary>
        /// 1 星期，范围为 1~7，7 表示周日
        /// </summary>
        public byte RTCWeek;
        /// <summary>
        /// 3 温度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Temperature1;
        /// <summary>
        /// 3 温度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Temperature2;
        /// <summary>
        /// 2 湿度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Humidity;
        /// <summary>
        /// 2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Noise;
        /// <summary>
        /// 1 保留字节
        /// </summary>
        public byte Reserved;
        /// <summary>
        /// 1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
        /// </summary>
        public byte LogoFlag;
        /// <summary>
        /// 2 0：未设置开机延时 1：开机延时时长
        /// </summary>
        public ushort PowerOnDelay;
        /// <summary>
        /// 2 风速(除以 10 为当前值) 0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] WindSpeed;
        /// <summary>
        /// 2 风向(当前值) 0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] WindDirction;
        /// <summary>
        /// 2 PM2.5 值(当前值)0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] PM2_5;
        /// <summary>
        /// 2 PM10 值(当前值)0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] PM10;
        ///// <summary>
        ///// 24 保留字
        ///// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        //public byte[] Reserved2;	
        /// <summary>
        /// 2 0x40 扩展参数长度
        /// </summary>
        public ushort ExtendParaLen;
        /// <summary>
        /// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ControllerName;
        /// <summary>
        /// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
        public byte[] ScreenLocation;
        /// <summary>
        /// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NameLocalationCRC32;
        /// <summary>
        /// 2 风向(当前值) 0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] PM100;
        /// <summary>
        /// 2 PM2.5 值(当前值)0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] AtmosphericPressure;
        /// <summary>
        /// 2 PM10 值(当前值)0xfffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] illumination;
        /// <summary>
        /// 128 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] ReserveSafe;
    }
    /// <summary>
    /// 网络搜索结果
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct NetSearchCmdRet_Web
    {
        ///// <summary>
        ///// 1 0xA4 命令组 
        ///// </summary>
        //public byte CmdGroup;
        ///// <summary>
        ///// 1 0x83 命令编号
        ///// </summary>
        //public byte Cmd;
        ///// <summary>
        ///// 2 控制器状态
        ///// </summary>
        //public byte Status;
        ///// <summary>
        ///// 2 错误状态寄存器
        ///// </summary>
        //public ushort Error;
        ///// <summary>
        ///// 2 0xA4 数据长度
        ///// </summary>
        //public ushort DataLen;
        /// <summary>
        /// 6 Mac 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] Mac = new byte[6];
        /// <summary>
        /// 4 控制器 IP 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] IP = new byte[4];
        /// <summary>
        /// 4 子网掩码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SubNetMask = new byte[4];
        /// <summary>
        /// 4 网关
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Gate = new byte[4];
        /// <summary>
        /// 2 端口
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Port = new byte[2];
        /// <summary>
        /// 1 1 表示 DHCP 2 表示手动设置
        /// </summary>
        public byte IPMode;
        /// <summary>
        /// 1 0 表示 IP 设置失败 1 表示 IP 设置成功
        /// </summary>
        public byte IPStatus;
        /// <summary>
        /// 1 0 Bit[0]表示服务器模式是否使能：1 –使能，0 –禁止 Bit[1]表示服务器模式：1 –web 模式，0 –普通模式
        /// </summary>
        public byte ServerMode;
        /// <summary>
        /// 4 服务器 IP 地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ServerIPAddress = new byte[4];
        /// <summary>
        /// 2 服务器端口号
        /// </summary>
        public ushort ServerPort;
        /// <summary>
        /// 8 服务器访问密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] ServerAccessPassword = new byte[8];
        /// <summary>
        /// 2 20S 心跳时间间隔（单位：秒）
        /// </summary>
        public ushort HeartBeatInterval;
        /// <summary>
        /// 12 用户自定义 ID，作为网络 ID 的前半部分，便于用户识别其控制卡
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] CustomID = new byte[12];
        //  Web 模式下返回下述 5 项的实际值，否则不上传下述 5 项
        /// <summary>
        /// 128 0 WEB 平台用户 id
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] WebUserID = new byte[128];
        /// <summary>
        /// 4 0 屏幕组号
        /// </summary>
        public int GroupNum;
        /// <summary>
        /// 1 0 域名标志 0 - 无域名，1—域名
        /// </summary>
        public byte DomainFlag;
        /// <summary>
        /// 128 域名名称 当 DomainFlag 为 1 时下发
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] DomainName = new byte[128];
        /// <summary>
        /// 128 LED00001 WEB 平台控制器名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] WebControllerName = new byte[128];
        //Web 模式下返回下述 5 项 结束 ###################
        /// <summary>
        /// 16 条形码，作为网络 ID 的后半部分，用以实现网络 ID 的唯一性
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] BarCode = new byte[16];
        /// <summary>
        /// 2 其中低位字节表示设备系列，而高位字节表示设备编号，例如 BX - 6Q2 应表示为[0x66, 0x02]，其它型号依此类推。
        /// </summary>
        public ushort ControllerType;
        /// <summary>
        /// 8 Firmware 版本号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareVersion = new byte[8];
        /// <summary>
        /// 1 控制器参数文件状态 
        /// 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。此时，PC软件应提示用户必须先加载屏参。
        /// 0x01 –控制器中有参数配置文件
        /// </summary>
        public byte ScreenParaStatus;
        /// <summary>
        /// 2 0x0001 控制器地址控制器出厂默认地址为 
        /// 0x0001(0x0000 地址将保留)控制除了对发送给自身地址的数据包进行处理外，还需对广播数据包进行处理。
        /// </summary>
        public ushort Address;
        /// <summary>
        /// 1 0x00 波特率 
        /// 0x00 –保持原有波特率不变 
        /// 0x01 –强制设置为 9600 
        /// 0x02 –强制设置为 57600
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 2 192 显示屏宽度
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 2 96 显示屏高度
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 1 0x01 对于无灰度系统，
        /// 单色时返回 1，
        /// 双色时返回 3，
        /// 三色时返回 7；
        /// 对于有灰度系统，返回 255
        /// </summary>
        public byte Color;
        /// <summary>
        /// 1 调亮模式 
        /// 0x00 –手动调亮 
        /// 0x01 –定时调亮 
        /// 0x02 –自动调亮
        /// </summary>
        public byte BrightnessAdjMode;
        /// <summary>
        /// 1 当前亮度值
        /// </summary>
        public byte CurrentBrigtness;
        /// <summary>
        /// 1 Bit0 –定时开关机状态，
        /// 0 表示无定时开关机，
        /// 1 表示有定时开关机
        /// </summary>
        public byte TimingOnOff;
        /// <summary>
        /// 1 开关机状态
        /// </summary>
        public byte CurrentOnOffStatus;
        /// <summary>
        /// 2 扫描配置编号
        /// </summary>
        public ushort ScanConfNumber;
        /// <summary>
        /// 1 一路数据带几行
        /// </summary>
        public byte RowsPerChanel;
        /// <summary>
        /// 1 对于无灰度系统，返回 0；对于有灰度系
        /// </summary>
        public byte GrayFlag;
        /// <summary>
        /// 2 最小单元宽度
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] UnitWidth = new byte[2];
        /// <summary>
        /// 1 6Q 显示模式 : 0 为 888, 1 为 565，其余卡为 0
        /// </summary>
        public byte modeofdisp;
        /// <summary>
        /// 1 当该字节为 0 时，网口通讯使用老的模式，即 UDP 和 TCP 均根据下面的PackageMode 字节确定包长，
        /// 并且 UDP通讯时，将大包分为小包，每发送一小包做一下延时当该字节不为 0 时，网口通讯使用新的模式，
        /// 即 UDP 的包长等于UDPPackageMode * 8KBYTE，且不再分为小包，将整包数据丢给协议栈TCP 的包长等于 PackageMode * 16KBYTE
        /// </summary>
        public byte NetTranMode;
        /// <summary>
        /// 1 包模式。0 小包模式，分包 600 byte。1 大包模式，分包 16K byte。
        /// </summary>
        public byte PackageMode;
        /// <summary>
        /// 1 是否设置了条码 ID如果设置了，该字节第 0 位为 1，否则为0
        /// </summary>
        public byte BarcodeFlag;
        /// <summary>
        /// 2 控制器上已有节目个数
        /// </summary>
        public ushort ProgramNumber;
        /// <summary>
        /// 4 当前节目名
        /// </summary>
        public int CurrentProgram;
        /// <summary>
        /// 1 Bit0 –是否屏幕锁定，1b’0 –无屏幕锁定，1b’1 –屏幕锁定
        /// </summary>
        public byte ScreenLockStatus;
        /// <summary>
        /// 1 Bit0 –是否节目锁定，1b’0 –无节目锁定，1’b1 –节目锁定
        /// </summary>
        public byte ProgramLockStatus;
        /// <summary>
        /// 1 控制器运行模式
        /// </summary>
        public byte RunningMode;
        /// <summary>
        /// 1 RTC 状态 0x00 – RTC 异常 0x01 – RTC 正常
        /// </summary>
        public byte RTCStatus;
        /// <summary>
        /// 2 年
        /// </summary>
        public ushort RTCYear;
        /// <summary>
        /// 1 月
        /// </summary>
        public byte RTCMonth;
        /// <summary>
        /// 1 日
        /// </summary>
        public byte RTCDate;
        /// <summary>
        /// 1 小时
        /// </summary>
        public byte RTCHour;
        /// <summary>
        /// 1 分钟
        /// </summary>
        public byte RTCMinute;
        /// <summary>
        /// 1 秒
        /// </summary>
        public byte RTCSecond;
        /// <summary>
        /// 1 星期，范围为 1~7，7 表示周日
        /// </summary>
        public byte RTCWeek;
        /// <summary>
        /// 3 温度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Temperature1 = new byte[3];
        /// <summary>
        /// 3 温度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Temperature2 = new byte[3];
        /// <summary>
        /// 2 湿度传感器当前值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Humidity = new byte[2];
        /// <summary>
        /// 2 噪声传感器当前值(除以 10 为当前值)针对 BX - ZS(485) 0xffff 时无效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Noise = new byte[2];
        /// <summary>
        /// 1 保留字节
        /// </summary>
        public byte Reserved;
        /// <summary>
        /// 1 0：表示未设置 Logo 节目 1：表示设置了 Logo 节目
        /// </summary>
        public byte LogoFlag;
        /// <summary>
        /// 2 0：未设置开机延时 1：开机延时时长
        /// </summary>
        public ushort PowerOnDelay;
        /// <summary>
        /// 2 风速(除以 10 为当前值) 0xfffff 时无效
        /// </summary>
        public ushort WindSpeed;
        /// <summary>
        /// 2 风向(当前值) 0xfffff 时无效
        /// </summary>
        public ushort WindDirction;
        /// <summary>
        /// 2 PM2.5 值(当前值)0xfffff 时无效
        /// </summary>
        public ushort PM2_5;
        /// <summary>
        /// 2 PM10 值(当前值)0xfffff 时无效
        /// </summary>
        public ushort PM10;
        //byte Reserved2[24];	//24 保留字
        /// <summary>
        /// 2 0x40 扩展参数长度
        /// </summary>
        public ushort ExtendParaLen;
        /// <summary>
        /// 16 LEDCON01 控制器名称限制为 16 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ControllerName = new byte[16];
        /// <summary>
        /// 44 0 屏幕安装地址限制为 44 个字节长度(全是 0x00 表示屏参丢失，参数无效，上位机空白显示)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
        public byte[] ScreenLocation = new byte[44];
        /// <summary>
        /// 4 控制器和屏幕安装地址共 60 个字节的CRC32 校验值，该值是为了便于上位机区分此处 64 个字节是表示控制器名称还是用来表示控制器名称和屏幕安装地址，进而采取不同的处理策略为了保持兼容，下位机不对该值进行验证
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NameLocalationCRC32 = new byte[4];
        /// <summary>
        /// 构造
        /// </summary>
        public NetSearchCmdRet_Web()
        {
        }
    }
    /// <summary>
    /// 屏幕数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Ping_data
    {
        /// <summary>
        /// 控制器类型
        /// 小端存储低位在前高位在后， 比如 0x254 反着取，低位表示系列，高位编号  [0x54, 0x02] 【系列，编号】
        /// </summary>
        public ushort ControllerType;
        /// <summary>
        /// 固件版本号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareVersion;
        /// <summary>
        /// 控制器参数文件状态 0x00 –控制器中没有参数配置文件，以下返回的是控制器的默认参数。 此时， PC 软件应提示用户必须先加载屏参。0x01 –控制器中有参数配置文件
        /// </summary>
        public byte ScreenParaStatus;
        /// <summary>
        /// 控制器地址
        /// </summary>
        public ushort uAddress;
        /// <summary>
        /// 波特率
        /// </summary>
        public byte Baudrate;
        /// <summary>
        /// 屏宽
        /// </summary>
        public ushort ScreenWidth;
        /// <summary>
        /// 屏高
        /// </summary>
        public ushort ScreenHeight;
        /// <summary>
        /// 显示屏颜色定义
        /// </summary>
        public byte Color;
        /// <summary>
        /// 当前亮度值   整数1-16
        /// </summary>
        public byte CurrentBrigtness;
        /// <summary>
        /// 控制器开关机状态   0 关机  1开机？
        /// </summary>
        public byte CurrentOnOffStatus;
        /// <summary>
        /// 扫描配置编号
        /// </summary>
        public ushort ScanConfNumber;
        /// <summary>
        /// 第一个自己一路数据代几行，其他基本用不上，如有需要可参考协议取相应的字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] reversed;
        /// <summary>
        /// 控制器ip地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] ipAdder;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TimingOnOff
    {
        /// <summary>
        /// 开机小时
        /// </summary>
        public byte onHour;
        /// <summary>
        /// 开机分钟
        /// </summary>
        public byte onMinute;
        /// <summary>
        /// 关机小时
        /// </summary>
        public byte offHour;
        /// <summary>
        /// 关机分钟
        /// </summary>
        public byte offMinute;
    }
    /// <summary>
    /// 
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TimingReset
    {
        /// <summary>
        /// 复位模式 0x00 –取消定时复位功能 0x01 –周期复位， 此时 RstInterval 字段有效 0x02 –只在指定时间复位
        /// </summary>
        public byte rstMode;
        /// <summary>
        /// 复位周期， 单位： 分钟如此字段为 0， 不进行复位操作
        /// </summary>
        public uint RstInterval;
        /// <summary>
        /// 小时 0Xff–表示此组无效， 下同
        /// </summary>
        public byte rstHour1;
        /// <summary>
        /// 
        /// </summary>
        public byte rstMin1;
        /// <summary>
        /// 
        /// </summary>
        public byte rstHour2;
        /// <summary>
        /// 
        /// </summary>
        public byte rstMin2;
        /// <summary>
        /// 
        /// </summary>
        public byte rstHour3;
        /// <summary>
        /// 
        /// </summary>
        public byte rstMin3;
    }
}
