using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //遮挡报警(子结构)(9000扩展)  区域大小704*576
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HIDEALARM_V30
    {
        public uint dwEnableHideAlarm;/* 是否启动遮挡报警 ,0-否,1-低灵敏度 2-中灵敏度 3-高灵敏度*/
        public ushort wHideAlarmAreaTopLeftX;/* 遮挡区域的x坐标 */
        public ushort wHideAlarmAreaTopLeftY;/* 遮挡区域的y坐标 */
        public ushort wHideAlarmAreaWidth;/* 遮挡区域的宽 */
        public ushort wHideAlarmAreaHeight;/*遮挡区域的高*/
        public NET_DVR_HANDLEEXCEPTION_V30 strHideAlarmHandleType;  /* 处理方式 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SCHEDTIME[] struAlarmTime;//布防时间
    }
}
