using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVUpgradeDevice
     * @brief Basic device information Structure definition
     * @attention  None
     */
    public struct NETDEV_UPGRADE_DEVICE_S
    {
        public Int32 dwUpgradeType;
        public Int32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_CHANNEL_MAX)]
        public Int32[] adwChannelID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_PATH_LEN)]
        public byte[] szPath;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] byRes;
    }

}
