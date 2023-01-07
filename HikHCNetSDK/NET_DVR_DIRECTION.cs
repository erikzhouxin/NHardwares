using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //方向结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DIRECTION
    {
        public NET_VCA_POINT struStartPoint;   // 方向起始点
        public NET_VCA_POINT struEndPoint;     // 方向结束点 
    }



}
