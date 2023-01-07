using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_DECINFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDVRIP;/* DVR IP地址 */
        public ushort wDVRPort;/* 端口号 */
        public byte byChannel;/* 通道号 */
        public byte byTransProtocol;/* 传输协议类型 0-TCP, 1-UDP */
        public byte byTransMode;/* 传输码流模式 0－主码流 1－子码流*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/* 监控主机登陆帐号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* 监控主机密码 */
    }
}
