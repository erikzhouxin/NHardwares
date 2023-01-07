using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_THERMOMETRY_ALARMRULE
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.THERMOMETRY_ALARMRULE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_THERMOMETRY_ALARMRULE_PARAM[] struThermometryAlarmRuleParam;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
