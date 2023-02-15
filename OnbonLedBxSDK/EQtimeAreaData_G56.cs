using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQtimeAreaData_G56
    {
        public E_arrMode linestyle;         //排列方式，单行还是多行
        public uint color;              //字体颜色
        public string fontName;           //字体名字
        public ushort fontSize;           //字体大小
        public byte fontBold;           //字体加粗
        public byte fontItalic;         //斜体
        public byte fontUnderline;      //字体加下划线
        public byte fontAlign;          //对齐方式--多行有效
        public byte date_enable;        //是否添加日期
        public E_DateStyle datestyle;           //日期格式
        public byte time_enable;        //是否添加时间---默认添加
        public E_TimeStyle timestyle;           //时间格式
        public byte week_enable;        //是否添加星期
        public E_WeekStyle weekstyle;           //星期格式
    }
}
