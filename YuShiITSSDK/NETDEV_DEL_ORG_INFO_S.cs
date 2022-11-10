using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEL_ORG_INFO_S
    {
        public Int32 dwOrgNum;
        public IntPtr pdwOrgIDs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        public byte[] byRes;    /* Reserved field*/
    }

}
