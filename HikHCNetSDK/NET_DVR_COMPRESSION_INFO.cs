using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //码流压缩参数(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_COMPRESSION_INFO
    {
        public byte byStreamType;//码流类型0-视频流,1-复合流,表示压缩参数时最高位表示是否启用压缩参数
        public byte byResolution;//分辨率0-DCIF 1-CIF, 2-QCIF, 3-4CIF, 4-2CIF, 5-2QCIF(352X144)(车载专用)
        public byte byBitrateType;//码率类型0:变码率，1:定码率
        public byte byPicQuality;//图象质量 0-最好 1-次好 2-较好 3-一般 4-较差 5-差
        public uint dwVideoBitrate; //视频码率 0-保留 1-16K(保留) 2-32K 3-48k 4-64K 5-80K 6-96K 7-128K 8-160k 9-192K 10-224K 11-256K 12-320K
                                    // 13-384K 14-448K 15-512K 16-640K 17-768K 18-896K 19-1024K 20-1280K 21-1536K 22-1792K 23-2048K
                                    //最高位(31位)置成1表示是自定义码流, 0-30位表示码流值(MIN-32K MAX-8192K)。
        public uint dwVideoFrameRate;//帧率 0-全部; 1-1/16; 2-1/8; 3-1/4; 4-1/2; 5-1; 6-2; 7-4; 8-6; 9-8; 10-10; 11-12; 12-16; 13-20;
    }
}
