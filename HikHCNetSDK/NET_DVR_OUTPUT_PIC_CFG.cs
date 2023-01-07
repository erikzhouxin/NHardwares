using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OUTPUT_PIC_CFG
    {
        public uint dwSize;
        public uint dwOutputPicNo;  //图片序号
        public byte byEnable; //logo是否显示，1-显示，0-隐藏
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_RECTCFG_EX struRect;//logo位置，输出口范围总大小为1920*1920
        public byte byFlash;  //是否闪烁1-闪烁，0-不闪烁
        public byte byTranslucent; //是否半透明1-半透明，0-不半透明
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                //保留
        public uint dwOutputPicWinNo; //输出口图片窗口号（1字节设备号+1字节输出口号+2字节输出口图片窗口号）,获取全部时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 28, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
