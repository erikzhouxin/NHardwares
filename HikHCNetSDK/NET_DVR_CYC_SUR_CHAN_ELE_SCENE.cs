using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CYC_SUR_CHAN_ELE_SCENE
    {
        public byte byEnable;   /* 是否启用 0－否 1－启用*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public NET_DVR_STREAM_MEDIA_SERVER_CFG_SCENE struStreamMediaSvrCfg;
        public NET_DVR_DEV_CHAN_INFO_SCENE struDecChanInfo; /*轮巡解码通道信息*/
    }
}
