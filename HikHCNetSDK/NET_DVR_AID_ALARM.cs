using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通事件报警 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AID_ALARM
    {
        public uint dwSize;         // 结构长度
        public uint dwRelativeTime; // 相对时标
        public uint dwAbsTime;      // 绝对时标
        public NET_VCA_DEV_INFO struDevInfo;    // 前端设备信息
        public NET_DVR_AID_INFO struAIDInfo;    // 交通事件信息
        public uint dwPicDataLen;   // 返回图片的长度 为0表示没有图片，大于0表示该结构后面紧跟图片数据
        public IntPtr pImage;        // 指向图片的指针
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      // 保留字节  
    }



}
