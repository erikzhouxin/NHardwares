using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //录象文件查找条件结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FILECOND
    {
        public int lChannel;//通道号
        public uint dwFileType;//录象文件类型0xff－全部，0－定时录像,1-移动侦测 ，2－报警触发，
                               //3-报警|移动侦测 4-报警&移动侦测 5-命令触发 6-手动录像
        public uint dwIsLocked;//是否锁定 0-正常文件,1-锁定文件, 0xff表示所有文件
        public uint dwUseCardNo;//是否使用卡号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] sCardNumber;//卡号
        public NET_DVR_TIME struStartTime;//开始时间
        public NET_DVR_TIME struStopTime;//结束时间
    }

}
