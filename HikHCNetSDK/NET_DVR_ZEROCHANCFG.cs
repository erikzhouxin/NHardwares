using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //零通道压缩配置参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ZEROCHANCFG
    {
        public uint dwSize;             //结构长度
        public byte byEnable;           //0-停止零通道编码，1-表示启用零通道编码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;           //保留
        public uint dwVideoBitrate;     /*视频码率 0-保留 1-16K(保留) 2-32K 3-48k 4-64K 5-80K 6-96K 7-128K 8-160k 9-192K 10-224K 11-256K 
                                             * 12-320K 13-384K 14-448K 15-512K 16-640K 17-768K 18-896K 19-1024K 20-1280K 21-1536K 22-1792K
                                             * 23-2048K
                                             * 最高位(31位)置成1表示是自定义码流, 0-30位表示码流值(MIN-32K MAX-8192K) */
        public uint dwVideoFrameRate;   //帧率 0-全部; 1-1/16; 2-1/8; 3-1/4; 4-1/2; 5-1; 6-2; 7-4; 8-6; 9-8; 10-10; 11-12; 12-16; 13-20, 
                                        //V2.0增加14-15, 15-18, 16-22;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;        //保留
    }
}
