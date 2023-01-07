using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2009-12-1 增加被动解码播放控制
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PASSIVEDECODE_CONTROL
    {
        public uint dwSize;
        public uint dwPlayCmd;      /* 播放命令 见文件播放命令*/
        public uint dwCmdParam;     /* 播放命令参数 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//Reverse
    }
}
