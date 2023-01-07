using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //按时间锁定
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TIME_LOCK
    {
        public uint dwSize;      //结构体大小
        public NET_DVR_TIME strBeginTime;
        public NET_DVR_TIME strEndTime;
        public uint dwChannel;        //通道号, 0xff表示所有通道
        public uint dwRecordType;     //录像类型:  0xffffffff－全部，0－定时录像，1-移动侦测，2－报警触发，3-报警触发或移动侦测，4-报警触发和移动侦测，5-命令触发，6-手动录像，7-智能录像(同文件查找)
        public uint dwLockDuration;   //锁定持续时间,单位秒,0xffffffff表示永久锁定
        public NET_DVR_TIME_EX strUnlockTimePoint;  //加锁时有效，当dwLockDuration不为永久锁定时，锁定持续的时间到此时间点就自动解锁
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
