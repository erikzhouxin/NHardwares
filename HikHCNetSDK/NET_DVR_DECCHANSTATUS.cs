using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*当前设备解码连接状态*/
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_DECCHANSTATUS
    {
        public uint dwWorkType;/*工作方式：1：轮巡、2：动态连接解码、3：文件回放下载 4：按时间回放下载*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDVRIP;/*连接的设备ip*/
        public ushort wDVRPort;/*连接端口号*/
        public byte byChannel;/* 通道号 */
        public byte byLinkMode;/* 连接模式 */
        public uint dwLinkType;/*连接类型 0－主码流 1－子码流*/

        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct objectInfo
        {
            [StructLayoutAttribute(LayoutKind.Sequential)]
            public struct userInfo
            {
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                public byte[] sUserName;/*请求视频用户名*/
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
                public byte[] sPassword;/* 密码 */
                [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 52)]
                public string cReserve;
            }

            [StructLayoutAttribute(LayoutKind.Sequential)]
            public struct fileInfo
            {
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
                public byte[] fileName;
            }
            [StructLayoutAttribute(LayoutKind.Sequential)]
            public struct timeInfo
            {
                public uint dwChannel;
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                public byte[] sUserName;/*请求视频用户名*/
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
                public byte[] sPassword;/* 密码 */
                public NET_DVR_TIME struStartTime;/* 按时间回放的开始时间 */
                public NET_DVR_TIME struStopTime;/* 按时间回放的结束时间 */
            }
        }
    }
}
