using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //协议列表V41
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPC_PROTO_LIST_V41
    {
        public uint dwSize;
        public uint dwProtoNum;  //有效的ipc协议数目
        public IntPtr pBuffer;    //协议列表缓冲区, dwProtoNum 个NET_DVR_PROTO_TYPE结构  
        public uint dwBufferLen; //缓冲区长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
