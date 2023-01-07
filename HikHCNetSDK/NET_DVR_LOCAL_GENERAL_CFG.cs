using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LOCAL_GENERAL_CFG
    {
        public byte byExceptionCbDirectly;    //0-通过线程池异常回调，1-直接异常回调给上层
        public byte byNotSplitRecordFile;     //回放和预览中保存到本地录像文件不切片 0-默认切片，1-不切片
        public byte byResumeUpgradeEnable;    //断网续传升级使能，0-关闭（默认），1-开启
        public byte byAlarmJsonPictureSeparate;   //控制JSON透传报警数据和图片是否分离，0-不分离，1-分离（分离后走COMM_ISAPI_ALARM回调返回）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      //保留
        public Int64 i64FileSize;      //单位：Byte
        public uint dwResumeUpgradeTimeout;       //断网续传重连超时时间，单位毫秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 236, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;    //预留
    }
}
