using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //走廊模式
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CORRIDOR_MODE_CCD
    {
        public byte byEnableCorridorMode; //是否启用走廊模式 0～不启用， 1～启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }



}
