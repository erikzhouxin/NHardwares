using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //热度图报警上传
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HEATMAP_RESULT
    {
        public uint dwSize;
        public NET_VCA_DEV_INFO struDevInfo;/*设备信息*/
        public NET_DVR_TIME_EX struStartTime;/*开始时间*/
        public NET_DVR_TIME_EX struEndTime;/*结束时间*/
        public uint dwMaxHeatMapValue;//最大热度值
        public uint dwMinHeatMapValue;//最小热度值
        public uint dwTimeHeatMapValue;// (时间热度值)平均热度值
        public ushort wArrayLine;//图片像素点行值 
        public ushort wArrayColumn;//图片像素点列值 （当行列值为0的时候，像素点值内存信息不存在）
        public IntPtr pBuffer;  //热度图片像素点数据信息
        public byte byDetSceneID;//检测场景号[1],球机当前支持1个场景, IPC默认是0
        public byte byBrokenNetHttp;     //断网续传标志位，0-不是重传数据，1-重传数据
        public ushort wDevInfoIvmsChannelEx;     //与NET_VCA_DEV_INFO里的byIvmsChannel含义相同，能表示更大的值。老客户端用byIvmsChannel能继续兼容，但是最大到255。新客户端版本请使用wDevInfoIvmsChannelEx。
        public byte byTimeDiffFlag;      /*时差字段是否有效  0-时差无效， 1-时差有效 */
        public byte cStartTimeDifferenceH;      /*开始时间与UTC的时差（小时），-12 ... +14，+表示东区*/
        public byte cStartTimeDifferenceM;      /*开始时间与UTC的时差（分钟），-30, 30, 45，+表示东区*/
        public byte cStopTimeDifferenceH;        /*结束时间与UTC的时差（小时），-12 ... +14， +表示东区*/
        public byte cStopTimeDifferenceM;       /*结束时间与UTC的时差（分钟），-30, 30, 45，+表示东区*/
        public byte byArrayUnitType; //矩阵单元数据类型（矩阵信息中每个像素点数据的数据类型），1-byte，2-short,4-int
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public uint dwTotalTime;//停留时间总和，单位秒，按人员停留时间报警时上传
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 112, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
