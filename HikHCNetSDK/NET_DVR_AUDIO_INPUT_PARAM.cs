using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUDIO_INPUT_PARAM
    {
        public byte byAudioInputType;  //音频输入类型，0-mic in，1-line in
        public byte byVolume; //volume,[0-100]
        public byte byEnableNoiseFilter; //是否开启声音过滤-关，-开
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byres;
    }
}
