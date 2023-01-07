using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //云台区域选择放大缩小(HIK 快球专用)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_POINT_FRAME
    {
        public int xTop;//方框起始点的x坐标
        public int yTop;//方框结束点的y坐标
        public int xBottom;//方框结束点的x坐标
        public int yBottom;//方框结束点的y坐标
        public int bCounter;//保留
    }

}
