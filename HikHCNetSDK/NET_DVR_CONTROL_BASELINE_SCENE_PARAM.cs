using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //基准场景操作参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CONTROL_BASELINE_SCENE_PARAM
    {
        public uint dwSize;     //结构体大小
        public uint dwChannel;  //通道号
        public byte byCommand;  //操作类型，1-此字段保留，暂不使用，2-更新基准场景
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
