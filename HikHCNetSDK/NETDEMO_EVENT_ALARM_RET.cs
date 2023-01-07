using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警输入结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_ALARM_RET
    {
        public uint dwAlarmInNo;//报警输入号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.SEARCH_EVENT_INFO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes = new byte[HikHCNetSdk.SEARCH_EVENT_INFO_LEN];
        }
    }


}
