using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVStructDataInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_DATA_INFO_S
    {
        public NETDEV_OBJECT_INFO_S stObjectInfo;
        public UInt32 udwImageNum;
        public IntPtr pstImageInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
