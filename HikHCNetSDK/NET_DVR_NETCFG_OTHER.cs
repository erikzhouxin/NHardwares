using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /************************************多路解码器(begin)***************************************/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_NETCFG_OTHER
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sFirstDNSIP;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sSecondDNSIP;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sRes;
    }
}
