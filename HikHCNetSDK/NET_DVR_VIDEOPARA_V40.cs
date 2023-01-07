using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOPARA_V40
    {
        public uint dwChannel;          // 通道号
        public uint dwVideoParamType;   // 视频参数类型 0-亮度 1-对比度 2-饱和度 3-色度 4-锐度 5-去噪
        public uint dwVideoParamValue;  //对应的视频参数值，范围依据能力集
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
