using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //事件搜索条件
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SEARCH_EVENT_PARAM_V40
    {
        public ushort wMajorType;            //0-移动侦测，1-报警输入, 2-智能事件 5-pos录像 7-门禁事件
        public ushort wMinorType;            //搜索次类型- 根据主类型变化，0xffff表示全部
        public NET_DVR_TIME struStartTime;    //搜索的开始时间，停止时间: 同时为(0, 0) 表示从最早的时间开始，到最后，最前面的4000个事件
        public NET_DVR_TIME struEndTime;    //
        public byte byLockType;        // 0xff-全部，0-未锁，1-锁定
        public byte byQuickSearch;        // 是否启用快速查询，0-不启用，1-启用（快速查询不会返回文件大小，仅对设备数据库进行查询，避免频繁唤醒硬盘）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 130, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;// 保留
        public UNION_EVENT_PARAM uSeniorParam;

        public void Init()
        {
            byRes = new byte[130];
            uSeniorParam.Init();
        }
    }
}
