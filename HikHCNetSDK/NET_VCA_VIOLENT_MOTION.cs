using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //剧烈运动参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_VIOLENT_MOTION
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDuration;           //触发剧烈运动报警阈值：1-50秒
        public byte bySensitivity;       //灵敏度参数，范围[1,5]
        public byte byMode;              //0-纯视频模式，1-音视频联合模式，2-纯音频模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            //保留
    }

}
