using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DRAWFRAME_DISK_QUOTA_CFG
    {
        public uint dwSize;                 //结构体大小
        public byte byPicQuota;             //图片百分比	 [0%,  30%]
        public byte byRecordQuota;              //普通录像百分比 [20%, 40%]
        public byte byDrawFrameRecordQuota; //抽帧录像百分比 [30%, 80%]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 61, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                    //保留字节
    }
}
