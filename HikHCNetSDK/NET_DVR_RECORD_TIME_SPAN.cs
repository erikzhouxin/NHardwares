using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECORD_TIME_SPAN
    {
        public uint dwSize;        //结构体大小
        public NET_DVR_TIME strBeginTime;  //开始时间
        public NET_DVR_TIME strEndTime;    //结束时间
        public byte byType;        //0 正常音视频录像, 1图片通道录像, 2ANR通道录像, 3抽帧通道录像
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 35, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
    }
}
