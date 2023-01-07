using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //场景巡航跟踪配置信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PATROL_TRACKCFG
    {
        public uint dwSize;  // 结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_PATROL_SCENE_INFO[] struPatrolSceneInfo;    // 巡航路径
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                              // 保留字节
    }


}
