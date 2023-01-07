using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单用户参数(子结构)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_USER_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;/* 用户名 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;/* 密码 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLocalRight;/* 权限 */
        /*数组0: 本地控制云台*/
        /*数组1: 本地手动录象*/
        /*数组2: 本地回放*/
        /*数组3: 本地设置参数*/
        /*数组4: 本地查看状态、日志*/
        /*数组5: 本地高级操作(升级，格式化，重启，关机)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RIGHT, ArraySubType = UnmanagedType.U4)]
        public uint[] dwRemoteRight;/* 权限 */
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
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sUserIP;/* 用户IP地址(为0时表示允许任何地址) */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byMACAddr;/* 物理地址 */
    }

}
