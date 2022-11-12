using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_RECORD_STATUS
    {
        public Int32 dwChannelID;                    /* 通道号  Channel ID */
        public Int32 dwRecordType;                   /* 录像类型 0:手动录像1:事件录像2:交易录像3:定时录像4:其他*/
        public Int32 dwRecordStatus;                 /* 录像状态 0:正在录像1:未启动存储2:没有硬盘或硬盘坏3:通道不在线*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                       /* 保留字节 */
    }

}
