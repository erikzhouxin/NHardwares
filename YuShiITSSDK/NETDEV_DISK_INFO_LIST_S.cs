﻿using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DISK_INFO_LIST_S
    {
        public Int32 dwSize;                                  /*Disk number */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_DISK_MAX_NUM)]
        public NETDEV_DISK_INFO_S[] astDisksInfo;             /* Disk info*/
    };

}
