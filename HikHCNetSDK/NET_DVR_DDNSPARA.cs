using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ddns
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DDNSPARA
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUsername;/* DDNS账号用户名/密码 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] sDomainName; /* 域名 */
        public byte byEnableDDNS;/*是否应用 0-否，1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
