using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_BUTTON_DOWN_EXCEPTION_ALARM
    {
        public uint dwSize;     /*结构长度*/
        public NET_VCA_DEV_INFO struDevInfo;/*设备信息*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节
    }
}
