using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FILECOND_V40
    {
        public Int32 lChannel;
        public uint dwFileType;
        public uint dwIsLocked;
        public uint dwUseCardNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.CARDNUM_LEN_OUT, ArraySubType = UnmanagedType.I1)]
        public byte[] sCardNumber;
        public NET_DVR_TIME struStartTime;
        public NET_DVR_TIME struStopTime;
        public byte byDrawFrame; //0:不抽帧，1：抽帧
        public byte byFindType; //0:查询普通卷，1：查询存档卷
        public byte byQuickSearch; //0:普通查询，1：快速（日历）查询
        public byte bySpecialFindInfoType;    //专有查询条件类型 0-无效， 1-带ATM查询条件  
        public uint dwVolumeNum;  //存档卷号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.GUID_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byWorkingDeviceGUID;    //工作机GUID，通过获取N+1得到
        public NET_DVR_SPECIAL_FINDINFO_UNION uSpecialFindInfo;   //专有查询条件
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;    //保留
    }
}
