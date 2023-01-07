using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACESNAP_INFO_ALARM_LOG
    {
        public uint dwRelativeTime;     // 相对时标
        public uint dwAbsTime;          // 绝对时标
        public uint dwSnapFacePicID;       //抓拍人脸图ID
        public NET_VCA_DEV_INFO struDevInfo;        //前端设备信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              // 保留字节
    }
}
