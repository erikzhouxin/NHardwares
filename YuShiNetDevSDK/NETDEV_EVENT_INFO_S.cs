using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EVENT_INFO_S
    {
        public Int32 dwSize;                                     /* 资源数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public NETDEV_EVENT_RES_S[] astEventRes;     /* 事件资源信息 */
        public Int32 dwEventActionType;                          /* 事件类型，参见枚举#NETDEV_EVENT_ACTION_TYPE_E */
        public IntPtr pstEventRes;                                /* 超过NETDEV_MAX_EVENT_RES_SIZE的事件资源信息 需要动态申请*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] byRes;
    };

}
