using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_ITC_RADAR_PARAM
    {
        public byte byRadarType;
        public byte byLevelAngle;
        public ushort wRadarSensitivity;
        public ushort wRadarSpeedValidTime;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public float fLineCorrectParam;
        public int iConstCorrectParam;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }

}
