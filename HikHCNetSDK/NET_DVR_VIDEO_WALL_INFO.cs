using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_VIDEO_WALL_INFO
    {
        public uint dwSize;
        public uint dwWindowNo;
        public uint dwSceneNo;
        public uint dwDestWallNo; //目的墙号
        public uint dwDestSceneNo;//目的场景号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
