using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_ABILITY
    {
        public uint dwSize;
        public byte byDecNums;
        public byte byStartChan;
        public byte byVGANums;
        public byte byBNCNums;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8 * 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byVGAWindowMode;/*VGA支持的窗口模式*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byBNCWindowMode;/*BNC支持的窗口模式*/
        public byte byDspNums;
        public byte byHDMINums;//HDMI显示通道个数（从25开始）
        public byte byDVINums;//DVI显示通道个数（从29开始）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 13, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RESOLUTIONNUM, ArraySubType = UnmanagedType.I1)]
        public byte[] bySupportResolution;//按照上面的枚举定义,一个字节代表一个分辨率是//否支持，1：支持，0：不支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4 * 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byHDMIWindowMode;//HDMI支持的窗口模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4 * 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byDVIWindowMode;//DVI支持的窗口模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
