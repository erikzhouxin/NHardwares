using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // ivms 报警图片上传结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_ALARM_JPEG
    {
        public byte byPicProType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_JPEGPARA struPicParam;
    }
}
