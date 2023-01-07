using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_STATUS
    {
        public int dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byErrorMsg;//下发错误信息，当byCardReaderRecvStatus为4时，表示已存在人脸对应的卡号
        public int dwReaderNo; //人脸读卡器编号，可用于下发错误返回
        public byte byRecvStatus;  //人脸读卡器状态，按字节表示，0-失败，1-成功，2-重试或人脸质量差，3-内存已满(人脸数据满)，4-已存在该人脸，5-非法人脸ID
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 131, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byErrorMsg = new byte[HikHCNetSdk.ERROR_MSG_LEN];
            byRes = new byte[131];
        }
    }
}
