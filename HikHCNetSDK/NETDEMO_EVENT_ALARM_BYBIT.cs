using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警输入
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_ALARM_BYBIT
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALARMIN_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byAlarmInNo;//报警输入号，byAlarmInNo[0]若置1则表示查找由报警输入1触发的事件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SEARCH_EVENT_INFO_LEN - HikHCNetSdk.MAX_ALARMIN_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byAlarmInNo = new byte[HikHCNetSdk.MAX_ALARMIN_V30];
            byRes = new byte[HikHCNetSdk.SEARCH_EVENT_INFO_LEN - HikHCNetSdk.MAX_CHANNUM_V30];
        }
    }


}
