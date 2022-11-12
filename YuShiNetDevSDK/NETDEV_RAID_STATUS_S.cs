using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RAID_STATUS_S
    {
        public Int32 bEnabled;                  /* 阵列状态使能 0:不使能 1:使能 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

}
