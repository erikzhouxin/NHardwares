using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*串口配置信息*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_UARTPARAM
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPortName;
        public ushort wUserId; /*用户编号，当连接设备为键盘时，绑定一个用户，用于权限管理*/
        public byte byPortType;    /*串口类型，三种0-RS232/1-RS485/2-RS422*/
        public byte byFuncType; /*串口连接的设备的类型0-空闲，1-键盘，2-用作透明通道(485串口不可配置成透明通道),3-模拟矩阵*/
        public byte byProtocolType;  /*串口支持的协议类型, 当连接键盘设备时需要该信息,获取键盘支持协议的编号及描述符*/
        public byte byBaudRate;
        public byte byDataBits;
        public byte byStopBits;   /*停止位*/
        public byte byParity;      /*校验*/
        public byte byFlowCtrl;   /*流控，软件流控，无流控*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 22, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     /*预留*/
    }
}
