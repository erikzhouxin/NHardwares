using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITC_ICR_PARAM_UNION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 156, ArraySubType = UnmanagedType.I1)]
        public byte[] uLen;
        public NET_ITC_ICR_AOTOSWITCH_PARAM struICRAutoSwitch;
        public NET_ITC_ICR_MANUALSWITCH_PARAM struICRManualSwitch;
        public NET_ITC_ICR_TIMESWITCH_PARAM struICRTimeSwitch;
    }



}
