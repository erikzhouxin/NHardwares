using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_CTRLINFO
    {
        public byte byVCAEnable;//是否开启智能
        public byte byVCAType;//智能能力类型，VCA_CHAN_ABILITY_TYPE 
        public byte byStreamWithVCA;//码流中是否带智能信息
        public byte byMode;//模式，VCA_CHAN_MODE_TYPE ,atm能力的时候需要配置
        public byte byControlType;   //控制类型，按位表示，0-否，1-是
                                     // byControlType &1 是否启用抓拍功能
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，设置为0 
    }

}
