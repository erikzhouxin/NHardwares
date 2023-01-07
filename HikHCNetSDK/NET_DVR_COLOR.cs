using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COLOR
    {
        public byte byBrightness;/*亮度,0-255*/
        public byte byContrast;/*对比度,0-255*/
        public byte bySaturation;/*饱和度,0-255*/
        public byte byHue;/*色调,0-255*/
    }
}
