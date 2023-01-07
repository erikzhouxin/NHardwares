using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //流量统计方向结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PDC_ENTER_DIRECTION
    {
        public NET_VCA_POINT struStartPoint; //流量统计方向起始点
        public NET_VCA_POINT struEndPoint;    // 流量统计方向结束点 
    }


}
