using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief  告警开关量输入信息 结构体定义  Alarm boolean inputs info Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INPUT_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szName;                                                  /* 输入开关量名称   Name of input alarm */
    }

}
