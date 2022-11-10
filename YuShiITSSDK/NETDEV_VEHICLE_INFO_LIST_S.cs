using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVVehicleInfoList
     * @brief Device information Structure definition
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_INFO_LIST_S
    {
        public UInt32 udwVehicleNum;
        public IntPtr pstMemberInfoList;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;              /* Reserved */
    }

}
