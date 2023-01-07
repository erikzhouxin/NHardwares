using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPSERVER_STREAM
    {
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_IPADDR struIPServer;
        public ushort wPort;
        public ushort wDvrNameLen;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDVRName;
        public ushort wDVRSerialLen;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U2)]
        public ushort[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDVRSerialNumber;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byUserName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPassWord;
        public byte byChannel;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public void Init()
        {
            byRes = new byte[3];
            byDVRName = new byte[HikHCNetSdk.NAME_LEN];
            byRes1 = new ushort[2];
            byDVRSerialNumber = new byte[HikHCNetSdk.SERIALNO_LEN];
            byUserName = new byte[HikHCNetSdk.NAME_LEN];
            byPassWord = new byte[HikHCNetSdk.PASSWD_LEN];
            byRes2 = new byte[11];
        }
    }

}
