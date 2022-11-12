using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_GAIN_INFO_S
    {
        public Int32 udwGain;         /* 增益值（单位:db）手动曝光模式下可用。范围[1,100]*/
        public Int32 udwMinGain;      /* 增益最小值 ,自定义曝光模式下可用，不得大于增益最大值。最小值为1*/
        public Int32 udwMaxGain;      /* 增益最大值 , 自定义曝光模式下可用，不得小于增益最小值。最大值为100*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
