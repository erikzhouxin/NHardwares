using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_ALARM
    {
        public uint dwSize;          //结构体大小
        public uint dwRelativeTime;  //相对时标
        public uint dwAbsTime;       //绝对时标
        public NET_VCA_DEV_INFO struDevInfo;     //前端设备信息
        public NET_DVR_TPS_INFO struTPSInfo;     //交通事件信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;      //保留字节
    }



}
