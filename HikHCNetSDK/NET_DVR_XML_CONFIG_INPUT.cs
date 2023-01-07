using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //XML透传接口
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_XML_CONFIG_INPUT
    {
        public uint dwSize;//结构体大小 
        public IntPtr lpRequestUrl;//请求信令，字符串格式 
        public uint dwRequestUrlLen;
        public IntPtr lpInBuffer;//输入参数缓冲区，XML格式 
        public uint dwInBufferSize;
        public uint dwRecvTimeOut;//接收超时时间，单位：ms，填0则使用默认超时5s 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
