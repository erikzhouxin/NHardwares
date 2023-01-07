using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINGER_PRINT_INFO_CTRL_V50_ByCardNo
    {
        public int dwSize;
        public byte byMode;  //删除方式，0-按卡号（人员ID）方式删除，1-按读卡器删除
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byRes1;
        public NET_DVR_FINGER_PRINT_BYCARD_V50 struProcessMode;//处理方式
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byRes;
        public void Init()
        {
            byRes1 = new byte[3];
            byRes = new byte[64];
            struProcessMode.Init();
        }
    }

}
