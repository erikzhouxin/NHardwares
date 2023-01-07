using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VCA_VERSION
    {
        public ushort wMajorVersion;        // 主版本号
        public ushort wMinorVersion;        // 次版本号
        public ushort wRevisionNumber;  // 修正号
        public ushort wBuildNumber;     // 编译号
        public ushort wVersionYear;     //	版本日期-年
        public byte byVersionMonth;     //	版本日期-月
        public byte byVersionDay;       //	版本日期-日
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            // 保留字节
    }



}
