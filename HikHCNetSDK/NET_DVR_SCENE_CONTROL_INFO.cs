using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_SCENE_CONTROL_INFO
    {
        public uint dwSize;
        public NET_DVR_VIDEO_WALL_INFO struVideoWallInfo;
        public uint dwCmd;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
