using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2009-4-11 added by likui 多路解码器new
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_PASSIVEMODE
    {
        public ushort wTransProtol;//传输协议，0-TCP, 1-UDP, 2-MCAST
        public ushort wPassivePort;//UDP端口, TCP时默认
        public NET_DVR_IPADDR struMcastIP;
        public byte byStreamType;/* 数据播放模式:REAL_TIME_STREAM(1)实时流,RECORD_STREAM(2)文件流 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
