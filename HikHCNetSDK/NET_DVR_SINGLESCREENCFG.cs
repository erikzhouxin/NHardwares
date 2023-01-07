using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLESCREENCFG
    {
        public byte byScreenSeq;//屏幕序号，0xff表示不用此屏,64-T解码器第一个表示主屏
        public byte bySubSystemNum;//解码子系统槽位号,解码器此值没有用
        public byte byDispNum;//解码子系统上对应显示通道号，64-T解码器中该值表示解码器的显示通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
