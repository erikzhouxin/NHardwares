using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //报警场景信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCENE_INFO
    {
        public uint dwSceneID;              //场景ID, 0 - 表示该场景无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] bySceneName;  //场景名称
        public byte byDirection;            //监测方向 1-上行，2-下行，3-双向，4-由东向西，5-由南向北，6-由西向东，7-由北向南，8-其它
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;              //保留
        public NET_DVR_PTZPOS struPtzPos;             //Ptz 坐标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;            //保留
    }



}
