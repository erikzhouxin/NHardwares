using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_PROTOCOL
    {
        public uint dwSize;
        public NET_DVR_ATM_PROTO_LIST struNetListenList;     // 网络监听协议描述
        public NET_DVR_ATM_PROTO_LIST struSerialListenList; //串口监听协议描述
        public NET_DVR_ATM_PROTO_LIST struNetProtoList;     //网络协议描述
        public NET_DVR_ATM_PROTO_LIST struSerialProtoList;   //串口协议描述
        public NET_DVR_ATM_PROTO_TYPE struCustomProto;      //自定义协议            
    }
}
