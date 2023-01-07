using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SEARCH_EVENT_PARAM
    {
        public ushort wMajorType;//0-移动侦测，1-报警输入, 2-智能事件
        public ushort wMinorType;//搜索次类型- 根据主类型变化，0xffff表示全部
        public NET_DVR_TIME struStartTime;//搜索的开始时间，停止时间: 同时为(0, 0) 表示从最早的时间开始，到最后，最前面的4000个事件
        public NET_DVR_TIME struEndTime;
        public byte byLockType;     // 0xff-全部，0-未锁，1-锁定
        public byte byValue;            //0-按位表示，1-按值表示
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 130, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
        public SEARCH_EVENT_UNION uSeniorPara;
    }


}
