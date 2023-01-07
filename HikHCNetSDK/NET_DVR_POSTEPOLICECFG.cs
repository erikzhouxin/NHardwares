using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_POSTEPOLICECFG
    {
        public uint dwSize;
        public uint dwDistance;//线圈距离,单位cm，取值范围[0,20000]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SIGNALLIGHT_NUM, ArraySubType = UnmanagedType.U4)]
        public uint[] dwLightChan;  //信号灯通道号
        public byte byCapSpeed;//标志限速，单位km/h，取值范围[0,255]
        public byte bySpeedLimit;//限速值，单位km/h，取值范围[0,255]
        public byte byTrafficDirection;//车流方向，0-由东向西，1-由西向东，2-由南向北，3-由北向南
        public byte byRes1; //保留
        public ushort wLoopPreDist;        /*触发延迟距离 ，单位：分米*/
        public ushort wTrigDelay;             /*触发硬延时时间 ，单位：毫秒*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留字节
    }

}
