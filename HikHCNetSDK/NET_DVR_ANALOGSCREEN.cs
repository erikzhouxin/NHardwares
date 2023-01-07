using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ANALOGSCREEN
    {
        public byte byDevSerPortNum;   /*连接设备的串口号*/
        public byte byScreenSerPort;  /*连接大屏的串口号*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 130, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_MATRIX_CFG struMatrixCfg;
    }
}
