using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //录象文件参数(带卡号)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_FINDDATA_CARD
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string sFileName;//文件名
        public NET_DVR_TIME struStartTime;//文件的开始时间
        public NET_DVR_TIME struStopTime;//文件的结束时间
        public uint dwFileSize;//文件的大小
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sCardNum;
    }

}
