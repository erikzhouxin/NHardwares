using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //协议列表
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPC_PROTO_LIST
    {
        public uint dwSize;
        public uint dwProtoNum;           /*有效的ipc协议数目*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.IPC_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PROTO_TYPE[] struProto;   /*有效的ipc协议*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
