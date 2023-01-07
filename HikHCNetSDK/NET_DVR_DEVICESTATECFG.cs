using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEVICESTATECFG
    {
        public uint dwSize;
        public ushort wPreviewNum; //预览连接个数
        public ushort wFortifyLinkNum; //布防连接个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LINK, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPADDR[] struPreviewIP;  //预览的用户IP地址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FORTIFY_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPADDR[] struFortifyIP; //布防连接的用户IP地址
        public uint dwVideoFrameRate;   //帧率：0-全部; 1-1/16; 2-1/8; 3-1/4; 4-1/2; 5-1; 6-2; 7-4; 8-6; 9-8; 10-10; 11-12; 12-16; 13-20; 14-15; 15-18; 16-22;
        public byte byResolution;   //分辨率0-DCIF 1-CIF, 2-QCIF, 3-4CIF, 4-2CIF 5（保留）,16-VGA（640*480）, 17-UXGA（1600*1200）, 18-SVGA （800*600）,19-HD720p（1280*720）,20-XVGA,  21-HD900p, 27-HD1080i, 28-2560*1920, 29-1600*304, 30-2048*1536, 31-2448*2048
        public byte bySnapResolution;   //抓拍分辨率0-DCIF 1-CIF, 2-QCIF, 3-4CIF, 4-2CIF 5（保留）,16-VGA（640*480）, 17-UXGA（1600*1200）, 18-SVGA （800*600）,19-HD720p（1280*720）,20-XVGA,  21-HD900p, 27-HD1080i, 28-2560*1920, 29-1600*304, 30-2048*1536, 31-2448*2048
        public byte byStreamType; //传输类型：0-主码流；1-子码流
        public byte byTriggerType; //触发模式：0-视频触发；1-普通触发
        public uint dwSDVolume;  //SD卡容量
        public uint dwSDFreeSpace; //SD卡剩余空间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DRIVECHAN_NUM * HikHCNetSdk.MAX_COIL_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byDetectorState;  //车检器状态：0-未使用；1-正常；2-异常
        public byte byDetectorLinkState; //车检器连接状态：0-未连接；1-连接
        public byte bySDStatus;    //SD卡状态 0－活动；1－休眠；2－异常，3-无sd卡
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FORTIFY_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byFortifyLevel; //布防等级，0-无，1-一等级（高），2-二等级（中），3-三等级（低）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 116, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
    }

}
