using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    public struct NET_DVR_FACELIB_GUARD_COND
    {
        public uint dwSize;
        public uint dwChannel;  //通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68, ArraySubType = UnmanagedType.I1)]
        public byte[] szFDID;//人脸库的ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
