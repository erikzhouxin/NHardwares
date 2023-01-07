using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_BIGSCREENCFG_SCENE
    {
        public byte byAllValid; /*漫游使能标志 */
        public byte byAssociateBaseMap;//关联的底图序号，0代表不关联
        public byte byEnableSpartan;//大屏畅显使能，1-开，0-关
        public byte byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_LAYERNUMS, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_WINCFG[] struWinCfg;
        public NET_DVR_BIGSCREENCFG struBigScreen;

        public void Init()
        {
            struBigScreen = new NET_DVR_BIGSCREENCFG();
            struWinCfg = new NET_DVR_WINCFG[HikHCNetSdk.MAX_LAYERNUMS];
        }
    }
}
