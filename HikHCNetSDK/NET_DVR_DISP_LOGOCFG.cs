using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //上传logo结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISP_LOGOCFG
    {
        public uint dwCorordinateX;//图片显示区域X坐标
        public uint dwCorordinateY;//图片显示区域Y坐标
        public ushort wPicWidth; //图片宽
        public ushort wPicHeight; //图片高
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byFlash;//是否闪烁1-闪烁，0-不闪烁
        public byte byTranslucent;//是否半透明1-半透明，0-不半透明
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留
        public uint dwLogoSize;//LOGO大小，包括BMP的文件头
    }
}
