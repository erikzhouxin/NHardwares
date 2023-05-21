using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
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
}
