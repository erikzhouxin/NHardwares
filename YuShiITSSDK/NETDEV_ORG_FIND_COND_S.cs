using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ORG_FIND_COND_S
    {
        public UInt32 udwOrgType;              /* See NETDEV_ORG_TYPE_E */
        public UInt32 udwRootOrgID;
        public UInt32 udwFindType;             /* See NETDEV_ORG_FIND_MODE_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;
    };

}
