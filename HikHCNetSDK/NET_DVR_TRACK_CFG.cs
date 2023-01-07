using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //球机配置结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRACK_CFG
    {
        public uint dwSize;             //结构长度	
        public byte byEnable;               //标定使能
        public byte byFollowChan;          // 被控制的从通道
        public byte byDomeCalibrate;            //设置智能跟踪球机标定，1设置 0不设置 
        public byte byRes;                  // 保留字节
        public NET_DVR_TRACK_CALIBRATION_PARAM struCalParam; //标定点组
    }
}
