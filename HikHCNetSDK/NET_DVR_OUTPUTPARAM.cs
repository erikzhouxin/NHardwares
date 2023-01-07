using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************输出参数配置*******************************/
    /*输出通道管理*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_OUTPUTPARAM
    {
        public uint dwSize;
        public byte byMonMode;      /*输出连接模式,1-BNC,2-VGA,3-DVI,4-HDMI*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwResolution;   /*分辨率，根据能力集获取所支持的进行设置*/
        public NET_DVR_VIDEOEFFECT struVideoEffect; /*输出通道视频参数配置*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
