using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_SCENECFG
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sSceneName;
        public byte byBigScreenNums;//大屏的个数，最大值通过能力集获取
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public ushort wDecChanNums;//场景中解码通道的个数
        public ushort wDispChanNums;//场景中显示通道的个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        public IntPtr pBigScreenBuffer;//大屏配置缓冲区, byBigScreenNums×sizeof(NET_DVR_BIGSCREENCFG_SCENE)
        public IntPtr pDecChanBuffer;//解码通道配置缓冲区, wDecChanNums×sizeof(NET_DVR_DECODECHANCFG_SCENE)
        public IntPtr pDispChanBuffer;//显示通道配置缓冲区, wDispChanNums×sizeof(NET_DVR_SCENEDISPCFG)
        public void Init()
        {
            sSceneName = new byte[HikHCNetSdk.NAME_LEN];
            byRes1 = new byte[3];
            byRes1 = new byte[12];
        }
    }
}
