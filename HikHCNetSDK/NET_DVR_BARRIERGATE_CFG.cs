using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //道闸控制参数
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_BARRIERGATE_CFG
    {
        public uint dwSize;
        public uint dwChannel;//通道号
        public byte byLaneNo; //道闸号（0-表示无效值(设备需要做有效值判断),1-道闸1）
        public byte byBarrierGateCtrl;//0-关闭道闸,1-开启道闸,2-停止道闸 3-锁定道闸,4~解锁道闸
        public byte byEntranceNo;//出入口编号 [1,8]
        public byte byUnlock;//启用解锁使能，0~为不启用，1~启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
