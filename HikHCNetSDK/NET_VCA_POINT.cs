using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /***********************************end*******************************************/

    /************************************智能参数结构*********************************/
    //智能共用结构
    //坐标值归一化,浮点数值为当前画面的百分比大小, 精度为小数点后三位
    //点坐标结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_POINT
    {
        public float fX;// X轴坐标, 0.001~1
        public float fY;//Y轴坐标, 0.001~1
    }

}
