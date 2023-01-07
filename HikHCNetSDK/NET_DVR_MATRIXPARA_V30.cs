using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //MATRIX输出参数结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIXPARA_V30
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ANALOG_CHANNUM, ArraySubType = UnmanagedType.U2)]
        public ushort[] wOrder;/* 预览顺序, 0xff表示相应的窗口不预览 */
        public ushort wSwitchTime;// 预览切换时间 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 14, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }

}
