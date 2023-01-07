using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //跟踪模式结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TRACK_MODE
    {
        public uint dwSize;     //结构长度
        public byte byTrackMode;   //跟踪模式
        public byte byRuleConfMode;   //规则配置跟踪模式0-本地配置跟踪，1-远程配置跟踪
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   //保留，置0
        [StructLayout(LayoutKind.Explicit)]
        public struct uModeParam
        {
            [FieldOffsetAttribute(0)]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            public uint[] dwULen;
        }
    }
}
