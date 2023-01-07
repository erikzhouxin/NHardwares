using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*报文信息位置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PACKAGE_LOCATION
    {
        public byte byOffsetMode;/*0,token;1,fix*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwOffsetPos;/*mode为1的时候使用*/
        public NET_DVR_FRAMETYPECODE struTokenCode;/*标志位*/
        public byte byMultiplierValue;/*标志位多少次出现*/
        public byte byEternOffset;/*附加的偏移量*/
        public byte byCodeMode;/*0,ASCII;1,HEX*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
