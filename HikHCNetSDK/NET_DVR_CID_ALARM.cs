using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CID_ALARM
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CID_CODE_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sCIDCode;    //CID事件号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sCIDDescribe;    //CID事件名
        public NET_DVR_TIME_EX struTriggerTime;            //触发报警的时间点
        public NET_DVR_TIME_EX struUploadTime;                //上传报警的时间点
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACCOUNTNUM_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sCenterAccount;    //中心帐号
        public byte byReportType;                    //见定义NET_DVR_ALARMHOST_REPORT_TYPE
        public byte byUserType;                        //用户类型，0-网络用户 1-键盘用户,2-手机用户,3-系统用户
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;        //网络用户用户名
        public ushort wKeyUserNo;                        //键盘用户号    0xFFFF表示无效
        public byte byKeypadNo;                        //键盘号        0xFF表示无效
        public byte bySubSysNo;                        //子系统号        0xFF表示无效
        public ushort wDefenceNo;                        //防区号        0xFFFF表示无效
        public byte byVideoChanNo;                    //视频通道号    0xFF表示无效
        public byte byDiskNo;                        //硬盘号        0xFF表示无效
        public ushort wModuleAddr;                    //模块地址        0xFFFF表示无效
        public byte byCenterType;                    //0-无效, 1-中心账号(长度6),2-扩展的中心账号(长度9)
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACCOUNTNUM_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] sCenterAccountV40;    //中心账号V40,使用此字段时sCenterAccount无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 28, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
