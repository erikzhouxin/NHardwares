using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DDNSPARA_V30
    {
        public byte byEnableDDNS;
        public byte byHostIndex;/* 0-Hikvision DNS(保留) 1－Dyndns 2－PeanutHull(花生壳)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DDNS_NUMS, ArraySubType = UnmanagedType.Struct)]
        public struDDNS[] struDDNS;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
