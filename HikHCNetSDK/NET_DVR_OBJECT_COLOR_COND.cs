using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //物体颜色条件结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OBJECT_COLOR_COND
    {
        public uint dwChannel;   //通道号
        public uint dwObjType;   //物体类型，参见OBJECT_TYPE_ENUM
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   //保留
    }
}
