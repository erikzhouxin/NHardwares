using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //TPS统计过车数据上传
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_STATISTICS_INFO
    {
        public uint dwSize;          // 结构体大小
        public uint dwChan;//通道号
        public NET_DVR_TPS_STATISTICS_PARAM struTPSStatisticsInfo;// 交通参数统计信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      // 保留
    }



}
