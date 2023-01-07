using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INPUT_SIGNAL_LIST
    {
        public uint dwSize;
        public uint dwInputSignalNums;  //设备输入信号源数量
        public IntPtr pBuffer;          //指向dwInputSignalNums个NET_DVR_INPUTSTREAMCFG结构大小的缓冲区
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwBufLen;           //所分配缓冲区长度，输入参数（大于等于dwInputSignalNums个NET_DVR_INPUTSTREAMCFG结构大小）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
