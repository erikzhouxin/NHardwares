using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //显示通道配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECTCFG_SCENE
    {
        public ushort wXCoordinate; /*矩形左上角起始点X坐标*/
        public ushort wYCoordinate; /*矩形左上角Y坐标*/
        public ushort wWidth;       /*矩形宽度*/
        public ushort wHeight;      /*矩形高度*/
    }
}
