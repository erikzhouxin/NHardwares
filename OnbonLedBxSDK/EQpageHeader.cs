using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQpageHeader
    {
        //请参考协议 图文字幕区数据格式
        public byte PageStyle; //数据页类型
        public byte DisplayMode; //显示方式 （特效）
        public byte ClearMode; // 退出方式/清屏方式
        public byte Speed; // 速度等级/背景速度等级
        public ushort StayTime; // 停留时间， 单位为 10ms
        public byte RepeatTime;//重复次数/背景拼接步长(左右拼接下为宽度， 上下拼接为高度)
        public ushort ValidLen;  //用法比较复杂请参考协议
        public E_arrMode arrMode; //排列方式--单行多行
        public ushort fontSize; //字体大小
        public uint color;//字体颜色
        public byte fontBold; //是否为粗体
        public byte fontItalic;//是否为斜体
        public E_txtDirection tdirection;//文字方向
        public ushort txtSpace; //文字间隔  	
        public byte Valign;
        public byte Halign;
    }
}
