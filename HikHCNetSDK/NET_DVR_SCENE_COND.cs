using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //多场景操作条件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCENE_COND
    {
        public uint dwSize;       //结构大小
        public Int32 lChannel;     //通道号
        public uint dwSceneID;    //场景ID, 0-表示该场景无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 48, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;    //保留
    }



}
