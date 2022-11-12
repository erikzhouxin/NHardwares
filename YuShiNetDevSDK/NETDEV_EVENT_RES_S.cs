using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EVENT_RES_S
    {
        public Int32 dwResType;                          /* 资源类型，参见枚举#NETDEV_EVENT_RES_TYPE_E */
        public Int32 dwResID;                            /* 资源ID */
        public Int32 dwFirstSubResID;                    /* 第一子资源ID */
        public Int32 dwSecondSubResID;                   /* 第二子资源ID 不同资源类型对应意义不同。如：电视墙分屏资源的资源ID是电视墙ID，第一子资源ID是窗口ID，第二子资源ID就是分屏ID*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRes;
    };

}
