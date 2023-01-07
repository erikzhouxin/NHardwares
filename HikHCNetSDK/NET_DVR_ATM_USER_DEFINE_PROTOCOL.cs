using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //用户自定义协议
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_USER_DEFINE_PROTOCOL
    {
        public NET_DVR_IDENTIFICAT struIdentification;  //报文标志
        public NET_DVR_FILTER struFilter; //数据包过滤设置
        public NET_DVR_ATM_PACKAGE_OTHERS struCardNoPara; //叠加卡号设置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ACTION_TYPE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ATM_PACKAGE_ACTION[] struTradeActionPara; //叠加交易行为设置 0-9 依次对应InCard OutCard OverLay SetTime GetStatus Query WithDraw Deposit ChanPass Transfer
        public NET_DVR_ATM_PACKAGE_OTHERS struAmountPara; //叠加交易金额设置
        public NET_DVR_ATM_PACKAGE_OTHERS struSerialNoPara; //叠加交易序号设置
        public NET_DVR_OVERLAY_CHANNEL struOverlayChan; //叠加通道设置
        public NET_DVR_ATM_PACKAGE_DATE struRes1; //叠加日期，保留
        public NET_DVR_ATM_PACKAGE_TIME struRes2; //叠加时间，保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;        //保留
    }
}
