using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TIME_SEGMENT
    {
        public NET_DVR_SIMPLE_DAYTIME struBeginTime;  //begin time
        public NET_DVR_SIMPLE_DAYTIME struEndTime;    //end time
    }


}
