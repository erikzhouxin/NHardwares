using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FLOW_TEST_PARAM
    {
        public uint dwSize;              //结构大小
        public int lCardIndex;         //网卡索引
        public uint dwInterval;         //设备上传流量时间间隔, 单位:100ms
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;           //保留字节
    }
}
