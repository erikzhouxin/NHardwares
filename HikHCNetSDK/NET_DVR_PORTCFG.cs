using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PORTCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TRANSPARENTNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PORTINFO[] struTransPortInfo;/* 数组0表示232 数组1表示485 */
    }
}
