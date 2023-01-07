using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //球机本地规则菜单配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRACK_PARAMCFG
    {
        public uint dwSize;             // 结构大小
        public ushort wAlarmDelayTime;    // 报警延时时间，目前球机只支持全局入侵 范围1-120秒
        public ushort wTrackHoldTime;     // 报警跟踪持续时间  范围0-300秒
        public byte byTrackMode;        //  参照 IPDOME_TRACK_MODE
        public byte byPreDirection; // 跟踪方向预判 0-不启用 1-启用
        public byte byTrackSmooth;      // 跟踪连续  0-不启用 1-启用
        public byte byZoomAdjust;   // 倍率系数调整 参见下表
        public byte byMaxTrackZoom; //最大跟踪倍率系数,0-表示默认倍率系数,等级6-标定值*1.0(默认),1-5为缩小标定值，值越小，缩小的比例越大,7-15为放大，值越大，放大的比例越大
        public byte byStopTrackWhenFindFace;  //人脸检测到后是否停止跟踪 0-否 1-是
        public byte byStopTrackThreshold;   //跟踪终止评分阈值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;          //  保留字节                
    }


}
