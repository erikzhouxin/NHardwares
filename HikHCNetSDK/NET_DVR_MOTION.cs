using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //移动侦测(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MOTION
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 396, ArraySubType = UnmanagedType.I1)]
        public byte[] byMotionScope;/*侦测区域,共有22*18个小宏块,为1表示改宏块是移动侦测区域,0-表示不是*/
        public byte byMotionSensitive;/*移动侦测灵敏度, 0 - 5,越高越灵敏,0xff关闭*/
        public byte byEnableHandleMotion;/* 是否处理移动侦测 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string reservedData;
        public NET_DVR_HANDLEEXCEPTION strMotionHandleType;/* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;//报警触发的录象通道,为1表示触发该通道
    }
}
