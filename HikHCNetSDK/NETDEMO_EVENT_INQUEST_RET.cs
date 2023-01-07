using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //审讯事件查询结果 
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct EVENT_INQUEST_RET
    {
        public byte byRoomIndex;  //审讯室编号,从1开始
        public byte byDriveIndex; //刻录机编号,从1开始
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;  //保留            
        public uint dwSegmentNo;     //本片断在本次审讯中的序号,从1开始 
        public ushort wSegmetSize;     //本片断的大小, 单位M 
        public ushort wSegmentState;   //本片断状态 0 刻录正常，1 刻录异常，2 不刻录审讯
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 288, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;     //保留

        public void Init()
        {
            byRes1 = new byte[6];
            byRes2 = new byte[288];
        }
    }


}
