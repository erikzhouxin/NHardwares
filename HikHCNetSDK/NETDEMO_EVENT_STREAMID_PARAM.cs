using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_STREAMID_PARAM
    {
        public NET_DVR_STREAM_INFO struIDInfo; // 流id信息，72字节长
        public uint dwCmdType;  // 外部触发类型，NVR接入云存储使用
        public byte byBackupVolumeNum; //存档卷号，CVR使用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 223, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            struIDInfo.Init();
            byRes = new byte[223];
        }
    }


}
