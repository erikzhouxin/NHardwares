using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVACSPermStatus
    * @brief 
    * @attention None
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ACS_PERM_STATUS_S
    {
        public UInt32 udwPersonID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szPersonName;
        public UInt32 udwDepartmentID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szDepartmentName;
        public UInt32 udwDoorID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szDoorName;
        public UInt32 udwDeviceID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_256)]
        public byte[] szDeviceName;
        public UInt32 udwStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }
}
