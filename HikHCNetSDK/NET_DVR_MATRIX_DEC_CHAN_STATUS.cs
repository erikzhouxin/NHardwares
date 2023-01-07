using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_DEC_CHAN_STATUS
    {
        public uint dwSize;
        public uint dwIsLinked;/* 解码通道状态 0－休眠 1－正在连接 2－已连接 3-正在解码 */
        public uint dwStreamCpRate;/* Stream copy rate, X kbits/second */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string cRes;/* 保留 */
    }
}
