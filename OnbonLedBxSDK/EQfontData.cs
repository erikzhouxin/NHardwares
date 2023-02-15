using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct EQfontData
    {
        public E_arrMode arrMode; //排列方式--单行多行  E_arrMode::	eSINGLELINE,   //单行 eMULTILINE,    //多行
        public ushort fontSize; //字体大小
        public uint color;//字体颜色 E_Color_G56 此通过此枚举值可以直接配置七彩色，如果大于枚举范围使用RGB888模式
        public byte fontBold; //是否为粗体
        public byte fontItalic;//是否为斜体
        public E_txtDirection tdirection;//文字方向
        public ushort txtSpace;  //文字间隔   
        public byte Halign; //横向对齐方式（0系统自适应、1左对齐、2居中、3右对齐）
        public byte Valign; //纵向对齐方式（0系统自适应、1上对齐、2居中、3下对齐）
    }
}
