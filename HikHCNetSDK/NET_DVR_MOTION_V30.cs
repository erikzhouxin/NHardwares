using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道图象结构
    //移动侦测(子结构)(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MOTION_V30
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96 * 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byMotionScope;/*侦测区域,0-96位,表示64行,共有96*64个小宏块,为1表示是移动侦测区域,0-表示不是*/
        public byte byMotionSensitive;/*移动侦测灵敏度, 0 - 5,越高越灵敏,oxff关闭*/
        public byte byEnableHandleMotion;/* 是否处理移动侦测 0－否 1－是*/
        public byte byEnableDisplay;/* 启用移动侦测高亮显示：0- 否，1- 是 */
        public byte reservedData;
        public NET_DVR_HANDLEEXCEPTION_V30 struMotionHandleType;/* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;/*布防时间*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.I1)]
        public byte[] byRelRecordChan;/* 报警触发的录象通道*/
    }
}
