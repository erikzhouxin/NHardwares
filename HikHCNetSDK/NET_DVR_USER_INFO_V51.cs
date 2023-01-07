using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单用户参数(子结构)(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER_INFO_V51
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;            /* 用户名只能用16字节 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;            /* 密码 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
        public byte[] byLocalRight;    /* 本地权限 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
        public byte[] byRemoteRight;/* 远程权限 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetPreviewRight;            /* 远程可以预览的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalRecordRight;            /* 本地可以录像的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetRecordRight;            /* 远程可以录像的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalPlaybackRight;            /* 本地可以回放的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetPlaybackRight;            /* 远程可以回放的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalPTZRight;                /* 本地可以PTZ的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetPTZRight;                /* 远程可以PTZ的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalBackupRight;            /* 本地备份权限通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalPreviewRight;      /* 本地预览权限通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        public NET_DVR_IPADDR struUserIP;                /* 用户IP地址(为0时表示允许任何地址) */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;    /* 物理地址 */
        public byte byPriority;                /* 优先级，0xff-无，0--低，1--中，2--高 */
        public byte byAlarmOnRight;         // 报警输入口布防权限 1-有权限，0-无权限
        public byte byAlarmOffRight;         // 报警输入口撤防权限 1-有权限，0-无权限
        public byte byBypassRight;           // 报警输入口旁路权限 1-有权限，0-无权限 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;               //四字节对齐
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
        public byte[] byPublishRight;  //信息发布专有权限
        public uint dwPasswordValidity;   //密码有效期,仅管理员用户可以修改,单位：天，填0表示永久生效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byKeypadPassword;    //键盘密码
        public byte byUserOperateType;    //用户操作类型，1-网络用户，2-键盘用户，3-网络用户+键盘用户
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1007, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
