using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DDNS_STREAM_CFG
    {
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_IPADDR struStreamServer;
        public ushort wStreamServerPort;
        public byte byStreamServerTransmitType;
        public byte byRes2;
        public NET_DVR_IPADDR struIPServer;
        public ushort wIPServerPort;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDVRName;
        public ushort wDVRNameLen;
        public ushort wDVRSerialLen;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDVRSerialNumber;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassWord;
        public ushort wDVRPort;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes4;
        public byte byChannel;
        public byte byTransProtocol;
        public byte byTransMode;
        public byte byFactoryType;
        public void Init()
        {
            byRes1 = new byte[3];
            byRes3 = new byte[2];
            sDVRName = new byte[HikHCNetSdk.NAME_LEN];
            sDVRSerialNumber = new byte[HikHCNetSdk.SERIALNO_LEN];
            sUserName = new byte[HikHCNetSdk.NAME_LEN];
            sPassWord = new byte[HikHCNetSdk.PASSWD_LEN];
            byRes4 = new byte[2];
        }
    }

}
