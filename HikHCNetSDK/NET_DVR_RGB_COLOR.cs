using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_RGB_COLOR
    {
        public byte byRed;   //RGB颜色三分量中的红色
        public byte byGreen; //RGB颜色三分量中的绿色
        public byte byBlue; //RGB颜色三分量中的蓝色
        public byte byRes;  //保留
    }
}
