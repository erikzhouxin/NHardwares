using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SCREENALARMCFG
    {
        public uint dwSize;
        public byte byAlarmType;    //报警类型，1-子板拔出，2-子板插入，3-子系统状态异常，4-子系统恢复恢复 5-输入源异常   6-温度报警 7-FPGA版本不匹配 8-预案开始 9-预案结束 10-解码板断网 11-解码板IP地址冲突，12-风扇异常
        public byte byBoardType;    // 1-输入板 2-输出板 ，3-主板，4-背板，报警类型为1，2，3，6的时候使用 
        public byte bySubException; //输入异常时具体子异常 1- 分辨率正常改变 2-输入端口类型改变3-分辨率错误4-分辨率改变导致解码资源不足，关闭该输入源对应窗口。5-分辨率改变，导致已开窗的缩放比例不在1/8到8倍范围。6-分辨率恢复正常,7-分辨率改变导致输出板数据量超限,设备关闭窗口 
        public byte byRes1;
        public ushort wStartInputNum; // 异常输入源（异常起点） 
        public ushort wEndInputNum; // 异常输入源（异常终点） 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
