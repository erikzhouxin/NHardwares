using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIXLIST
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwMatrixNum;//设备返回的矩阵数量
        public IntPtr pBuffer;//矩阵信息缓冲区
        public uint dwBufLen;//所分配指针长度，输入参数
    }
}
