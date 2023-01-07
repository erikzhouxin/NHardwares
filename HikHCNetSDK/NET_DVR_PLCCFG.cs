using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PLCCFG
    {
        public uint dwSize;
        public byte byPlcEnable;    //是否启用车牌亮度补偿（默认启用）：0-关闭，1-启用 
        public byte byPlateExpectedBright;  //车牌的预期亮度（默认值50）, 范围[0, 100]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;   //保留 
        public byte byTradeoffFlash;     //是否考虑闪光灯的影响: 0 - 否;  1 - 是(默认); 
                                         //使用闪光灯补光时, 如果考虑减弱闪光灯的亮度增强效应, 则需要设为1;否则为0
        public byte byCorrectFactor;     //纠正系数, 范围[0, 100], 默认值50 (在tradeoff_flash切换时,恢复默认值）
        public ushort wLoopStatsEn;  //是否该线圈的亮度，按位表示，0-不统计，1-统计
        public byte byPlcBrightOffset;// 车牌亮度补偿灵敏度(虚拟线圈模式起效)，取值范围1~100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 19, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
