using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEO_INPUT_EFFECT
    {
        public uint dwSize;             //结构体大小
        public ushort wEffectMode;        //模式 0-标准 1-室内 2-弱光 3-室外  255-自定义
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 146, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;        //保留
        public NET_DVR_VIDEO_EFFECT struVideoEffect;    //视频效果参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           //保留
    }
}
