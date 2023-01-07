using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LOCAL_CHECK_DEV
    {
        public uint dwCheckOnlineTimeout;     //巡检时间间隔，单位ms  最小值为30s，最大值120s。为0时，表示用默认值(120s)
        public uint dwCheckOnlineNetFailMax;  //由于网络原因失败的最大累加次数；超过该值SDK才回调用户异常，为0时，表示使用默认值1
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
