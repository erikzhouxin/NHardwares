using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ALARMHOST_ABILITY
    {
        public uint dwSize;                      // 结构体大小
        public ushort wTotalAlarmInNum;         // 报警输入口总数(防区),包括级联
        public ushort wLocalAlarmInNum;         // 本地报警输入口
        public ushort wExpandAlarmInNum;        // 可扩展的报警输入口
        public ushort wTotalAlarmOutNum;        // 报警输出口总数 （设备支持的总数）
        public ushort wLocalAlarmOutNum;        // 本地报警输出口个数
        public ushort wExpandAlarmOutNum;       // 可扩展的报警输出口
        public ushort wTotalRs485Num;           // 报警输出口总数 （设备支持的总数）
        public ushort wLocalRs485Num;           // 本地485口数
        public ushort wExpandRs485Num;          // 可扩展的485口数
        public ushort wFullDuplexRs485Num;    // 全双工的485口数
        public ushort wTotalSensorNum;          // 模拟量最大个数 (设备支持的总数)
        public ushort wLocalSensorNum;        // 本地模拟量个数
        public ushort wExpandSensorNum;         // 可扩展的模拟量个数
        public ushort wAudioOutNum;                //语音输出个数
        public ushort wGatewayNum;            //门禁个数
        public ushort wElectroLockNum;            //电锁个数
        public ushort wSirenNum;                 // 主机警号数目
        public ushort wSubSystemNum;            // 可划分子系统数目
        public ushort wNetUserNum;            // 网络用户数
        public ushort wKeyboardNum;           // 键盘数
        public ushort wOperatorUserNum;           // 操作用户数
        public byte bySupportDetector;//是否支持常开、常闭探测器，1-支持，0-不支持
        public byte bySupportSensitivity;//是否支持防区灵敏度，1-支持，0-不支持
        public byte bySupportArrayBypass;//是否支持组旁路，1-支持，0-不支持
        public byte bySupportAlarmInDelay;//是否支持防区延迟,1-支持，0-不支持
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] bySupportAlarmInType;//支持的防区类型,数组0:即时防区,1-24小时防区,2-延时防区 ,3-内部防区，4-钥匙防区 5-火警防区 6-周界防区 7-24小时无声防区 8-24小时辅助防区，9-24小时震动防区,10-门禁紧急开门防区，11-门禁紧急关门防区15-无
        public byte byTelNum;        //支持电话个数
        public byte byCenterGroupNum;    //中心组个数
        public byte byGPRSNum;        //GPRS中心数，最多4个
        public byte byNetNum;        //网络中心数，最多4个
        public byte byAudioNum;        //音频个数
        public byte by3GNum;        //3G模块个数
        public byte byAnalogVideoChanNum;        //模拟视频通道个数
        public byte byDigitalVideoChanNum;        //数字视频通道个数
        public byte bySubSystemArmType;        //子系统布防类型，0-表示不支持，1-表示支持。bit0-普通布防（注：网络小主机只支持普通布防，在能力集中加这个字段的时候网络小主机已经发布，所以网络小主机中该字段为0，所以用0表示支持，1表示不支持。对外接口中SDK内部会做兼容），bit1-即时布防，bit2-留守布防。    
        public byte byPublicSubSystemNum;    //公共子系统个数

        public uint dwSupport1;    //按位表示，结果非0表示支持，0表示不支持
        public uint dwSubSystemEvent;        //子系统事件，按位表示，0表示不支持，非0表示支持,bit0-进入延时，bit1-退出延时，bit2-布防，bit3-撤防，bit4-报警，bit5-消除报警记忆
        public uint dwOverallEvent;            //全局事件，按位表示，0表示不支持，非0表示支持，bit0-交流电掉电，bit1-电池电压低，bit2-电话线掉线，bit3-有线网络异常，bit4-无线网络异常，bit5-硬盘故障,bit6-3G/4G信号异常, bit7-（模块链接）第三方主机掉线,bit8-WIFI通信故障，bit9-RF信号干扰故障
        public uint dwFaultType;            //设备支持的故障类型，bit0-交流电断电，bit1-蓄电池欠压，bit2-主机防拆开，bit3-电话线掉线，bit4-主键盘掉线，bit5-网络故障，bit6-无线异常，bit7-扩展总线异常，bit8-硬盘异常    

        public byte byPublicSubsystemAssociateSubsystemNum;    //公共子系统可关联的子系统个数
        public byte byOverallKeyboard;    //全局键盘个数
        public ushort wSafetyCabinSupport; //防护舱控制器能力，按位表示，结果非0表示支持，0表示不支持    

        public byte by485SlotNum;        //485虚拟槽位号
        public byte bySubSystemAttributeAbility;  // 值恒为1，禁止1号子系统关闭使能

        public ushort wKeyboardAddrNum;      // 键盘地址数
        public byte byAlarmLampNum;         //警灯数目
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 117, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;            //  保留字节
        public void Init()
        {
            bySupportAlarmInType = new byte[16];
            byRes = new byte[117];
        }
    }

}
