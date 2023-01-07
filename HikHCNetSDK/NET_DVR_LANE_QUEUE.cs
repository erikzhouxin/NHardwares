using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //车道队列结构体 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LANE_QUEUE
    {
        public NET_VCA_POINT struHead;       //队列头
        public NET_VCA_POINT struTail;       //队列尾
        public uint dwLength;      //实际队列长度 单位为米 [0-500]
    }



}
