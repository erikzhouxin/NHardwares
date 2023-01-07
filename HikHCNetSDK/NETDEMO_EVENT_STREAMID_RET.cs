using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //流id录像查询结果
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_STREAMID_RET
    {
        public uint dwRecordType;   //录像类型 0-定时录像 1-移动侦测 2-报警录像 3-报警|移动侦测 4-报警&移动侦测 5-命令触发 6-手动录像 7-震动报警 8-环境触发 9-智能报警 10-回传录像
        public uint dwRecordLength; //录像大小
        public byte byLockFlag;    // 锁定标志 0：没锁定 1：锁定
        public byte byDrawFrameType;    // 0：非抽帧录像 1：抽帧录像
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byFileName;   //文件名
        public uint dwFileIndex;            // 存档卷上的文件索引
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes1 = new byte[2];
            byFileName = new byte[HikHCNetSdk.NAME_LEN];
            byRes = new byte[256];
        }
    }


}
