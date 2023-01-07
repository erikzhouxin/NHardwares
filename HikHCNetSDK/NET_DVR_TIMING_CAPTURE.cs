using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TIMING_CAPTURE
    {
        public NET_DVR_JPEGPARA struJpegPara;   // 定时抓图图片质量
        public uint dwPicInterval; //定时抓图时间间隔,单位s   1-1s 2-2s 3-3s 4-4s 5-5s 
                                   //6-10m 7-30m 8-1h 9-12h 10-24h
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      // 保留字节
    }
}
