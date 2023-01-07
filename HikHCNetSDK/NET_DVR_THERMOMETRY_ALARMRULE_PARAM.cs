using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_THERMOMETRY_ALARMRULE_PARAM
    {
        public byte byEnabled;
        public byte byRuleID;
        public byte byRule;
        public byte byRes;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.NAME_LEN)]
        public string szRuleName;
        public float fAlert;
        public float fAlarm;
        public float fThreshold;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
