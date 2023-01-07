using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DIGITALSCREEN
    {
        public NET_DVR_IPADDR struAddress;/*设备为数字设备时的IP信息*/
        public ushort wPort;        //通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 26, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
