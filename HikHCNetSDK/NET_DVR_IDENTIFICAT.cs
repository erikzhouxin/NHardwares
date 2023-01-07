using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*起始标识设置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IDENTIFICAT
    {
        public byte byStartMode;/*0,ASCII;1,HEX*/
        public byte byEndMode;/*0,ASCII;1,HEX*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_FRAMETYPECODE struStartCode;/*起始字符*/
        public NET_DVR_FRAMETYPECODE struEndCode;/*结束字符*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
