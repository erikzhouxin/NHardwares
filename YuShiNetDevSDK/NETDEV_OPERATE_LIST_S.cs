using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OPERATE_LIST_S
    {
        public Int32 dwSize;                  /*Size */
        public IntPtr pstOperateInfo;         /*Need to be dynamically allocated memory (see # NETDEV_OPERATE_INFO_S) */
    }

}
