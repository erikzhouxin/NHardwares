using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RESET_COUNTER_CFG
    {
        public uint dwSize;
        public byte byEnable; //是否启用，0-不启用，1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_TIME_EX[] struTime;//数据清零时间，时分秒有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
