using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //智能搜索参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SMART_SEARCH_PARAM
    {
        public byte byChan;                 //通道号
        public byte bySearchCondType; //智能查找联合体NET_DVR_AREA_SMARTSEARCH_COND_UNION的索引     
        /*0-移动侦测区域 ，1-越界侦测， 2-区域入侵*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_TIME struStartTime;      //录像开始的时间
        public NET_DVR_TIME struEndTime;        //录像停止的时间
        public NET_DVR_AREA_SMARTSEARCH_COND_UNION uSmartSearchCond;  //智能查找条件
        public byte bySensitivity;              //移动侦测搜索灵敏度,1	>80%  2 40%~80%  3 1%~40%
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
