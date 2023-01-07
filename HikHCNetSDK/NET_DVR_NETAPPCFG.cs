using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //网络参数配置
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_NETAPPCFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDNSIp; /* DNS服务器地址 */
        public NET_DVR_NTPPARA struNtpClientParam;/* NTP参数 */
        public NET_DVR_DDNSPARA struDDNSClientParam;/* DDNS参数 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 464, ArraySubType = UnmanagedType.I1)]
        public byte[] res;/* 保留 */
    }
}
