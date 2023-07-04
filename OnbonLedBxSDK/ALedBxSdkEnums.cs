using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.OnbonLedBxSDK
{
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
}
