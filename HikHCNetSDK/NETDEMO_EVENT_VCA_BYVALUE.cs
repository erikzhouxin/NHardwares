using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析--按值方式查找 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_VCA_BYVALUE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.U2)]
        public ushort[] wChanNo;    //触发事件的通道			
        public byte byRuleID;      //行为分析类型，规则0xff表示全部，从0开始
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 171, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     /*保留*/
        public void Init()
        {
            wChanNo = new ushort[64];
            byRes = new byte[171];
        }
    }


}
