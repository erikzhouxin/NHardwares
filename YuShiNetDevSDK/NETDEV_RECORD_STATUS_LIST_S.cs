using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_STATUS_LIST_S
    {
        public UInt32 udwSize;                                 /* 录像状态数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_CHANNEL_MAX)]
        public NETDEV_RECORD_STATUS[] astRecordStatus;      /* 录像状态信息 */
    }

}
