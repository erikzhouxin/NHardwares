using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*帧格式*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FRAMETYPECODE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] code;/* 代码 */
    }
}
