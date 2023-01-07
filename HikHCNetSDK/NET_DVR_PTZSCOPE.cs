using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //球机范围信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PTZSCOPE
    {
        public ushort wPanPosMin;//水平参数min
        public ushort wPanPosMax;//水平参数max
        public ushort wTiltPosMin;//垂直参数min
        public ushort wTiltPosMax;//垂直参数max
        public ushort wZoomPosMin;//变倍参数min
        public ushort wZoomPosMax;//变倍参数max
    }

}
