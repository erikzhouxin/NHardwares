using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FD_PROCIMG_CFG
    {
        public uint dwSize;           //结构大小
        public byte byEnable;         //是否激活规则;
        public byte bySensitivity;      //检测灵敏度，[0,5]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 22, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       //保留字节 
        public NET_VCA_SIZE_FILTER struSizeFilter;  //尺寸过滤器
        public NET_VCA_POLYGON struPolygon;    //多边形
        public NET_VCA_FD_IMAGE_CFG struFDImage;  //图片信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;    //保留
    }
}
