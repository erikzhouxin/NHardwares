using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*时间显示格式*/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVRT_TIME_FORMAT
    {
        public byte byTimeForm;/*1. HH MM SS;0. HH MM*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byHourMode;/*0,12;1,24*/ //lili mode
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string chSeprator;/*报文分隔符，暂时没用*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string chDisplaySeprator;/*显示分隔符*/
        public byte byDisplayForm;/*0~5，3个item的排列组合*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        public byte byDisplayHourMode;/*0,12;1,24*/ //lili mode
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes4;
    }
}
