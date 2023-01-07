using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_SDK_MANUAL_THERMOMETRY
    {
        public uint dwSize;//结构体大小
        public uint dwChannel;//通道号
        public uint dwRelativeTime; // 相对时标（只读）
        public uint dwAbsTime;      // 绝对时标（只读）
        public byte byThermometryUnit;//测温单位: 0-摄氏度（℃），1-华氏度（℉），2-开尔文(K)
        public byte byDataType;//数据状态类型:0-检测中，1-开始，2-结束（只读）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_SDK_MANUALTHERM_RULE struRuleInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
