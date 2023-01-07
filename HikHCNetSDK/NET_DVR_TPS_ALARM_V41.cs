using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //交通统计信息报警(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_ALARM_V41
    {
        public uint dwSize;          // 结构体大小
        public uint dwRelativeTime;  // 相对时标
        public uint dwAbsTime;       // 绝对时标
        public NET_VCA_DEV_INFO struDevInfo;     // 前端设备信息
        public NET_DVR_TPS_INFO_V41 struTPSInfo;     // 交通参数统计信息 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      // 保留
    }



}
