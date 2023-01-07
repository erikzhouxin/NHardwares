using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //叠加字符扩展(8条字符)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SHOWSTRING_EX
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_STRINGNUM_EX, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SHOWSTRINGINFO[] struStringInfo;/* 要显示的字符内容 */
    }
}
