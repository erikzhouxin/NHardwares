using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //区域框结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RECT
    {
        public float fX;//边界框左上角点的X轴坐标, 0.001~1
        public float fY;//边界框左上角点的Y轴坐标, 0.001~1
        public float fWidth;//边界框的宽度, 0.001~1
        public float fHeight;//边界框的高度, 0.001~1
    }

}
