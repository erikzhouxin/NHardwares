using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* 控制网络文件回放 */
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_PLAYREMOTEFILE
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDecoderIP;/* DVR IP地址 */
        public ushort wDecoderPort;/* 端口号 */
        public ushort wLoadMode;/* 回放下载模式 1－按名字 2－按时间 */

        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct mode_size
        {
            [FieldOffsetAttribute(0)]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            /*[FieldOffsetAttribute(0)]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.I1)]             
            public byte[] byFile;/* 回放的文件名 */
            /*[FieldOffsetAttribute(0)]
            public bytime bytime;
            * */
        }
    }
}
