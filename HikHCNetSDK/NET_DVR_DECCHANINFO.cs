using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*连接的通道配置*/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_DECCHANINFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDVRIP;/* DVR IP地址 */
        public ushort wDVRPort;/* 端口号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/* 用户名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* 密码 */
        public byte byChannel;/* 通道号 */
        public byte byLinkMode;/* 连接模式 */
        public byte byLinkType;/* 连接类型 0－主码流 1－子码流 */
    }
}
