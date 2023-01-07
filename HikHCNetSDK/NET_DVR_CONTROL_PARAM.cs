using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*******************************预案控制*******************************/
    //该结构体可作为通用控制结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CONTROL_PARAM
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDeviceID; //被控设备的设备ID
        public ushort wChan;                 //被控通道
        public byte byIndex;             //控制索引，根据命令确定具体表示什么索引
        public byte byRes1;
        public uint dwControlParam;
        public byte byMandatoryAlarm;    //1-使能  0-不使能
        public byte byRes2;
        public ushort wZoneIndex;  //防区号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byOperatorCode;//回控码
        public uint dwPlanNo; //4字节预案号，客户端统一使用4字节的预案号，单字节的预案号不再使用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
