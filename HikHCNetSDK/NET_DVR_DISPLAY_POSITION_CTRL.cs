using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示单元位置控制
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISPLAY_POSITION_CTRL
    {
        public byte byPositionType; //1-水平位置 2-垂直位置，
        public char byScale;            //-1 、0、+1三个值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 14, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
