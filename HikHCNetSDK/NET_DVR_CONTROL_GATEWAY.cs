using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    public struct NET_DVR_CONTROL_GATEWAY
    {
        public uint dwSize; //结构体大小
        public uint dwGatewayIndex; //门禁序号，从1开始
        public byte byCommand; //操作命令，0-关闭，1-打开，2-常开（通道状态），3-恢复（普通状态）
        public byte byLockType; //锁类型，0-普通（以前默认都为0）,1-智能锁
        public ushort wLockID; //锁ID，从1开始（远程开门口机锁时，0表示门口机本机控制器上接的锁、1表示外接控制器上接的锁）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byControlSrc; //操作发起源信息
        public byte byControlType; //开锁类型，1-监视，2-通话
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPassword;       //锁密码，当byLockType为智能锁时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 108, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2; //保留
    }
}
