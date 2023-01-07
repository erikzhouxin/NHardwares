using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUDIOENC_INFO
    {
        public uint in_frame_size;                /* 输入一帧数据大小(BYTES)，由GetInfoParam函数返回         */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U4)]
        public int[] reserved;                 /* 保留 */
    }

}
