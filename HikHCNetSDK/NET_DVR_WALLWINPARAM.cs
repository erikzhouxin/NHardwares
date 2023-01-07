using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //窗口相关参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WALLWINPARAM
    {
        public uint dwSize;
        public byte byTransparency; //使能透明度，0-关，非0-开	
        public byte byWinMode;//窗口分屏模式，能力集获取
        public byte byEnableSpartan;//畅显使能，0-关，1-开
        public byte byDecResource;  //为窗口分配的解码资源，1-D1,2-720P,3-1080P
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
