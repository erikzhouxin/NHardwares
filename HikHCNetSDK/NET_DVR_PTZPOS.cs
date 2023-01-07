using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //球机位置信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PTZPOS
    {
        public ushort wAction;//获取时该字段无效
        public ushort wPanPos;//水平参数
        public ushort wTiltPos;//垂直参数
        public ushort wZoomPos;//变倍参数
    }

}
