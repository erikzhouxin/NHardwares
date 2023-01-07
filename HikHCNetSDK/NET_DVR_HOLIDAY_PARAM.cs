using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDAY_PARAM
    {
        public byte byEnable;           // 是否启用
        public byte byDateMode;         // 日期模式 0-模式A 1-模式B 2-模式C
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;           // 保留字节
        public NET_DVR_HOLIDATE_UNION uHolidate;    // 假日日期
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName;   // 假日名称
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;           // 保留字节
    }
}
