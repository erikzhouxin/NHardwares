using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagNETDEVFileInfo
    * @brief 
    * @attention 
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILE_INFO_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public byte[] szName;   /* [1, 16]*/
        public UInt32 udwSize;
        public UInt32 dwFileType;              /* See #NETDEV_FILE_TYPE_E */
        public UInt32 udwLastChange;           /*UTC:s */
        public IntPtr pcData;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_512)]
        public string szUrl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    }

}
