using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //离岗事件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_LEAVE_POSITION
    {
        public NET_VCA_POLYGON struRegion; //区域范围
        public ushort wLeaveDelay;  //无人报警时间，单位：s，取值1-1800
        public ushort wStaticDelay; //睡觉报警时间，单位：s，取值1-1800
        public byte byMode;       //模式，0-离岗事件，1-睡岗事件，2-离岗睡岗事件
        public byte byPersonType; //值岗人数类型，0-单人值岗，1-双人值岗
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
    }

}
