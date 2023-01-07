using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2009-12-16 增加控制解码器解码通道缩放
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_DECCHAN_CONTROL
    {
        public uint dwSize;
        public byte byDecChanScaleStatus;/*解码通道显示缩放控制,1表示缩放显示，0表示真实显示*/
        public byte byDecodeDelay;//解码延时，0-默认，1-实时性好，2-实时性较好，3-实时性中，流畅性中，4-流畅性较好，5-流畅性好，0xff-自动调整   
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 66, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
