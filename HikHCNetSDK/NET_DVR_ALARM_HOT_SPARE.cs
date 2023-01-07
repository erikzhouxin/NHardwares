using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARM_HOT_SPARE
    {
        public uint dwSize;   //结构体
        public uint dwExceptionCase;   //报警原因   0-网络异常
        public NET_DVR_IPADDR struDeviceIP;    //产生异常的设备IP地址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;         //保留
    }

}
