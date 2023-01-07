﻿using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_TRUNKLIST
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwTrunkNum;//设备返回的干线数量
        public IntPtr pBuffer;//干线信息缓冲区
        public uint dwBufLen;//所分配指针长度，输入参数
    }
}
