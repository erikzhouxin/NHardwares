using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FD_IMAGE_CFG
    {
        public uint dwWidth;                  //灰度图像数据宽度
        public uint dwHeight;                 //灰度图像高度
        public uint dwImageLen;  //灰度图像数据长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
        public IntPtr pImage;    //灰度图像数据
    }
}
