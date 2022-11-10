using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVObjectInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_INFO_S
    {
        public UInt32 udwFaceNum;
        public IntPtr pstFaceInfo;
        public UInt32 udwPersonNum;
        public IntPtr pstPersonInfo;
        public UInt32 udwNonMotorVehNum;
        public IntPtr pstNonMotorVehInfo;
        public UInt32 udwVehicleNum;
        public IntPtr pstVehInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
