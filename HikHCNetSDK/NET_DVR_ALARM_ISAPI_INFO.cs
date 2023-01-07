using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARM_ISAPI_INFO
    {
        public IntPtr pAlarmData;           // 报警数据
        public uint dwAlarmDataLen;   // 报警数据长度
        public byte byDataType;        // 0-invalid,1-xml,2-json
        public byte byPicturesNumber;  // 图片数量
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public IntPtr pPicPackData;         // 图片变长部分
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
    }
}
