using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************获取设备状态*******************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEVICE_RUN_STATUS
    {
        public uint dwSize;
        public uint dwMemoryTotal;      //内存总量	单位Kbyte
        public uint dwMemoryUsage;      //内存使用量 单位Kbyte
        public byte byCPUUsage;         //CPU使用率 0-100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
