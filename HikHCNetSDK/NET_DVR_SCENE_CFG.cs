using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //场景配置结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCENE_CFG
    {
        public uint dwSize;                                          //结构大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ITS_SCENE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ONE_SCENE_CFG[] struSceneCfg; //场景配置信息
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;                                      //保留
    }



}
