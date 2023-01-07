using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ASSOCIATECFG
    {
        public byte byAssociateType;//关联类型，1-报警
        public ushort wAlarmDelay;//报警延时，0－5秒；1－10秒；2－30秒；3－1分钟；4－2分钟；5－5分钟；6－10分钟；
        public byte byAlarmNum;//报警号，具体的值由应用赋，相同的报警赋相同的值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
