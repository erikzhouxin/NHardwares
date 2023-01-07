using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单条场景时间段
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ONE_SCENE_TIME
    {
        public byte byActive;                     //0 -无效,1–有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;                    //保留
        public uint dwSceneID;                    //场景ID
        public NET_DVR_SCHEDTIME struEffectiveTime;   //场景起效时间
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                   //保留
    }



}
