using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SEND_PARAM_IN
    {
        public IntPtr pSendData;
        public uint dwSendDataLen;
        public NET_DVR_TIME_V30 struTime;
        public byte byPicType;
        public byte byPicURL;  //图片数据采用URL方式 0-二进制图片数据，1-图片数据走URL方式
        public byte byUploadModeling;
        public byte byRes1;
        public uint dwPicMangeNo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string sPicName;
        public uint dwPicDisplayTime;
        public IntPtr pSendAppendData;
        public uint dwSendAppendDataLen;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 192, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
