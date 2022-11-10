using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 设备图像设置 结构体定义    Device image settings Structure definition
     * @attention 参数取值范围：0-255     parameter range: 0-255
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_SETTING_S
    {
        public Int32 dwContrast;                   /*对比度 Contrast */
        public Int32 dwBrightness;                 /*亮度 Brightness */
        public Int32 dwSaturation;                 /*饱和度 Saturation */
        public Int32 dwSharpness;                  /* 亮度Sharpness */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byRes;                            /*保留字段 Reserved */
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
