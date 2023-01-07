using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VCA_DEV_WORKSTATUS
    {
        public uint dwSize;         // 结构体大小
        public byte byDeviceStatus; // 设备的状态0 - 正常工作 1- 不正常工作
        public byte byCpuLoad;      // CPU使用率0-100 分别代表使用百分率
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VCA_CHAN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_VCA_CHAN_WORKSTATUS[] struVcaChanStatus;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRes;        // 保留字节
    }
}
