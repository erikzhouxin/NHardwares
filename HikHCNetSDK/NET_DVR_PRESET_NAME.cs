using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //云台预置点信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PRESET_NAME
    {
        public uint dwSize;
        public ushort wPresetNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byName;
        public ushort wPanPos;
        public ushort wTiltPos;
        public ushort wZoomPos;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 58, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
