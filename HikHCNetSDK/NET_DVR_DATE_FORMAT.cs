using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*日期显示格式*/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_DATE_FORMAT
    {
        public byte byItem1;/*Month,0.mm;1.mmm;2.mmmm*/
        public byte byItem2;/*Day,0.dd;*/
        public byte byItem3;/*Year,0.yy;1.yyyy*/
        public byte byDateForm;/*0~5，3个item的排列组合*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string chSeprator;/*分隔符*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string chDisplaySeprator;/*显示分隔符*/
        public byte byDisplayForm;/*0~5，3个item的排列组合*///lili mode by lili
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 27, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
