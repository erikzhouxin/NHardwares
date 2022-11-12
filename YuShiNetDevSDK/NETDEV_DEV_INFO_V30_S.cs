using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_INFO_V30_S
    {
        public NETDEV_DEV_BASIC_INFO_S stDevBasicInfo;             /* 设备基本信息 */
        public NETDEV_DEV_FIREWARE_INFO_S stDevFirewareInfo;       /* 设备固件信息 */
    }

}
