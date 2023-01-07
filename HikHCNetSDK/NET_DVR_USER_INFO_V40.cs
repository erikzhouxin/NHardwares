using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单用户参数(子结构)(扩展)
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_USER_INFO_V40
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;            /* 用户名只能用16字节 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;            /* 密码 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
        public byte[] byLocalRight; /* 本地权限 */
        /*数组0: 本地控制云台*/
        /*数组1: 本地手动录象*/
        /*数组2: 本地回放*/
        /*数组3: 本地设置参数*/
        /*数组4: 本地查看状态、日志*/
        /*数组5: 本地高级操作(升级，格式化，重启，关机)*/
        /*数组6: 本地查看参数 */
        /*数组7: 本地管理模拟和IP camera */
        /*数组8: 本地备份 */
        /*数组9: 本地关机/重启 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
        public byte[] byRemoteRight;/* 远程权限 */
        /*数组0: 远程控制云台*/
        /*数组1: 远程手动录象*/
        /*数组2: 远程回放 */
        /*数组3: 远程设置参数*/
        /*数组4: 远程查看状态、日志*/
        /*数组5: 远程高级操作(升级，格式化，重启，关机)*/
        /*数组6: 远程发起语音对讲*/
        /*数组7: 远程预览*/
        /*数组8: 远程请求报警上传、报警输出*/
        /*数组9: 远程控制，本地输出*/
        /*数组10: 远程控制串口*/
        /*数组11: 远程查看参数 */
        /*数组12: 远程管理模拟和IP camera */
        /*数组13: 远程关机/重启 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetPreviewRight;            /* 远程可以预览的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalRecordRight;           /* 本地可以录像的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetRecordRight;         /* 远程可以录像的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalPlaybackRight;         /* 本地可以回放的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetPlaybackRight;           /* 远程可以回放的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalPTZRight;              /* 本地可以PTZ的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwNetPTZRight;                /* 远程可以PTZ的通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V40, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalBackupRight;           /* 本地备份权限通道，从前往后顺序排列，遇到0xffffffff后续均为无效*/
        public NET_DVR_IPADDR struUserIP;               /* 用户IP地址(为0时表示允许任何地址) */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;    /* 物理地址 */
        public byte byPriority;             /* 优先级，0xff-无，0--低，1--中，2--高 */
        /* 无……表示不支持优先级的设置
        低……默认权限:包括本地和远程回放,本地和远程查看日志和状态,本地和远程关机/重启
        中……包括本地和远程控制云台,本地和远程手动录像,本地和远程回放,语音对讲和远程预览、本地备份,本地/远程关机/重启
        高……管理员 */
        public byte byAlarmOnRight;         // 报警输入口布防权限 1-有权限，0-无权限
        public byte byAlarmOffRight;         // 报警输入口撤防权限 1-有权限，0-无权限
        public byte byBypassRight;           // 报警输入口旁路权限 1-有权限，0-无权限 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 118, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
