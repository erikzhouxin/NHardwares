using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DDNSPARA_EX
    {
        public byte byHostIndex;/* 0-Hikvision DNS 1－Dyndns 2－PeanutHull(花生壳)*/
        public byte byEnableDDNS;/*是否应用DDNS 0-否，1-是*/
        public ushort wDDNSPort;/* DDNS端口号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUsername;/* DDNS用户名*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* DDNS密码 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] sDomainName;/* 设备配备的域名地址 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] sServerName;/* DDNS 对应的服务器地址，可以是IP地址或域名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
