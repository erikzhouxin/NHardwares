using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*****************************DS-6001D/F(begin)***************************/
    //DS-6001D Decoder
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DECODERINFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byEncoderIP;//解码设备连接的服务器IP
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byEncoderUser;//解码设备连接的服务器的用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byEncoderPasswd;//解码设备连接的服务器的密码
        public byte bySendMode;//解码设备连接服务器的连接模式
        public byte byEncoderChannel;//解码设备连接的服务器的通道号
        public ushort wEncoderPort;//解码设备连接的服务器的端口号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] reservedData;//保留
    }
}
