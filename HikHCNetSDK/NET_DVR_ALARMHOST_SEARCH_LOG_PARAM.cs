using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /************************动环报警管理主机日志查找 begin************************************************/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_SEARCH_LOG_PARAM
    {
        public ushort wMajorType;       // 主类型
        public ushort wMinorType;       // 次类型 
        public NET_DVR_TIME struStartTime;  // 开始时间 
        public NET_DVR_TIME struEndTime;    // 结束时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节
    }

}
