using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ipc接入设备信息扩展，支持ip设备的域名添加
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPDEVINFO_V31
    {
        public byte byEnable;//该IP设备是否有效
        public byte byProType;
        public byte byEnableQuickAdd;
        public byte byRes1;//保留字段，置0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;//用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;//密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byDomain;//设备域名
        public NET_DVR_IPADDR struIP;//IP地址
        public ushort wDVRPort;// 端口号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留字段，置0

        public void Init()
        {
            sUserName = new byte[HikHCNetSdk.NAME_LEN];
            sPassword = new byte[HikHCNetSdk.PASSWD_LEN];
            byDomain = new byte[HikHCNetSdk.MAX_DOMAIN_NAME];
            byRes2 = new byte[34];
        }
    }

}
