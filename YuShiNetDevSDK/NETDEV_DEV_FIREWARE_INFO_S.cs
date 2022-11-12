using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_FIREWARE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szDevModel;       /* 设备型号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szFireVersion;    /* 软件版本号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szSerialNum;      /* 设备序列号 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string byRes;
    }

}
