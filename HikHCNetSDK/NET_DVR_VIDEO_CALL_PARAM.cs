using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VIDEO_CALL_PARAM
    {
        public uint dwSize;
        public uint dwCmdType;      //信令类型  0-请求呼叫，1-取消本次呼叫，2-接听本次呼叫 3-拒绝本地来电呼叫 4-被叫响铃超时 5-结束本次通话，6-设备正在通话中，7-客户端正在通话中，8室内机不在线
        public ushort wPeriod;  //期号, 范围[0,9]
        public ushort wBuildingNumber; //楼号
        public ushort wUnitNumber;  //单元号
        public ushort wFloorNumber;  //层号
        public ushort wRoomNumber;    //房间号
        public ushort wDevIndex; //设备编号
        public byte byUnitType; //设备类型，1-门口机，2-管理机，3-室内机，4-围墙机，5-别墅门口机，6-二次确认机，7-8700客户端，8-4200客户端，9-APP
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 115, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;     //保留
    }
}
