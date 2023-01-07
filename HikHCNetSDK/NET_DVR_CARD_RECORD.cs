using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CARD_RECORD
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo; //card No
        public byte byCardType;
        public byte byLeaderCard;
        public byte byUserType;
        public byte byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
        public byte[] byDoorRight;
        public NET_DVR_VALID_PERIOD_CFG struValid;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_GROUP_NUM_128, ArraySubType = UnmanagedType.I1)]
        public byte[] byBelongGroup;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CARD_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardPassword;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
        public ushort[] wCardRightPlan;
        public uint dwMaxSwipeTimes;
        public uint dwSwipeTimes;
        public uint dwEmployeeNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byName;
        //按位表示，0-无权限，1-有权限
        //第0位表示：弱电报警
        //第1位表示：开门提示音
        //第2位表示：限制客卡
        //第3位表示：通道
        //第4位表示：反锁开门
        //第5位表示：巡更功能
        public uint dwCardRight;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byDoorRight = new byte[HikHCNetSdk.MAX_DOOR_NUM_256];
            byBelongGroup = new byte[HikHCNetSdk.MAX_GROUP_NUM_128];
            byCardPassword = new byte[HikHCNetSdk.CARD_PASSWORD_LEN];
            wCardRightPlan = new ushort[HikHCNetSdk.MAX_DOOR_NUM_256];
            byName = new byte[HikHCNetSdk.NAME_LEN];
            byRes = new byte[256];
        }
    }
}
