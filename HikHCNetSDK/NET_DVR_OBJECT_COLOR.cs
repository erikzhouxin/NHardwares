using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //物体颜色参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OBJECT_COLOR
    {
        public uint dwSize;       //结构体大小
        public byte byEnable;     //0-不启用，1-启用
        public byte byColorMode;  //取色方式，1-颜色值，2-图片
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;    //保留
        public NET_DVR_OBJECT_COLOR_UNION uObjColor; //物体颜色联合体，取值依赖于取色方式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;   //保留
    }
}
