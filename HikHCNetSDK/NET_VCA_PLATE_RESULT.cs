using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车牌检测结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_PLATE_RESULT
    {
        public uint dwSize;//结构长度
        public uint dwRelativeTime;//相对时标
        public uint dwAbsTime;//绝对时标
        public byte byPlateNum;//车牌个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_PLATE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_PLATE_INFO[] struPlateInfo;//车牌信息结构
        public uint dwPicDataLen;//返回图片的长度 为0表示没有图片，大于0表示该结构后面紧跟图片数据
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes2;//保留，设置为0 图片的高宽
        public System.IntPtr pImage;//指向图片的指针
    }
}
