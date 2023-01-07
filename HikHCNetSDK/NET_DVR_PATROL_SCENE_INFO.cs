using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //巡航路径场景信息
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PATROL_SCENE_INFO
    {
        public ushort wDwell;         // 停留时间 30-300
        public byte byPositionID;   // 场景号1-10，默认0表示该巡航点不添加场景
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
