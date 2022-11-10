using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVVehicleMemberAttr
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_MEMBER_ATTR_S
    {
        public UInt32 udwColor;
        public NETDEV_FILE_INFO_S stVehicleImage;
    }

}
