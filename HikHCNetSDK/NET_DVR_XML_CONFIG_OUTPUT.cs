using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_XML_CONFIG_OUTPUT
    {
        public uint dwSize;//结构体大小 
        public IntPtr lpOutBuffer;//输出参数缓冲区，XML格式 
        public uint dwOutBufferSize;
        public uint dwReturnedXMLSize;//实际输出的XML内容大小 
        public IntPtr lpStatusBuffer;//返回的状态参数(XML格式：ResponseStatus)，获取命令成功时不会赋值，如果不需要，可以置NULL 
        public uint dwStatusSize;//状态缓冲区大小(内存大小) 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
