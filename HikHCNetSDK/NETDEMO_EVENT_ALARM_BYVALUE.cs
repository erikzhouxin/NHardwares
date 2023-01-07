using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警输入 按值表示
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_ALARM_BYVALUE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.U2)]
        public ushort[] wAlarmInNo;//报警输入号，byAlarmInNo[0]若置1则表示查找由报警输入1触发的事件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 44, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            wAlarmInNo = new ushort[128];
            byRes = new byte[44];
        }
    }


}
