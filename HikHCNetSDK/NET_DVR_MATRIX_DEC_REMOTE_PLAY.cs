using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2007-12-24 Merry Christmas Eve...
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDVRIP;/* DVR IP地址 */
        public ushort wDVRPort;/* 端口号 */
        public byte byChannel;/* 通道号 */
        public byte byReserve;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/* 用户名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* 密码 */
        public uint dwPlayMode;/* 0－按文件 1－按时间*/
        public NET_DVR_TIME StartTime;
        public NET_DVR_TIME StopTime;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string sFileName;
    }
}
