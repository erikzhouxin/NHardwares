using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //图片质量
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_JPEGPARA
    {
        /*注意：当图像压缩分辨率为VGA时，支持0=CIF, 1=QCIF, 2=D1抓图，
        当分辨率为3=UXGA(1600x1200), 4=SVGA(800x600), 5=HD720p(1280x720),6=VGA,7=XVGA, 8=HD900p
        仅支持当前分辨率的抓图*/
        public ushort wPicSize;/* 0=CIF, 1=QCIF, 2=D1 3=UXGA(1600x1200), 4=SVGA(800x600), 5=HD720p(1280x720),6=VGA*/
        public ushort wPicQuality;/* 图片质量系数 0-最好 1-较好 2-一般 */
    }
}
