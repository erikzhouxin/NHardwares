using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //语音对讲参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSION_AUDIO
    {
        public byte byAudioEncType;//音频编码类型 0-G722; 1-G711
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byres;//这里保留音频的压缩参数 
    }

}
