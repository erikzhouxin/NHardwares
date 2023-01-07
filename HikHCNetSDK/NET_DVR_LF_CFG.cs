using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //LF双摄像机配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LF_CFG
    {
        public uint dwSize;//结构长度	
        public byte byEnable;//标定使能
        public byte byFollowChan;// 被控制的从通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_LF_CALIBRATION_PARAM struCalParam;//标定点组
    }
}
