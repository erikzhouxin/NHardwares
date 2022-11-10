using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_STATUS_LIST_S
    {
        public UInt32 udwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_CHANNEL_MAX)]
        public NETDEV_RECORD_STATUS[] astRecordStatus;
    }

}
