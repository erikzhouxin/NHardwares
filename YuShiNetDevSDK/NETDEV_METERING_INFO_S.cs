using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_METERING_INFO_S
    {
        public Int32 udwMeteringMode;                 /* 测光控制模式,此字段在非手动曝光模式下可用。枚举详见#NETDEV_DAY_NIGHT_MODE_E*/
        public Int32 udwRefBrightness;                /* 人脸亮度。人脸测光模式下可用。范围：[0, 100]。*/
        public Int32 udwHoldTime;                     /* 最短持续时间。人脸测光模式下可用。单位：分钟。范围：[0, 60]。*/
        public NETDEV_METERING_AREA_S stMeteringArea;  /* 测光区域 ,在测光模式为区域测光及点测光时，此字段可用*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
