using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VCA_CHAN_WORKSTATUS
    {
        public byte byJointed;              // 0-没有关联  1-已经关联
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_IPADDR struIP;                   // 关联的取流设备IP地址
        public ushort wPort;                    // 关联的取流设备端口号
        public ushort wChannel;             // 关联的取流设备通道号
        public byte byVcaChanStatus;        // 0 - 未启用 1 - 启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;               // 保留字节
    }
}
