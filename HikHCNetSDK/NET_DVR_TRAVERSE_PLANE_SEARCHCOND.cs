using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //越界侦测查询条件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRAVERSE_PLANE_SEARCHCOND
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ALERTLINE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_TRAVERSE_PLANE[] struVcaTraversePlane;  //穿越境界面参数
        public uint dwPreTime;   /*智能报警提前时间 单位:秒*/
        public uint dwDelayTime; /*智能报警延迟时间 单位:秒*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5656, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
