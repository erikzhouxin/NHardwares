using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVWideDynamicInfo
     * @brief  宽动态信息  结构体定义    WideDynamicInfo
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_WIDE_DYNAMIC_INFO_S
    {
        public Int32 udwWideDynamicMode;              /* 宽动态模式 WideDynamicMode 枚举详见#NETDEV_WIDE_DYNAMIC_MODE_E*/
        public Int32 udwWideDynamicLevel;             /* 宽动态级别配置，宽动态开启且在曝光模式为自动模式、自定义、快门优先、室内50HZ、室内60HZ、低拖影下可用。范围[1, 9]。*/
        public Int32 udwOpenSensitivity;              /* 宽动态开启的灵敏度。宽动态模式为自动下可用。范围[1, 9]。*/
        public Int32 udwCloseSensitivity;             /* 宽动态关闭的灵敏度。宽动态模式为自动下可用。范围[1, 9]。*/
        public Int32 udwAntiFlicker;                  /* 宽动态条纹抑制：0：关闭 1：开启该功能开启后，可消除图像中的条纹效应。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                      /* 保留字段  Reserved */
    }

}
