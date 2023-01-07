using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR本地预览参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PREVIEWCFG
    {
        public uint dwSize;
        public byte byPreviewNumber;//预览数目,0-1画面,1-4画面,2-9画面,3-16画面,0xff:最大画面
        public byte byEnableAudio;//是否声音预览,0-不预览,1-预览
        public ushort wSwitchTime;//切换时间,0-不切换,1-5s,2-10s,3-20s,4-30s,5-60s,6-120s,7-300s
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_WINDOW, ArraySubType = UnmanagedType.I1)]
        public byte[] bySwitchSeq;//切换顺序,如果lSwitchSeq[i]为 0xff表示不用
    }

}
