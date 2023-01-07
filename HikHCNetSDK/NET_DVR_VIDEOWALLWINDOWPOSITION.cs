using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //窗口信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOWALLWINDOWPOSITION
    {
        public uint dwSize;
        public byte byEnable;  //窗口使能,0-不使能，1-使能 
        public byte byWndOperateMode;  //窗口操作模式，0-统一坐标，1-分辨率坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwWindowNo;//窗口号
        public uint dwLayerIndex;//窗口相对应的图层号，图层号到最大即置顶，置顶操作
        public NET_DVR_RECTCFG_EX struRect; //目的窗口统一坐标(相对显示墙)，获取或按统一坐标设置时有效
        public NET_DVR_RECTCFG_EX struResolution; //目的窗口分辨率坐标，获取或按分辨率坐标设置有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 44, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
