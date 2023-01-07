using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //夏令时参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ZONEANDDST
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        public uint dwEnableDST;//是否启用夏时制 0－不启用 1－启用
        public byte byDSTBias;//夏令时偏移值，30min, 60min, 90min, 120min, 以分钟计，传递原始数值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_TIMEPOINT struBeginPoint;//夏时制开始时间
        public NET_DVR_TIMEPOINT struEndPoint;//夏时制停止时间
    }
}
