using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图片参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PIC
    {
        public byte byPicType;        //图片类型，1-jpg
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;        //保留
        public uint dwPicWidth;       //图片宽度
        public uint dwPicHeight;      //图片高度
        public uint dwPicDataLen;     //图片数据实际大小
        public uint dwPicDataBuffLen; //图片数据缓冲区大小
        public IntPtr byPicDataBuff;    //图片数据缓冲区
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;       //保留
    }
}
