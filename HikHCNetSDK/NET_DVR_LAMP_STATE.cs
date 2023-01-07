using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //指示灯外控
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_LAMP_STATE
    {
        public byte byFlicker;//0~不闪烁 1 ～闪烁
        public byte byParkingIndex;//车位号1～3
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwIONo;//1~IO1;2~IO2;4~IO3;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
