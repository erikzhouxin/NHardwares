using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_WALLSCENECFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSceneName;    //场景名称
        public byte byEnable;                //场景是否有效，0-无效，1-有效
        public byte bySceneIndex;            //场景号，只能获取。获取所有场景时使用该参数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 78, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
