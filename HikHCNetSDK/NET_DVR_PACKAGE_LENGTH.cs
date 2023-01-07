using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*报文信息长度*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PACKAGE_LENGTH
    {
        public byte byLengthMode;/*长度类型，0,variable;1,fix;2,get from package(设置卡号长度使用)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwFixLength;/*mode为1的时候使用*/
        public uint dwMaxLength;
        public uint dwMinLength;
        public byte byEndMode;/*终结符0,ASCII;1,HEX*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_FRAMETYPECODE struEndCode;/*终结符*/
        public uint dwLengthPos;/*lengthMode为2的时候使用，卡号长度在报文中的位置*/
        public uint dwLengthLen;/*lengthMode为2的时候使用，卡号长度的长度*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
