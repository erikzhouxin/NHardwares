using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道能力输入参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_CHAN_IN_PARAM
    {
        public byte byVCAType;//VCA_CHAN_ABILITY_TYPE枚举值
        public byte byMode;//模式，VCA_CHAN_MODE_TYPE ,atm能力的时候需要配置
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，设置为0 
    }

}
