using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 音频编码
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUDIOENC_PROCESS_PARAM
    {
        public IntPtr in_buf;                      /* 输入buf */
        public IntPtr out_buf;                     /* 输出buf */
        public uint out_frame_size;               /* 编码一帧后的BYTE数 */
        public int g726enc_reset;                /* 重置开关 */
        public int g711_type;                    /* g711编码类型,0 - U law, 1- A law */
        public int enc_mode;                     /* 音频编码模式，AMR编码配置 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U4)]
        public int[] reserved;                 /* 保留 */
    }

}
