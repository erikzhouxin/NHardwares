using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /****************************DS9000新增结构(end)******************************/
    //时间点
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TIMEPOINT
    {
        public uint dwMonth;//月 0-11表示1-12个月
        public uint dwWeekNo;//第几周 0－第1周 1－第2周 2－第3周 3－第4周 4－最后一周
        public uint dwWeekDate;//星期几 0－星期日 1－星期一 2－星期二 3－星期三 4－星期四 5－星期五 6－星期六
        public uint dwHour;//小时	开始时间0－23 结束时间1－23
        public uint dwMin;//分	0－59
    }
}
