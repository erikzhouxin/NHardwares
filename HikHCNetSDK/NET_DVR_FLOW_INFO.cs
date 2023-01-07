using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FLOW_INFO
    {
        public uint dwSize;             //结构大小
        public uint dwSendFlowSize;     //发送流量大小,单位kbps
        public uint dwRecvFlowSize;     //接收流量大小,单位kbps
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;          //保留 
    }
}
