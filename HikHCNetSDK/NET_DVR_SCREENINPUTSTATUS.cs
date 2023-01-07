using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREENINPUTSTATUS
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwNums;     //设备返回的输入源状态的数量
        public IntPtr pBuffer;  //缓冲区
        public uint dwBufLen;   //所分配指针长度，输入参数
    }
}
