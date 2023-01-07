using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_COND
    {
        public int dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN)]
        public byte[] byCardNo;//人脸关联的卡号（设置时该参数可不设置）
        public int dwFaceNum;// 设置或获取人脸数量，获取时置为0xffffffff表示获取所有人脸信息
        public int dwEnableReaderNo;// 人脸读卡器编号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124)]
        public byte[] byRes;
        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byRes = new byte[124];
        }
    }
}
