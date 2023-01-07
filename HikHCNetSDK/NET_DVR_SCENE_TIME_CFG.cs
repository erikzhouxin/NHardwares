using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //场景起效时间段配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCENE_TIME_CFG
    {
        public uint dwSize;                                               //结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SCENE_TIMESEG_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_SCENE_TIME[] struSceneTime; //场景时间段数组
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                                            //保留
    }



}
