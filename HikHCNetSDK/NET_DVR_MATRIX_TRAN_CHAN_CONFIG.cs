using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_TRAN_CHAN_CONFIG
    {
        public uint dwSize;
        public byte by232IsDualChan;/* 设置哪路232透明通道是全双工的 取值1到MAX_SERIAL_NUM */
        public byte by485IsDualChan;/* 设置哪路485透明通道是全双工的 取值1到MAX_SERIAL_NUM */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] res;/* 保留 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SERIAL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MATRIX_TRAN_CHAN_INFO[] struTranInfo;/*同时支持建立MAX_SERIAL_NUM个透明通道*/
    }
}
