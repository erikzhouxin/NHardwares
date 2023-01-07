using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_MATRIX_DIGITALMATRIX
    {
        public NET_DVR_IPADDR struAddress; /*设备为数字设备时的IP信息*/
        public ushort wPort;
        public byte byNicNum; /*0 - eth0, 1 - eth1, 考虑双网口如何通信加入绑定的网口*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 69, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
