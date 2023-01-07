using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAPTURE_FACE_CFG
    {
        public int dwSize;
        public int dwFaceTemplate1Size;//人脸模板1数据大小，等于0时，代表无人脸模板1数据
        public IntPtr pFaceTemplate1Buffer;//人脸模板1数据缓存（不大于2.5k）
        public int dwFaceTemplate2Size;//人脸模板2数据大小，等于0时，代表无人脸模板2数据
        public IntPtr pFaceTemplate2Buffer; //人脸模板2数据缓存（不大于2.5K）
        public int dwFacePicSize;//人脸图片数据大小，等于0时，代表无人脸图片数据;
        public IntPtr pFacePicBuffer;//人脸图片数据缓存;
        public byte byFaceQuality1;//人脸质量，范围1-100
        public byte byFaceQuality2;//人脸质量，范围1-100
        public byte byCaptureProgress;    //采集进度，目前只有两种进度值：0-未采集到人脸，100-采集到人脸（只有在进度为100时，才解析人脸信息）
        public byte byRes1;
        public int dwInfraredFacePicSize;   //红外人脸图片数据大小，等于0时，代表无人脸图片数据
        public IntPtr pInfraredFacePicBuffer;      //红外人脸图片数据缓存
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 116, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            byRes = new byte[116];
        }
    }

}
