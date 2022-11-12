using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DAY_NIGHT_INFO_S
    {
        public Int32 udwDayNightMode;                 /* 昼夜模式类型 DayNightMode 枚举参见#NETDEV_DAY_NIGHT_MODE_E*/
        public Int32 udwDayNightSensitivity;          /* 昼夜模式灵敏度 DayNightSensitivity 在昼夜模式为自动模式下可用，范围[0, 9]。若图像能力支持该功能，此字段必选。*/
        public Int32 udwDayNightTime;                 /* 昼夜模式切换时间，在昼夜模式为自动模式下可用。范围[3, 120]。单位秒。若图像能力支持该功能，此字段必选。*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                    /* Reserved */
    }

}
