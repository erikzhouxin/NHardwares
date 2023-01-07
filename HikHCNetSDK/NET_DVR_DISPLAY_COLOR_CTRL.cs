using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示单元颜色控制
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPLAY_COLOR_CTRL
    {
        public byte byColorType;        //1-亮度 2-对比度 3-饱和度 4-清晰度
        public char byScale;            //-1 、0、+1三个值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 14, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
