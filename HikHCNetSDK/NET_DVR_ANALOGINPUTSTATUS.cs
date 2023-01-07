using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************输入信号状态*******************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ANALOGINPUTSTATUS
    {
        public uint dwLostFrame;        /*视频输入丢帧数*/
        public byte byHaveSignal;       /*是否有视频信号输入*/
        public byte byVideoFormat;      /*视频制式，1：NTSC,2：PAL,0：无*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 46, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
