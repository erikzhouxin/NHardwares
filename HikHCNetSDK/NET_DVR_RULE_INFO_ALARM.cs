using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RULE_INFO_ALARM
    {
        public uint dwSize;             // 结构体大小
        public uint dwRelativeTime;     // 相对时标
        public uint dwAbsTime;          // 绝对时标
        public NET_VCA_DEV_INFO struDevInfo;        // 前端设备信息
        public NET_DVR_EVENT_INFO_LIST struEventInfoList;   //事件信息列表
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           // 保留字节
    }



}
