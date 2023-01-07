using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人脸抓拍附加信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FACESNAP_ADDINFO
    {
        //人脸矩形框,该坐标为人脸小图(头肩照)中人脸的坐标
        public NET_VCA_RECT struFacePicRect;
        public int iSwingAngle;//旋转角, -90~90度
        public int iTiltAngle;//俯仰角, -90~90度
        public uint dwPupilDistance;//瞳距,范围为：最小值为10像素,最大值为当前分辨率宽度/1.6
        public byte byBlockingState;//目标遮挡状态， 0-表示“未知”（算法不支持）,1~无遮挡,2~瞬时轻度遮挡，3~持续轻度遮挡，4~严重遮挡
        public byte byFaceSnapThermometryEnabled;//人脸抓拍测温使能 1-开启 0-关闭
        public byte byIsAbnomalTemperature;//人脸抓拍测温是否温度异常 1-是 0-否
        public byte byThermometryUnit;//测温单位: 0-摄氏度（℃），1-华氏度（℉），2-开尔文(K)
        public NET_DVR_TIME_EX struEnterTime;   // 最佳抓拍下进入时间
        public NET_DVR_TIME_EX struExitTime;    // 最佳抓拍下离开时间
        public float fFaceTemperature; // 人脸温度（ - 20.0℃~150.0℃，精确到小数点后1位）
        public float fAlarmTemperature;// 测温报警警阈值（精确到小数点后1位）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 472, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;// 保留字节
    }
}
