using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVStructImageInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STRUCT_IMAGE_INFO_S
    {
        public UInt32 udwIndex;
        public UInt32 udwType;
        public UInt32 udwFormat;
        public UInt32 udwWidth;
        public UInt32 udwHeight;
        public UInt32 udwCaptureTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public byte[] szUrl;
        public UInt32 udwSize;
        public IntPtr pszData;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
