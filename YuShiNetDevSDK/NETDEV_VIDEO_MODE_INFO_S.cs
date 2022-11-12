using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_MODE_INFO_S
    {
        public Int32 udwWidth;                                      /* 图像宽度 Image width*/
        public Int32 udwHeight;                                     /* 图像高度 Image height*/
        public Int32 udwFrameRate;                                  /* 图像帧率 Image frame rate*/
    }

}
