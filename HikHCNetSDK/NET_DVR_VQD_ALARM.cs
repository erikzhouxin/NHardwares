using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //视频质量诊断报警结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VQD_ALARM
    {
        public uint dwSize;                //结构体大小
        public uint dwRelativeTime;        //相对时标
        public uint dwAbsTime;            //绝对时标
        public NET_VCA_DEV_INFO struDevInfo; //前端设备信息 
        public uint dwEventType;           //事件类型，参考VQD_EVENT_ENUM
        public float fThreshold;            //报警阈值[0.000,1.000]
        public uint dwPicDataLen;          //图片长度，为0表示没有图片
        public IntPtr pImage;               //指向图片的指针 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            //保留
    }
}
