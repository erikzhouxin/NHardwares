using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECORD_V40
    {
        public uint dwSize;
        public uint dwRecord;                          /*是否录像 0-否 1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_RECORDDAY_V40[] struRecAllDay;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_RECORDSCHED_V40[] struRecordSched;
        public uint dwRecordTime;                    /* 录象延时长度 0-5秒， 1-10秒， 2-30秒， 3-1分钟， 4-2分钟， 5-5分钟， 6-10分钟*/
        public uint dwPreRecordTime;                /* 预录时间 0-不预录 1-5秒 2-10秒 3-15秒 4-20秒 5-25秒 6-30秒 7-0xffffffff(尽可能预录) */
        public uint dwRecorderDuration;                /* 录像保存的最长时间 */
        public byte byRedundancyRec;    /*是否冗余录像,重要数据双备份：0/1*/
        public byte byAudioRec;        /*录像时复合流编码时是否记录音频数据：国外有此法规*/
        public byte byStreamType;  // 0-主码流，1-子码流，2-主子码流同时 3-三码流
        public byte byPassbackRecord;  // 0:不回传录像 1：回传录像
        public ushort wLockDuration;  // 录像锁定时长，单位小时 0表示不锁定，0xffff表示永久锁定，录像段的时长大于锁定的持续时长的录像，将不会锁定
        public byte byRecordBackup;  // 0:录像不存档 1：录像存档
        public byte bySVCLevel;    //SVC抽帧类型：0-不抽，1-抽二分之一 2-抽四分之三
        public byte byRecordManage;   //录像调度，0-启用， 1-不启用; 启用时进行定时录像；不启用时不进行定时录像，但是录像计划仍在使用，比如移动侦测，回传都还在按这条录像计划进行
        public byte byExtraSaveAudio;//音频单独存储
        /*开启智能录像功能后，算法库是自动启用智能录像算法，其功能为若录像中无目标出现，会降低码率、帧率，而目标出现时又恢复全码率及帧率，从而达到减少资源消耗的目的*/
        public byte byIntelligentRecord;//是否开启智能录像功能 0-否 1-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 125, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
