using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单条场景配置信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ONE_SCENE_CFG
    {
        public byte byEnable;                 //是否启用该场景,0-不启用 1- 启用
        public byte byDirection;              //监测方向 1-上行，2-下行，3-双向，4-由东向西，5-由南向北，6-由西向东，7-由北向南，8-其它
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;                //保留
        public uint dwSceneID;                //场景ID(只读), 0 - 表示该场景无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] bySceneName;    //场景名称
        public NET_DVR_PTZPOS struPtzPos;       //ptz 坐标
        public uint dwTrackTime;              //球机跟踪时间[5,300] 秒，TFS(交通取证)模式下有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;               //保留
    }



}
