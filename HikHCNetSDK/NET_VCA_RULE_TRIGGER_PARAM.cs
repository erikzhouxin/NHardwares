using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //规则触发参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_RULE_TRIGGER_PARAM
    {
        public byte byTriggerMode;   //规则的触发方式，0- 不启用，1- 轨迹点 2- 目标面积 
        public byte byTriggerPoint;  //触发点，触发方式为轨迹点时有效 0- 中,1-上,2-下
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;       //保留
        public float fTriggerArea;    //触发目标面积百分比 [0,100]，触发方式为目标面积时有效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;       //保留
    }

}
