using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SEARCH_EVENT_RET
    {
        [FieldOffset(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 304, ArraySubType = UnmanagedType.I1)]
        public byte[] byEventRetUnion;
        /*
        [FieldOffset(0)]
        public EVENT_ALARM_RET struAlarmRet;
        [FieldOffset(0)]
        public EVENT_MOTION_RET struMotionRet;
        [FieldOffset(0)]
        public EVENT_VCA_RET struVcaRet;
        [FieldOffset(0)]
        public EVENT_INQUEST_RET struInquestRet;
        [FieldOffset(0)]
        public EVENT_STREAMID_RET struStreamIDRet;
         * */
    }


}
