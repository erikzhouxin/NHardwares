using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATMFINDINFO
    {
        public byte byTransactionType;       //交易类型 0-全部，1-查询， 2-取款， 3-存款， 4-修改密码，5-转账， 6-无卡查询 7-无卡存款， 8-吞钞 9-吞卡 10-自定义
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;    //保留
        public uint dwTransationAmount;     //交易金额 ;
    }
}
