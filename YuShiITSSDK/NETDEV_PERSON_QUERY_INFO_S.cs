using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagNETDEVPersonQueryInfo
     * @brief 
     * @attention None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PERSON_QUERY_INFO_S
    {
        public UInt32 udwNum;
        public IntPtr pstQueryInfos;
        public UInt32 udwLimit;
        public UInt32 udwOffset;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;
    }

}
