using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_INQUEST_CDRW_STATUS
    {
        /*运行状态：0-审讯开始，
         * 1-审讯过程中刻录，2-审讯停止，
         * 3-刻录审讯文件, 
         * 4-备份(事后备份和本地备份)
         * 5-空闲
         * 6-初始化硬盘
         * 7-恢复审讯*/
        public uint dwType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_INQUEST_CDRW_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_INQUEST_CDRW[] strCDRWNum;   //数组0表示刻录机1    
        public NET_DVR_TIME_EX struInquestStartTime;        //审讯开始的时间点
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;             //保留
    }
}
