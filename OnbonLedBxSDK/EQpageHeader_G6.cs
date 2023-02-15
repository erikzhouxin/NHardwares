using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQpageHeader_G6
    {
        public byte PageStyle;          //数据页类型
        public byte DisplayMode;        //显示方式
        public byte ClearMode;          //退出方式/清屏方式
        public byte Speed;              //速度等级
        public ushort StayTime;         //停留时间
        public byte RepeatTime;     //重复次数
        public ushort ValidLen;         //此字段只在左移右移方式下有效
        public byte CartoonFrameRate;  //特技为动画方式时，该值代表其帧率
        public byte BackNotValidFlag;  //背景无效标志
        public E_arrMode arrMode;           //排列方式--单行多行
        public ushort fontSize;         //字体大小
        public uint color;              //字体颜色
        public byte fontBold;           //是否为粗体 0:false 1:true
        public byte fontItalic;     //是否为斜体
        public E_txtDirection tdirection;   //文字方向
        public ushort txtSpace;         //文字间隔   	
        public byte Valign;
        public byte Halign;
    }
}
