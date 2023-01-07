using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //轮巡解码结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_LOOP_DECINFO_SCENE
    {
        public ushort wPoolTime;        /*轮询间隔*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CYCLE_CHAN, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CYC_SUR_CHAN_ELE_SCENE[] struChanArray;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
