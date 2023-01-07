using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //电视墙输出位置配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEOWALLDISPLAYPOSITION
    {
        public uint dwSize;
        public byte byEnable; //使能：0- 禁用，1- 启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwVideoWallNo;//电视墙号(组合)
        public uint dwDisplayNo;  //显示输出号(组合)，批量获取全部时有效
        public NET_DVR_RECTCFG_EX struRectCfg;//位置坐标，须为基准坐标（通过能力集获取）的整数倍，宽度和高度值不用设置，即为基准值
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
