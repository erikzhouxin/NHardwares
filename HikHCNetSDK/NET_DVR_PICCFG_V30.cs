using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通道图象结构(9000扩展)
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_PICCFG_V30
    {
        public uint dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sChanName;
        public uint dwVideoFormat;/* 只读 视频制式 1-NTSC 2-PAL*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byReservedData;/*保留*/
        //显示通道名
        public uint dwShowChanName;// 预览的图象上是否显示通道名称,0-不显示,1-显示 区域大小704*576
        public ushort wShowNameTopLeftX;/* 通道名称显示位置的x坐标 */
        public ushort wShowNameTopLeftY;/* 通道名称显示位置的y坐标 */
        //视频信号丢失报警
        public NET_DVR_VILOST_V30 struVILost;
        public NET_DVR_VILOST_V30 struRes;/*保留*/
        //移动侦测
        public NET_DVR_MOTION_V30 struMotion;
        //遮挡报警
        public NET_DVR_HIDEALARM_V30 struHideAlarm;
        //遮挡  区域大小704*576
        public uint dwEnableHide;/* 是否启动遮挡 ,0-否,1-是*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SHELTERNUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SHELTER[] struShelter;
        //OSD
        public uint dwShowOsd;// 预览的图象上是否显示OSD,0-不显示,1-显示 区域大小704*576
        public ushort wOSDTopLeftX;/* OSD的x坐标 */
        public ushort wOSDTopLeftY;/* OSD的y坐标 */
        public byte byOSDType;/* OSD类型(主要是年月日格式) */
        /* 0: XXXX-XX-XX 年月日 */
        /* 1: XX-XX-XXXX 月日年 */
        /* 2: XXXX年XX月XX日 */
        /* 3: XX月XX日XXXX年 */
        /* 4: XX-XX-XXXX 日月年*/
        /* 5: XX日XX月XXXX年 */
        public byte byDispWeek;/* 是否显示星期 */
        public byte byOSDAttrib;/* OSD属性:透明，闪烁 */
        /* 0: 不显示OSD */
        /* 1: 透明,闪烁 */
        /* 2: 透明,不闪烁 */
        /* 3: 闪烁,不透明 */
        /* 4: 不透明,不闪烁 */
        public byte byHourOSDType;/* OSD小时制:0-24小时制,1-12小时制 */
        public byte byFontSize;//字体大小，16*16(中)/8*16(英)，1-32*32(中)/16*32(英)，2-64*64(中)/32*64(英)  3-48*48(中)/24*48(英) 0xff-自适应(adaptive)
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
