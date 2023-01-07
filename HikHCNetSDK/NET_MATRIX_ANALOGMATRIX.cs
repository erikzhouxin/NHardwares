using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_ANALOGMATRIX
    {
        public byte bySerPortNum;   /*连接的串口号*/
        public byte byMatrixSerPortType;/* 矩阵接入网关的串口与模拟矩阵的键盘口(键盘协议)连接还是与矩阵通信口（矩阵协议）连接 ，0 --- 矩阵协议通讯口 1 --- 键盘通讯口*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_SINGLE_RS232 struRS232;  //232串口参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
