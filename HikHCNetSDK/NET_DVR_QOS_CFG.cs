using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_QOS_CFG
    {
        public uint dwSize;
        public byte byManageDscp;   // 管理数据的DSCP值 [0-63]
        public byte byAlarmDscp;    // 报警数据的DSCP值 [0-63]
        public byte byVideoDscp;    // 视频数据的DSCP值 [0-63]，byFlag为0时，表示音视频
        public byte byAudioDscp;    // 音频数据的DSCP值 [0-63]，byFlag为1时有效
        public byte byFlag;         // 0：音视频合一，1：音视频分开
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 126, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
