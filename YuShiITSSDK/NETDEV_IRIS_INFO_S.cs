using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_IRIS_INFO_S
    {
        public Int32 udwIris;       /* 光圈,在光圈优先、手动曝光模式下可选。光圈支持的取值:160， 200， 240， 280， 340， 400， 480， 560， 680， 800， 960， 1100，1400,  1600,  2200*/
        public Int32 udwMinIris;    /* 最小光圈值 自定义曝光模式下可用，枚举同 Iris能力集所描述，不得大于光圈最大值。图像能力集支持该功能，此字段必选。*/
        public Int32 udwMaxIris;    /* 最大光圈值 自定义曝光模式下可用，枚举同 Iris能力集所描述，不得小于光圈最小值。图像能力集支持该功能，此字段必选。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
