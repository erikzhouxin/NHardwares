using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WINLIST
    {
        public uint dwSize;
        public ushort wScreenSeq;   //设备序号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwWinNum;   //设备返回的窗口数量
        public IntPtr pBuffer;  //窗口信息缓冲区，最大为224*sizeof(NET_DVR_WINCFG)
        public uint dwBufLen;   //所分配指针长度
    }
}
