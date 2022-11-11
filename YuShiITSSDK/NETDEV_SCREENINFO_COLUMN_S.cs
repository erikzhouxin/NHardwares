﻿using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SCREENINFO_COLUMN_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_SCREEN_INFO_COLUMN)]
        public Int16[] columnInfo;
    }

}
