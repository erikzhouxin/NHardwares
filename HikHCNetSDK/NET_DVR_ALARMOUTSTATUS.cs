using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警输出状态
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMOUTSTATUS
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] Output;
    }

}
