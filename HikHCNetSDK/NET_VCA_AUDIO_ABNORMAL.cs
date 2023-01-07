using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //声强突变参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_AUDIO_ABNORMAL
    {
        public ushort wDecibel;       //声音强度
        public byte bySensitivity;  //灵敏度参数，范围[1,5] 
        public byte byAudioMode;    //声音检测模式，0-灵敏度检测，1-分贝阈值检测，2-灵敏度与分贝阈值检测 
        public byte byEnable;       //使能，是否开启
        public byte byThreshold;    //声音阈值[0,100]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 54, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      //保留   
    }

}
