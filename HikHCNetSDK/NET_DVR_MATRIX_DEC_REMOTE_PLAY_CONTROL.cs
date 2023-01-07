using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY_CONTROL
    {
        public uint dwSize;
        public uint dwPlayCmd;/* 播放命令 见文件播放命令*/
        public uint dwCmdParam;/* 播放命令参数 */
    }
}
