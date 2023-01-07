using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LF_TRACK_MODE
    {
        public uint dwSize;//结构长度
        public byte byTrackMode;//跟踪模式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，置0
        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct uModeParam
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
            [FieldOffsetAttribute(0)]
            public uint[] dwULen;
            /*[FieldOffsetAttribute(0)]
            public NET_DVR_LF_MANUAL_CTRL_INFO struManualCtrl;//手动跟踪结构
            [FieldOffsetAttribute(0)]
            public NET_DVR_LF_TRACK_TARGET_INFO struTargetTrack;//目标跟踪结构
             * */
        }
    }
}
