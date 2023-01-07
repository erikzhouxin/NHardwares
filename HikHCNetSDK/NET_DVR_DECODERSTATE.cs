using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECODERSTATE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byEncoderIP;//解码设备连接的服务器IP
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byEncoderUser;//解码设备连接的服务器的用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byEncoderPasswd;//解码设备连接的服务器的密码
        public byte byEncoderChannel;//解码设备连接的服务器的通道号
        public byte bySendMode;//解码设备连接的服务器的连接模式
        public ushort wEncoderPort;//解码设备连接的服务器的端口号
        public uint dwConnectState;//解码设备连接服务器的状态
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] reservedData;//保留
    }
}
