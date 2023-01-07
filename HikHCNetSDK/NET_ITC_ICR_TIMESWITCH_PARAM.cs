using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_ICR_TIMESWITCH_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_ITC_ICRTIMECFG[] struAutoCtrlTime;//自动切换时间段 (自动切换下 时空下生效 现在支持4组，预留4组)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ICR_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byICRPreset; //实际生效根据能力集动态显示 [0~100] 数组下标表示预置点号1～8 （0～7 相对应）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
