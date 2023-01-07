using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLEWALLPARAM
    {
        public uint dwSize;
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwWallNum;//电视墙输出号
                              //坐标须为基准坐标的整数倍（128×128），宽度和高度值不用设置，即为基准值
        public NET_DVR_RECTCFG struRectCfg;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 36, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
