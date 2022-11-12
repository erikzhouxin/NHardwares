using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_SETTING_S
    {
        public Int32 dwContrast;                   /* Contrast */
        public Int32 dwBrightness;                 /* Brightness */
        public Int32 dwSaturation;                 /* Saturation */
        public Int32 dwSharpness;                  /* Sharpness */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                            /* Reserved */
    }

    //    [StructLayout(LayoutKind.Sequential)]
    //    public struct NETDEV_IMAGE_SETTING_S
    //{
    //        public Int32 dwContrast;                   /* Contrast */
    //        public Int32 dwBrightness;                 /* Brightness */
    //        public Int32 dwSaturation;                 /* Saturation */
    //        public Int32 dwSharpness;                  /* Sharpness */
    //        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
    //        public byte[]  byRes;                     /* Reserved */
    //};

}
