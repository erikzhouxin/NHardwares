using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //录象文件参数(cvr)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_FINDDATA_V40
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string sFileName;//文件名
        public NET_DVR_TIME struStartTime;//文件的开始时间
        public NET_DVR_TIME struStopTime;//文件的结束时间
        public uint dwFileSize;//文件的大小
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sCardNum;
        public byte byLocked;//9000设备支持,1表示此文件已经被锁定,0表示正常的文件
        public byte byFileType;  //文件类型:0－定时录像,1-移动侦测 ，2－报警触发，
                                 //3-报警|移动侦测 4-报警&移动侦测 5-命令触发 6-手动录像,7－震动报警，8-环境报警，9-智能报警，10-PIR报警，11-无线报警，12-呼救报警,14-智能交通事件
        public byte byQuickSearch; //0:普通查询结果，1：快速（日历）查询结果
        public byte byRes;
        public uint dwFileIndex; //文件索引号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }

}
