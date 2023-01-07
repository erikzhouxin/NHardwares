using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************获取串口信息*******************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SERIAL_CONTROL
    {
        public uint dwSize;
        public byte bySerialNum;        // 串口个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] bySerial;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
