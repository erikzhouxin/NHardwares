using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OBJECT_LIST_S
    {
        public UInt32 udwObjectType;                  /* 目标类型 参见枚举 NETDEV_OBJECT_TYPE_E */
        public UInt32 udwObjectID;                    /* 目标ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] byRes;                          /* 保留字段 */
    };

}
