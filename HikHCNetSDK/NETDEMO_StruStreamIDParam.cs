using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct struStreamIDParam
    {
        public NET_DVR_STREAM_INFO struIDInfo;
        public uint dwCmdType;
        public byte byBackupVolumeNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byArchiveLabel;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 656, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            byRes1 = new byte[3];
            byArchiveLabel = new byte[64];
            byRes = new byte[656];
            struIDInfo.Init();
        }
    }
}
