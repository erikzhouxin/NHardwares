using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SNAPENABLECFG
    {
        public uint dwSize;
        public byte byPlateEnable;//是否支持车牌识别，0-不支持，1-支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;   //保留
        public byte byFrameFlip;   //图像是否翻转 0-不翻转，1-翻转
        public ushort wFlipAngle;    //图像翻转角度 0,90,180,270
        public ushort wLightPhase;   //相位，取值范围[0, 360]
        public byte byLightSyncPower;  //是否信号灯电源同步，0-不同步；1-同步
        public byte byFrequency;        //信号频率
        public byte byUploadSDEnable;  //是否自动上传SD图片，0-否；1-是
        public byte byPlateMode; //识别模式参数:0-视频触发,1-外部触发
        public byte byUploadInfoFTP; //是否上传抓拍附加信息到FTP，0-否，1-是
        public byte byAutoFormatSD; //是否自动格式化SD卡，0-否，1-是
        public ushort wJpegPicSize; //Jpeg图片大小[64-8196]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 56, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }



}
