using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*OSD 叠加的位置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OSD_POSITION
    {
        public byte byPositionMode;/*叠加风格，共2种；0，不显示；1，Custom*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwPos_x;/*x坐标，positionmode为Custom时使用*/
        public uint dwPos_y;/*y坐标，positionmode为Custom时使用*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
