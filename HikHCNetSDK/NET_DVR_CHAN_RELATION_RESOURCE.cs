using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHAN_RELATION_RESOURCE
    {
        public uint dwSize;
        public uint dwDisplayChan; //显示通道号（1字节设备号+1字节保留+2字节显示通道号）
        public byte byRelateAudio; //是否关联子窗口音频
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwSubWinNo; //关联音频的子窗口号（1字节电视墙号+1字节子窗口号+2字节窗口号）
        public uint dwChannel; //编码通道号，获取全部时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
