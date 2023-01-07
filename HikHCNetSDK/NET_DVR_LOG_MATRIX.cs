using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LOG_MATRIX
    {
        public NET_DVR_TIME strLogTime;
        public uint dwMajorType;
        public uint dwMinorType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPanelUser;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sNetUser;
        public NET_DVR_IPADDR struRemoteHostAddr;
        public uint dwParaType;
        public uint dwChannel;
        public uint dwDiskNumber;
        public uint dwAlarmInPort;
        public uint dwAlarmOutPort;
        public uint dwInfoLen;
        public byte byDevSequence;//槽位号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMacAddr;//MAC地址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSerialNumber;//序列号
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.LOG_INFO_LEN - HikHCNetSdk.SERIALNO_LEN - HikHCNetSdk.MACADDR_LEN - 1)]
        public string sInfo;
    }
}
