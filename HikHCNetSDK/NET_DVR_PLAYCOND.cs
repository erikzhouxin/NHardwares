using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLAYCOND
    {
        public uint dwChannel;
        public NET_DVR_TIME struStartTime;
        public NET_DVR_TIME struStopTime;
        public byte byDrawFrame;  //0:不抽帧，1：抽帧
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;    //保留
    }
}
