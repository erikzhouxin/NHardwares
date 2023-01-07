using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HKDDNS_STREAM
    {
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byDDNSDomain;
        public ushort wPort;
        public ushort wAliasLen;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlias;
        public ushort wDVRSerialLen;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
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
            byDDNSDomain = new byte[64];
            byAlias = new byte[HikHCNetSdk.NAME_LEN];
            byRes1 = new byte[2];
            byDVRSerialNumber = new byte[HikHCNetSdk.SERIALNO_LEN];
            byUserName = new byte[HikHCNetSdk.NAME_LEN];
            byPassWord = new byte[HikHCNetSdk.PASSWD_LEN];
            byRes2 = new byte[11];
        }
    }

}
