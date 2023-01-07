using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //颜色联合体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OBJECT_COLOR_UNION
    {
        public NET_DVR_COLOR struColor;   //颜色值
        public NET_DVR_PIC struPicture; //图片
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   //保留
    }
}
