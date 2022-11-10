using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVLed
     * @brief    出入口设备Led屏显示配置
     * @attention 时间实时显示可下发内容“#T”,由设备自行控制显示
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_LED_LINE_CFG_S
    {
        public Int32 dwEnCode;                                     /**< 下发数据编码格式 0：UTF-8编码格式，1：GBK编码格式*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szContext;                                    /**< 下发内容*/
    }

}
