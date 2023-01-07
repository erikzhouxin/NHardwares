using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CUSTOM_PROTOCAL
    {
        public uint dwSize;              //结构体大小
        public uint dwEnabled;           //是否启用该协议0 不启用 1 启用
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.DESC_LEN)]
        public string sProtocalName;   //自定义协议名称, 16位
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;          //保留,用于协议名称扩展
        public uint dwEnableSubStream;   //子码流是否启用0 不启用 1 启用	
        public byte byMainProType;        //主码流协议类型 1 RTSP
        public byte byMainTransType;        //主码流传输类型 0：Auto 1：udp 2：rtp over rtsp
        public ushort wMainPort;           //主码流端口	
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_PRO_PATH)]
        public string sMainPath;  //主码流路径	
        public byte bySubProType;         //子码流协议类型 1 RTSP
        public byte bySubTransType;     //子码流传输类型 0：Auto 1：udp 2：rtp over rtsp
        public ushort wSubPort;   //子码流端口
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_PRO_PATH)]
        public string sSubPath;   //子码流路径 	
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;          //保留
    }
}
