using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_PARAM_CTRL_CARDNO
    {
        public int dwSize;
        public byte byMode;//删除方式，0-按卡号方式删除，1-按读卡器删除
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_FACE_PARAM_BYCARD struByCard;//按卡号的方式删除,读卡器暂时不写
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            byRes1 = new byte[3];
            byRes = new byte[64];
            struByCard.Init();
        }
    }
}
