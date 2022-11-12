using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TMS_CAR_PLATE_PIC_INFO_S
    {
        public Int32 udwPicSize;       /* 图片大小 */
        public IntPtr pcPicData;       /* 图片数据 */
    };

}
