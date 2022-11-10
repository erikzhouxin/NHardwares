using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 遮挡检测分析信息 Tampering detection analysis info
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TAMPER_ALARM_INFO_S
    {
        public Int32 dwSensitivity;                               /* 灵敏度  Sensitivity */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                                      /* 保留字段  Reserved */
    }

}
