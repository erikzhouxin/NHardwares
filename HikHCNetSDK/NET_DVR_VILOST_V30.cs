using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //信号丢失报警(子结构)(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VILOST_V30
    {
        public byte byEnableHandleVILost;/* 是否处理信号丢失报警 */
        public NET_DVR_HANDLEEXCEPTION_V30 strVILostHandleType;/* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 56, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
    }
}
