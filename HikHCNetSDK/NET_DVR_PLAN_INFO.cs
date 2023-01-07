using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*预案项信息*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLAN_INFO
    {
        public byte byValid;        // 该项是否有效
        public byte byType;         // 见定义NET_DVR_PLAN_OPERATE_TYPE
        public ushort wLayoutNo;    // 布局号
        public byte byScreenStyle;    //屏幕型号，开关机所用，1是低亮，2是高亮
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwDelayTime;    // 一个项的运行时间, 单位秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
