using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //CMOS模式下前端镜头配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CMOSMODECFG
    {
        public byte byCaptureMod;   //抓拍模式：0-抓拍模式1；1-抓拍模式2
        public byte byBrightnessGate;//亮度阈值
        public byte byCaptureGain1;   //抓拍增益1,0-100
        public byte byCaptureGain2;   //抓拍增益2,0-100
        public uint dwCaptureShutterSpeed1;//抓拍快门速度1
        public uint dwCaptureShutterSpeed2;//抓拍快门速度2
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
