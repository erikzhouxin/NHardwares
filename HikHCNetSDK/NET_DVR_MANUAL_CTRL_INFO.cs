using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //手动控制结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MANUAL_CTRL_INFO
    {
        public NET_VCA_POINT struCtrlPoint;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
