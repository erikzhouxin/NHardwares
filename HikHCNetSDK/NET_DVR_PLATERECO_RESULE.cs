using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLATERECO_RESULE
    {
        public uint dwSize;
        public uint dwRelativeTime; //相对时标
        public uint dwAbsTime;  //绝对时标
        public NET_VCA_DEV_INFO struDevInfo; // 前段设备信息
        public NET_DVR_PLATE_INFO struPlateInfo;
        public uint dwPicDataLen;   //返回图片的长度 为0表示没有图片，大于0表示该结构后面紧跟图片数据
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;    //保留，设置为0
        public IntPtr pImage;   //指向图片的指针
    }



}
