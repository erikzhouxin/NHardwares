using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
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
}
