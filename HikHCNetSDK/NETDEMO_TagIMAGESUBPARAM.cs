using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图像增强、去噪级别及稳定性使能配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct TagIMAGESUBPARAM
    {
        public NET_DVR_SCHEDTIME struImageStatusTime;//图像状态时间段
        public byte byImageEnhancementLevel;//图像增强的级别，0-7，0表示关闭
        public byte byImageDenoiseLevel;//图像去噪的级别，0-7，0表示关闭
        public byte byImageStableEnable;//图像稳定性使能，0表示关闭，1表示打开
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
