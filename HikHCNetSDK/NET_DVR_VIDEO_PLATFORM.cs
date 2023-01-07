using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct NET_DVR_VIDEO_PLATFORM
    {
        [FieldOffsetAttribute(0)]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 160, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        /*[FieldOffsetAttribute(0)]
        public VideoPlatform struVideoPlatform;
        [FieldOffsetAttribute(0)]
        public NotVideoPlatform struNotVideoPlatform;
         * */
    }
}
