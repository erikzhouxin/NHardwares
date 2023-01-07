using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //时间段录像参数配置(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_RECORDSCHED
    {
        public NET_DVR_SCHEDTIME struRecordTime;
        public byte byRecordType;//0:定时录像，1:移动侦测，2:报警录像，3:动测|报警，4:动测&报警, 5:命令触发, 6: 智能录像
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string reservedData;
    }
}
