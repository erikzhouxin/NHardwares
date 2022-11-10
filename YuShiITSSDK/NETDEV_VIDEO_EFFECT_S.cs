using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_EFFECT_S
    {
        public Int32 dwContrast;                   /* Contrast */
        public Int32 dwBrightness;                 /* Brightness */
        public Int32 dwSaturation;                 /* Saturation */
        public Int32 dwHue;                        /* Hue */
        public Int32 dwGamma;                      /* Gamma */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;                    /* Reserved */
    };

}
