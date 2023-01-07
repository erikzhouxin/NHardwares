using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能分析仪取流计划子结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_DEVSCHED
    {
        public NET_DVR_SCHEDTIME struTime;//时间参数
        public NET_DVR_PU_STREAM_CFG struPUStream;//前端取流参数
    }
}
