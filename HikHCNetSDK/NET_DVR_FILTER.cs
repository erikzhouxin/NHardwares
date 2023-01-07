using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //SDK_V31 ATM
    /*过滤设置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FILTER
    {
        public byte byEnable;/*0,不启用;1,启用*/
        public byte byMode;/*0,ASCII;1,HEX*/
        public byte byFrameBeginPos;// 报文标志位的起始位置     
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byFilterText;/*过滤字符串*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
