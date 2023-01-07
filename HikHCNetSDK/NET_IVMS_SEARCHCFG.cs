using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // IVMS 后检索配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_SEARCHCFG
    {
        public uint dwSize;
        public NET_DVR_MATRIX_DEC_REMOTE_PLAY struRemotePlay;// 远程回放
        public NET_IVMS_ALARM_JPEG struAlarmJpeg;// 报警上传图片配置
        public NET_IVMS_RULECFG struRuleCfg;//IVMS 行为规则配置
    }
}
