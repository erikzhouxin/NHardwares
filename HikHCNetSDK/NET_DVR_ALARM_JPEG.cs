using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARM_JPEG
    {
        public byte byPicProType;       /*报警时图片处理方式 0-不处理 1-上传*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;           //保留字节
        public NET_DVR_JPEGPARA struPicParam;               /*图片规格结构*/
    }
}
