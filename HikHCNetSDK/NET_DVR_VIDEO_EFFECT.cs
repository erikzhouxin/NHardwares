using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEO_EFFECT
    {
        public uint dwBrightValue;      //亮度[0,255]
        public uint dwContrastValue;    //对比度[0,255]
        public uint dwSaturationValue;  //饱和度[0,255]
        public uint dwHueValue;         //色调[0,255]
        public uint dwSharpness;          //锐度[0,255]
        public uint dwDenoising;          //去噪[0,255]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
