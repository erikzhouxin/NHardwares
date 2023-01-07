using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //球机机芯参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DOME_MOVEMENT_PARAM
    {
        public ushort wMaxZoom;   // 球机最大倍率系数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 42, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  // 保留字节
    }


}
