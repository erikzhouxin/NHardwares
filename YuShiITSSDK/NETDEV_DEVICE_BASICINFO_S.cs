using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 设备基本信息 结构体定义 Basic device information Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEVICE_BASICINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szDevModel;                     /* 设备型号  Device model */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szSerialNum;                    /* 硬件序列号  Hardware serial number */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szFirmwareVersion;              /* 软件版本号  Software version */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szMacAddress;                   /* IPv4的Mac地址  MAC address of IPv4 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public string szDeviceName;                   /* 设备名称  Device name */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
        public byte[] byRes;                                    /* Reserved */
    }

}
