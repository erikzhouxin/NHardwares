using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_VIDEOPLATFORM_V40
    {
        /*各个子窗口对应解码通道所对应的解码子系统的槽位号(对于视频综合平台中解码子系统有效)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOWS, ArraySubType = UnmanagedType.I1)]
        public byte[] byJoinDecoderId;
        //显示窗口所解视频分辨率，1-D1,2-720P,3-1080P，设备端需要根据此//分辨率进行解码通道的分配，如1分屏配置成1080P，则设备会把4个解码通
        //道都分配给此解码通道
        public byte byDecResolution;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 143, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
