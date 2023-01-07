using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CORRECT_DEADPIXEL_PARAM
    {
        public uint dwSize;
        public uint dwCommand; //命令：0-进入坏点模式，1-添加坏点，2-保存坏点，3-退出坏点
        public uint dwDeadPixelX; //坏点X坐标
        public uint dwDeadPixelY; //坏点Y坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
