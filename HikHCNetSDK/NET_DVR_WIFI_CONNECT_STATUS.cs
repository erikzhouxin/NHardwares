using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //wifi连接状态
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WIFI_CONNECT_STATUS
    {
        public uint dwSize;
        public byte byCurStatus;    //1-已连接，2-未连接，3-正在连接
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       //保留
        public uint dwErrorCode;    // byCurStatus = 2时有效,1-用户名或密码错误,2-无此路由器,3-未知错误
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 244, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
