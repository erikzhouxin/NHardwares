using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 交通参数统计信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_TPS_STATISTICS_PARAM
    {
        public byte byStart;          // 开始码
        public byte byCMD;         // 命令号， 08-定时成组数据指令
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 预留字节
        public ushort wDeviceID;      // 设备ID
        public ushort wDataLen;       // 数据长度
        public byte byTotalLaneNum;  // 有效车道总数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_TIME_V30 struStartTime;    //统计开始时间
        public uint dwSamplePeriod;    //统计时间,单位秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_TPS_RULE, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_TPS_LANE_PARAM[] struLaneParam;
    }



}
