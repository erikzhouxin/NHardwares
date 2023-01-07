using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VCA_CTRLINFO_CFG
    {
        public uint dwSize;
        public byte byVCAEnable;     //是否开启智能
        public byte byVCAType;       //智能能力类型，VCA_CHAN_ABILITY_TYPE 
        public byte byStreamWithVCA; //码流中是否带智能信息
        public byte byMode;         //模式，ATM 能力时参照VCA_CHAN_MODE_TYPE ,TFS 能力时参照 TFS_CHAN_MODE_TYPE，行为分析完整版时参照BEHAVIOR_SCENE_MODE_TYPE
        public byte byControlType;   //控制类型，按位表示，0-否，1-是
                                     //byControlType &1 是否启用抓拍功能
                                     //byControlType &2 是否启用联动前端设备
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 83, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留，设置为0
    }


}
