using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VOICEBROADCAST_CFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_VOICE_INFO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sInfo; //语音播报内容
        public byte byBroadcastNum;// 语音播报次数， 1~10次
        public byte byIntervalTime;// 语音播报间隔时间,1~5s
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 126, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
