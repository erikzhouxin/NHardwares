using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HOLIDAY_PARAM_CFG
    {
        public uint dwSize;         // 结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_HOLIDAY_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_HOLIDAY_PARAM[] struHolidayParam;    // 假日参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留参数
    }
}
