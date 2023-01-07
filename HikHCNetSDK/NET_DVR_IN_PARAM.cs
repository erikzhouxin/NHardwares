using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IN_PARAM
    {
        public NET_DVR_BUF_INFO struCondBuf;
        public NET_DVR_BUF_INFO struInParamBuf;
        public uint dwRecvTimeOut;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
