using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_ICR_AOTOSWITCH_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ICR_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byICRPreset; //实际生效根据能力集动态显示 [0~100] 数组下标表示预置点号1～8 （0～7 相对应）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 148, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
