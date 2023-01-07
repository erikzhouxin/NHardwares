using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //移动侦测--按值
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_MOTION_BYVALUE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.U2)]
        public ushort[] wMotDetChanNo;//报警输入号，byAlarmInNo[0]若置1则表示查找由报警输入1触发的事件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 172, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            wMotDetChanNo = new ushort[64];
            byRes = new byte[172];
        }
    }


}
