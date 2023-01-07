using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINGERPRINT_STATUS
    {
        public int dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN)]
        public byte[] byCardNo;
        public byte byCardReaderRecvStatus;//指纹读卡器状态，按字节表示，0-失败，1-成功，2-该指纹模组不在线，3-重试或指纹质量差，4-内存已满，5-已存在该指纹，6-已存在该指纹ID，7-非法指纹ID，8-该指纹模组无需配置
        public byte byFingerPrintID;//手指编号，有效值范围为1-10
        public byte byFingerType;//指纹类型  0-普通指纹，1-胁迫指纹
        public byte byRecvStatus;//主机错误状态：0-成功，1-手指编号错误，2-指纹类型错误，3-卡号错误（卡号规格不符合设备要求），4-指纹未关联工号或卡号（工号或卡号字段为空），5-工号不存在，6-指纹数据长度为0，7-读卡器编号错误，8-工号错误
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ERROR_MSG_LEN)]
        public byte[] byErrorMsg;//下发错误信息，当byCardReaderRecvStatus为5时，表示已存在指纹对应的卡号
        public int dwCardReaderNo;//当byCardReaderRecvStatus为5时，表示已存在指纹对应的指纹读卡器编号，可用于下发错误返回。0时表示无错误信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] byRes;
        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byErrorMsg = new byte[HikHCNetSdk.ERROR_MSG_LEN];

            byRes = new byte[20];
        }
    }

}
