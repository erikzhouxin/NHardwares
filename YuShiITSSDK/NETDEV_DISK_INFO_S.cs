using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISK_INFO_S
    {
        public Int32 dwDiskCabinetIndex;
        public Int32 dwSlotIndex;                                                      /* Slot Index */
        public Int32 dwTotalCapacity;                                                  /* Total Capacity*/
        public Int32 dwUsedCapacity;                                                   /* Used Capacity */
        public NETDEV_DISK_WORK_STATUS_E enStatus;                                                         /* Status */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public String szManufacturer;                                                 /* Manufacturer */
    };

}
