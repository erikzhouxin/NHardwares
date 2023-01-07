using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEV_ACCESS_CFG
    {
        public uint dwSize;
        public NET_DVR_IPADDR struIP;       //接入设备的IP地址
        public ushort wDevicePort;              //端口号
        public byte byEnable;                //是否启用，0-否，1-是
        public byte byRes1;             //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;    //接入设备的登录帐号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;    //接入设备的登录密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
