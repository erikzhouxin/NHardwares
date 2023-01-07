using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*****************************DS-6001D/F(end)***************************/

    //单字符参数(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_SHOWSTRINGINFO
    {
        public ushort wShowString;// 预览的图象上是否显示字符,0-不显示,1-显示 区域大小704*576,单个字符的大小为32*32
        public ushort wStringSize;/* 该行字符的长度，不能大于44个字符 */
        public ushort wShowStringTopLeftX;/* 字符显示位置的x坐标 */
        public ushort wShowStringTopLeftY;/* 字符名称显示位置的y坐标 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 44)]
        public string sString;/* 要显示的字符内容 */
    }
}
