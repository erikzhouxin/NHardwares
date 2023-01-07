using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCENEDISPCFG
    {
        public byte byEnable;//是否启用，0-不启用，1-启用
        public byte bySoltNum;//槽位号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byDispChanNum;
        public byte byAudio;                /*音频是否开启,0-否，1-是*/
        public byte byAudioWindowIdx;      /*音频开启子窗口*/
        public byte byVedioFormat;          /*1:NTSC,2:PAL，0-NULL*/
        public byte byWindowMode;           /*画面模式，从能力集获取*/
        public byte byEnlargeStatus;         /*是否处于放大状态，0：不放大，1：放大*/
        public byte byEnlargeSubWindowIndex;//放大的子窗口号    
        public byte byScale; /*显示模式，0-真实显示，1-缩放显示( 针对BNC )*/
        public uint dwResolution;//分辨率
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecChan;/*各个子窗口关联的解码通道*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecoderId;/*槽位号*/
        //显示窗口所解视频分辨率，1-D1,2-720P,3-1080P，设备端需要根据此//分辨率进行解码通道的分配，如1分屏配置成1080P，则设备会把4个解码通道都分配给此解码通道
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS_V41, ArraySubType = UnmanagedType.I1)]
        public byte[] byDecResolution;
        public byte byRow;//大屏所在的行的序号
        public byte byColumn;//大屏所在的列的序号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public NET_DVR_RECTCFG struDisp; //电视墙显示位置
    }
}
