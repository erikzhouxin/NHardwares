using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BACKUP_TIME_PARAM
    {
        public int lChannel;        //按时间备份的通道
        public NET_DVR_TIME struStartTime;   //备份的起始时间
        public NET_DVR_TIME struStopTime;    //备份的终止时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] byDiskDes;     //备份磁盘描述
        public byte byWithPlayer;               //是否备份播放器
        public byte byContinue;                 //是否继续备份 0不继续 1继续
        public byte byDrawFrame;                 //0 不抽帧  1 抽帧
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 33, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                     // 保留字节 
    }
}
