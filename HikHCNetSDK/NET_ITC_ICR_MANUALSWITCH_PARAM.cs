using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_ICR_MANUALSWITCH_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ICR_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byICRPreset; //实际生效根据能力集动态显示 [0~100]
        public byte bySubSwitchMode;//1~白天，2~晚上
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 147, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
