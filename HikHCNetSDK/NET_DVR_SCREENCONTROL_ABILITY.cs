using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //多屏控制器能力集
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREENCONTROL_ABILITY
    {
        public uint dwSize;         /*结构长度*/
        public byte byLayoutNum;        /* 布局个数*/
        public byte byWinNum;           /*屏幕窗口个数*/
        public byte byOsdNum;       /*OSD个数*/
        public byte byLogoNum;      /*Logo个数*/
        public byte byInputStreamNum;  //输入源个数 ---设备支持最大输入通道个数（包括本地输入源和网络输入源）
        public byte byOutputChanNum;    //输出通道个数---设备支持最大输出通道个数
        public byte byCamGroupNum;      /*分组个数*/
        public byte byPlanNum;          /*预案个数*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public byte byIsSupportPlayBack;  /*是否支持回放*/
        public byte byMatrixInputNum;  //支持输入矩阵最大个数
        public byte byMatrixOutputNum; //支持输出矩阵最大个数
        public NET_DVR_DISPINFO struVgaInfo;//VGA输出信息
        public NET_DVR_DISPINFO struBncInfo;//BNC输出信息
        public NET_DVR_DISPINFO struHdmiInfo;//HDMI输出信息
        public NET_DVR_DISPINFO struDviInfo;//DVI输出信息
        public byte byMaxUserNums;//支持用户数
        public byte byPicSpan;      //底图跨度，一张底图最多可覆盖的屏幕数
        public ushort wDVCSDevNum;  //分布式大屏控制器最大设备数
        public ushort wNetSignalNum;    //最大网络输入源个数
        public ushort wBaseCoordinateX;//基准坐标
        public ushort wBaseCoordinateY;
        public byte byExternalMatrixNum;    //最大外接矩阵个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 49, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
