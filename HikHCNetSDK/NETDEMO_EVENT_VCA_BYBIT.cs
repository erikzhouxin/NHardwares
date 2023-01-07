using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //行为分析
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_VCA_BYBIT
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byChanNo;//触发事件的通道
        public byte byRuleID;//规则ID，0xff表示全部
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 235, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留

        public void Init()
        {
            byChanNo = new byte[HikHCNetSdk.MAX_CHANNUM_V30];
            byRes1 = new byte[235];
        }
    }


}
