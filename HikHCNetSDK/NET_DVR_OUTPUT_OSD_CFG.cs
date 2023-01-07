using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OUTPUT_OSD_CFG
    {
        public uint dwSize;
        public byte byEnable; //OSD是否显示，0-不显示，1-显示
        public byte byFontSize; //字体大小，1-大，2-中，3-小
        public byte byOSDColor; //OSD颜色配置，0-默认， 1-黑，2-白，3-红，4-绿，5-蓝
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_OSD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byOsdContent; //OSD内容
        public NET_DVR_RECTCFG_EX struRect;//OSD位置，输出口范围总大小为1920*1920
        public uint dwOsdWinNo; //输出口OSD窗口号（1字节设备号+1字节输出口号+2字节OSD窗口号），获取所有时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                //保留
    }
}
