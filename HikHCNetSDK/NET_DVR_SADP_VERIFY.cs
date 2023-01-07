using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SADP_VERIFY
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PASSWD_LEN)]
        public string chPassword;
        public NET_DVR_IPADDR struOldIP;
        public ushort wOldPort;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 62, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
