using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVImagingExposure
     * @brief 图像曝光参数 结构体定义    Device image Exposure Structure definition
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IMAGE_EXPOSURE_S
    {
        public Int32 udwMode;                                  /* 曝光模式  Exposure Mode 枚举详见#NETDEV_EXPOSURE_MODE_E*/
        public Int32 dwCompensationLevel;                      /* 曝光补偿级别,曝光模式为非手动曝光模式时可用。范围[-100,100].图像能力集支持该功能，此字段必选 */
        public Int32 udwHLCSensitivity;                        /* 强光抑制灵敏度，当前场景为道路强光抑制及园区强光抑制时可用,范围[1,9]。 图像能力集支持该功能，此字段必选 */
        public NETDEV_IRIS_INFO_S stIrisInfo;                  /* 光圈信息。图像能力集支持该功能，此字段必选。*/
        public NETDEV_SHUTTER_INFO_S stShutterInfo;            /* 快门信息。图像能力集支持该功能，此字段必选。*/
        public NETDEV_GAIN_INFO_S stGainInfo;                  /* 增益信息。*/
        public NETDEV_WIDE_DYNAMIC_INFO_S stWideDynamicInfo;   /* 宽动态信息。图像能力集支持该功能，此字段必选。*/
        public NETDEV_METERING_INFO_S stMeteringInfo;          /* 测光信息。当前场景不是道路强光抑制及园区强光抑制时可用。图像能力集支持该功能，此字段必选。*/
        public NETDEV_DAY_NIGHT_INFO_S stDayNightInfo;         /* 昼夜模式信息。图像能力集支持该功能，此字段必选。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szReserve;                               /* 保留字段  Reserved */
    }

}
