using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //开锁记录
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_UNLOCK_RECORD_INFO
    {
        public byte byUnlockType; //开锁方式，参考UNLOCK_TYPE_ENUM
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1; //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byControlSrc; //操作发起源信息，刷卡开锁时为卡号，蓝牙开锁时为萤石的APP账号，二维码开锁时为访客的手机号，其余情况下为设备编号
        public uint dwPicDataLen; //图片数据长度
        public IntPtr pImage; //图片指针
        public uint dwCardUserID; //持卡人ID
        public ushort nFloorNumber;//刷卡开锁时有效，为楼层号
        public ushort wRoomNumber; //操作发起源附加信息，刷卡开锁时有效，为房间号，
        public ushort wLockID; //（对于门口机，0-表示本机控制器上接的锁、1-表示外接控制器上接的锁）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.LOCK_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byLockName; //刷卡开锁时有效，锁名称，对应门参数配置中门名称
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byEmployeeNo; //工号（人员ID）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 136, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留
    }
}
