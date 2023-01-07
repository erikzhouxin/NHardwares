using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************文件回放-远程回放设置*******************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY_V41
    {
        public uint dwSize;
        public NET_DVR_IPADDR struIP;       /* DVR IP地址 */
        public ushort wDVRPort;         /* 端口号 */
        public byte byChannel;          /* 通道号 */
        public byte byReserve;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;        /* 用户名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;        /* 密码 */
        public uint dwPlayMode;     /* 0－按文件 1－按时间*/
        public NET_DVR_TIME StartTime;
        public NET_DVR_TIME StopTime;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string sFileName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        /*保留*/
    }
}
