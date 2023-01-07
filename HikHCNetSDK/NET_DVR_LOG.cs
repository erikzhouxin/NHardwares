using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //日志信息
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_LOG
    {
        public NET_DVR_TIME strLogTime;
        public uint dwMajorType;//主类型 1-报警; 2-异常; 3-操作; 0xff-全部
        public uint dwMinorType;//次类型 0-全部;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPanelUser;//操作面板的用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sNetUser;//网络操作的用户名
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sRemoteHostAddr;//远程主机地址
        public uint dwParaType;//参数类型
        public uint dwChannel;//通道号
        public uint dwDiskNumber;//硬盘号
        public uint dwAlarmInPort;//报警输入端口
        public uint dwAlarmOutPort;//报警输出端口
    }

}
