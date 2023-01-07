using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //IVMS的ATM进入区域参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_ENTER_REGION
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_ENTER_REGION[] struEnter;//进入区域
    }
}
