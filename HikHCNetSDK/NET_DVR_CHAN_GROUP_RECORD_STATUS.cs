using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //****NVR end***//
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHAN_GROUP_RECORD_STATUS
    {
        public uint dwSize; //结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CHANNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_CHANS_RECORD_STATUS[] struChanStatus; //一组64个
    }
}
