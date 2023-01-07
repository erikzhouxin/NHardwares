using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //硬盘状态
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISKSTATE
    {
        public uint dwVolume;//硬盘的容量
        public uint dwFreeSpace;//硬盘的剩余空间
        public uint dwHardDiskStatic;//硬盘的状态,0-活动,1-休眠,2-不正常
    }

}
