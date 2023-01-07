using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_LOG_RET
    {
        public NET_DVR_TIME struLogTime;                //  日志时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;     // 操作用户
        public NET_DVR_IPADDR struIPAddr;                 // 操作IP地址
        public ushort wMajorType;                 // 主类型 
        public ushort wMinorType;                 // 次类型
        public ushort wParam;                       // 操作参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public uint dwInfoLen;                  // 描述信息长度
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.LOG_INFO_LEN)]
        public string sInfo;       // 描述信息
    }

}
