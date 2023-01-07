using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAMERA_DEHAZE_CFG
    {
        public uint dwSize;
        public byte byDehazeMode; //0-不启用，1-自动模式，2-开
        public byte byLevel; //等级，0-100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
