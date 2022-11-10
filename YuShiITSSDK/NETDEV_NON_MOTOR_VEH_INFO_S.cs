using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVNonMotorVehInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_NON_MOTOR_VEH_INFO_S
    {
        public UInt32 udwID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_64)]
        public byte[] szPosition;
        public UInt32 udwSmallPicAttachIndex;
        public UInt32 udwLargePicAttachIndex;
        public NETDEV_NO_MOTOR_VEH_ATTR_S stNoMotorVehAttr;
        public UInt32 udwPersonOnNoVehiNum;
        public IntPtr pstPersonAttr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
