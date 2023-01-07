using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARM_ISAPI_PICDATA
    {
        public uint dwPicLen;
        public byte byPicType;  //图片格式: 1- jpg
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FILE_PATH_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] szFilename;
        public IntPtr pPicData;
    }
}
