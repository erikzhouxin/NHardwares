using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LOOPPLAN_SUBCFG
    {
        public uint dwSize;
        public uint dwPoolTime; /*轮询间隔，单位：秒*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CYCLE_CHAN_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_MATRIX_CHAN_INFO_V30[] struChanConInfo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
