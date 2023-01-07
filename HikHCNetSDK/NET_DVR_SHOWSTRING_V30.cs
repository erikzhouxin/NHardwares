using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //叠加字符(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SHOWSTRING_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_STRINGNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SHOWSTRINGINFO[] struStringInfo;/* 要显示的字符内容 */
    }
}
