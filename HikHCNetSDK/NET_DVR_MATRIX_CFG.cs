using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_CFG
    {
        public byte byValid;                //判断是否是模拟矩阵（是否有效）
        public byte byCommandProtocol;  //模拟矩阵的指令（4种）
        public byte byScreenType;           //保留	
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byScreenToMatrix; //模拟矩阵的输出与屏幕的对应关系
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
