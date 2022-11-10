using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVNonMotorVehicleAttr
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NO_MOTOR_VEH_ATTR_S
    {
        public UInt32 udwSpeedType;
        public UInt32 udwImageDirection;
        public UInt32 udwNonVehicleType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
