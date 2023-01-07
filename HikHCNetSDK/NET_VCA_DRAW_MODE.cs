using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析规则DSP信息叠加结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_DRAW_MODE
    {
        public uint dwSize;
        public byte byDspAddTarget;//编码是否叠加目标
        public byte byDspAddRule;//编码是否叠加规则
        public byte byDspPicAddTarget;//抓图是否叠加目标
        public byte byDspPicAddRule;//抓图是否叠加规则
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
