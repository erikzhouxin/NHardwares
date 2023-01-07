using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //TPS实时过车数据上传
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_REAL_TIME_INFO
    {
        public uint dwSize;          // 结构体大小
        public uint dwChan;//通道号
        public NET_DVR_TIME_V30 struTime;    //检测时间
        public NET_DVR_TPS_PARAM struTPSRealTimeInfo;// 交通参数统计信息
        public IntPtr pAddInfoBuffer;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        /*附加信息标识（即是否有NET_DVR_TPS_ADDINFO结构体）,0-无附加信息, 1-有附加信息。*/
        public byte byAddInfoFlag;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      // 保留
    }



}
