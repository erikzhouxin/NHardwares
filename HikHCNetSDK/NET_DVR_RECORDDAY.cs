using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //全天录像参数配置(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECORDDAY
    {
        public ushort wAllDayRecord;/* 是否全天录像 0-否 1-是*/
        public byte byRecordType;/* 录象类型 0:定时录像，1:移动侦测，2:报警录像，3:动测|报警，4:动测&报警 5:命令触发, 6: 智能录像*/
        public byte reservedData;
    }
}
