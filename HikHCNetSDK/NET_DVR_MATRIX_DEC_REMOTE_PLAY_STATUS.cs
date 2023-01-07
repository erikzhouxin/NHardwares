using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_DEC_REMOTE_PLAY_STATUS
    {
        public uint dwSize;
        public uint dwCurMediaFileLen;/* 当前播放的媒体文件长度 */
        public uint dwCurMediaFilePosition;/* 当前播放文件的播放位置 */
        public uint dwCurMediaFileDuration;/* 当前播放文件的总时间 */
        public uint dwCurPlayTime;/* 当前已经播放的时间 */
        public uint dwCurMediaFIleFrames;/* 当前播放文件的总帧数 */
        public uint dwCurDataType;/* 当前传输的数据类型，19-文件头，20-流数据， 21-播放结束标志 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 72, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
