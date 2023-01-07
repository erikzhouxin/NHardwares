using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*IP报警输出*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPALARMOUTCFG_V40
    {
        public uint dwSize;  //结构体长度
        public uint dwCurIPAlarmOutNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_IP_ALARMOUT_V40, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_IPALARMOUTINFO_V40[] struIPAlarmOutInfo;/*IP报警输出*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
