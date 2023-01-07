using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ENCODE_JOINT_PARAM
    {
        public uint dwSize;         // 结构体大小
        public byte byJointed;      //  0 没有关联 1 已经关联
        public byte byDevType;      // 被关联的设备类型  1 代表智能设备
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       // 保留字节
        public NET_DVR_IPADDR struIP;           // 关联的被取流设备IP地址
        public ushort wPort;            // 关联的被取流设备端口号
        public ushort wChannel;     // 关联的被取流设备通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           // 保留字节
    }
}
