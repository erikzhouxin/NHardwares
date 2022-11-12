using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEL_ORG_INFO_S
    {
        public Int32 dwOrgNum;     /* 组织数量 */
        public IntPtr pdwOrgIDs;   /* 需要删除的组织ID，根据dwOrgNum 动态申请(INT32*) */
        public Int32 dwOrgType;    /* 组织类型 见 NETDEV_ORG_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;    /* 保留字段  Reserved field*/
    }

}
